using CsvAnalyzer.Application.Common.FilesModel;
using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Application.Mapping;
using CsvAnalyzer.Domain.Value;
using CsvHelper;
using CsvHelper.Configuration;
using ErrorOr;
using System.Globalization;


namespace CsvAnalyzer.Application.Service
{
    public class CsvService(IFilesRepository _filesRepository,
                            ICsvValidator _csvValidator,
                            IUnitOfWork _unit)
    {
        public async Task<ErrorOr<List<CsvModel>?>> ProccessCsvAsync(Stream file)
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
                return Error.Unexpected(description: "CsvLines got null");

            return recordOrError.Value;
        }

        public async Task<ErrorOr<Success>> SaveFileAsync(string file, List<CsvModel> csvLines)
        {
            var fileEntry = FileEntry.Create(file);


            return Result.Success;
        }
    }
}