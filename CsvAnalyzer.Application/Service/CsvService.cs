using CsvAnalyzer.Application.Common.Errors;
using CsvAnalyzer.Application.Common.FilesModel;
using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Application.Mapping;
using CsvAnalyzer.Domain.Results;
using CsvAnalyzer.Domain.Value;
using CsvAnalyzer.Domain.Values.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using ErrorOr;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace CsvAnalyzer.Application.Service
{
    public class CsvService(IFilesRepository _filesRepository,
                            IResultsRepository _resultsRepository,
                            ICsvValidator _csvValidator,
                            IUnitOfWork _unit)
    {
        public async Task<ErrorOr<Success>> ProccessCsvAsync(Stream file, string fileName)
        {
            using var reader = new StreamReader(file);
            using var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                DetectDelimiter = true,
                HasHeaderRecord = true,
                MissingFieldFound = ConfigurationFunctions.MissingFieldFound,
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            });
            csvReader.Context.RegisterClassMap<CsvFileMapper>();

            var recordOrError = await _csvValidator.CsvValidateAsync(csvReader);

            if (recordOrError.IsError)
                return recordOrError.Errors;

            if (recordOrError.Value is null)
                return CsvServiceErrors.CsvLinesNullValue;

            var savefileResult = await SaveFileAsync(fileName, recordOrError.Value);

            if (savefileResult.IsError)
                return savefileResult.Errors;

            var fileEntry = await CalculateResultsAsync(savefileResult.Value);

            return Result.Success;
        }

        public async Task<ErrorOr<Guid>> SaveFileAsync(string fileName, List<CsvModel> csvLines)
        {
            var fileEntry = FileEntry.Create(fileName);

            if (!await _filesRepository.ExistsByNameAsync(fileName))
            {
                var fileValues = csvLines.Select(x => FileValuesEntry.Create(
                    x.Date!.Value,
                    x.ExecutionTime!.Value,
                    x.Value!.Value,
                    fileEntry.Id)).ToList();

                await _filesRepository.SaveFileInfoAsync(fileEntry);
                await _filesRepository.SaveFileLinesAsync(fileValues);
            }
            else
            {
                fileEntry = await _filesRepository.GetByNameAsync(fileName);

                var fileValues = csvLines.Select(x => FileValuesEntry.Create(
                    x.Date!.Value,
                    x.ExecutionTime!.Value,
                    x.Value!.Value,
                    fileEntry!.Id)).ToList();

                await _filesRepository.RemoveValuesAsync(fileEntry.Id);
                await _filesRepository.SaveFileLinesAsync(fileValues);
            }

            await _unit.CommitChanges(); // транзакцию добавить

            return fileEntry.Id;
        }

        public async Task<ErrorOr<Success>> CalculateResultsAsync(Guid fileEntryId)
        {
            var fileEntry = await _filesRepository.GetByIdAsync(fileEntryId);
            var fileValues = fileEntry?.FileValues;

            var dates = fileValues.Select(e => e.Date).OrderBy(d => d).ToList();
            var values = fileValues.Select(e => e.Value).OrderBy(v => v).ToList();
            var executionTimes = fileValues.Select(e => e.ExecutionTime).ToList();

            var minDate = dates.First();
            var maxDate = dates.Last();

            var timeDeltaSeconds = (maxDate - minDate).TotalSeconds;

            var avgExec = executionTimes.Average();
            var avgValue = values.Average();

            double medianValue;
            int count = values.Count;
            if (count % 2 == 0)
                medianValue = (values[count / 2 - 1] + values[count / 2]) / 2.0;
            else
                medianValue = values[count / 2];

            var minValue = values.First();
            var maxValue = values.Last();

            var resultEntry = ResultEntry.Create(
                timeDeltaSeconds,
                minDate,
                avgExec,
                avgValue,
                medianValue,
                maxValue,
                minValue,
                fileEntryId);

            await _resultsRepository.AddResultAsync(resultEntry); // транзакцию добавить
            await _unit.CommitChanges();

            return Result.Success;
        }
    }
}