using CsvAnalyzer.Application.Common.FilesModel;
using CsvHelper;
using ErrorOr;

namespace CsvAnalyzer.Application.Common.Interfaces
{
    public interface ICsvValidator
    {
        public Task<ErrorOr<List<CsvModel>?>> CsvValidateAsync(CsvReader reader);
    }
}
