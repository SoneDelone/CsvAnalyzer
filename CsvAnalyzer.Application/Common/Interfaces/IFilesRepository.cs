using CsvAnalyzer.Domain.Value;
using ErrorOr;

namespace CsvAnalyzer.Application.Common.Interfaces
{
    public interface IFilesRepository
    {
        Task<ErrorOr<Success>> AddValue(FileEntry file);
        Task<ErrorOr<Success>> RemoveValue(Guid fileEntryId);
        Task<ErrorOr<Success>> UpdateValues(Domain.Values.Entities.ValuesEntry lines);
        Task<ErrorOr<Success>> ValueExists();
    }
}
