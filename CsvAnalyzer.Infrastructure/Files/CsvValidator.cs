using CsvAnalyzer.Application.Common.FilesModel;
using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Infrastructure.Common.Errors;
using CsvHelper;
using CsvHelper.TypeConversion;
using ErrorOr;

namespace CsvAnalyzer.Infrastructure.Files
{
    public class CsvValidator : ICsvValidator
    {
        public async Task<ErrorOr<List<CsvModel>?>> CsvValidateAsync(CsvReader csvReader)
        {
            List<CsvModel> csvLines = new();

            var dateNow = DateTime.UtcNow;
            var minDate = new DateTime(2000, 1, 1);

            if (csvReader is null)
                return CsvValidatorErrors.NullReader;

            csvReader.Read();
            csvReader.ReadHeader();

            while (csvReader.Read())
            {
                try
                {
                    var record = csvReader.GetRecord<CsvModel>();

                    if (!record.Date.HasValue)
                        return CsvValidatorErrors.NullDate;

                    if (!record.ExecutionTime.HasValue)
                        return CsvValidatorErrors.NullExecutionTime;

                    if (!record.Value.HasValue)
                        return CsvValidatorErrors.NullValue;

                    if (record.Date > dateNow)
                        return CsvValidatorErrors.DateInFuture;

                    if (record.Date < minDate)
                        return CsvValidatorErrors.OldDate;

                    if (record.ExecutionTime < 0)
                        return CsvValidatorErrors.NegativeExecutionTime;

                    if (record.Value < 0)
                        return CsvValidatorErrors.NegativeValue;

                    csvLines.Add(record);
                }
                catch (ReaderException ex) { return CsvValidatorErrors.ReaderException; }
                catch (HeaderValidationException ex) { return CsvValidatorErrors.HeaderValidationException; }
                catch (TypeConverterException ex) { return CsvValidatorErrors.TypeConverterException; }
            }

            var count = csvLines.Count;
            if (count >= 1 && count <= 10000)
                return csvLines;

            return CsvValidatorErrors.CountOutOfRange;

        }
    }
}
