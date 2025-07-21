using CsvAnalyzer.Domain.Value;
using CsvAnalyzer.Domain.Values.Entities;

namespace CsvAnalyzer.Application.Common.Interfaces
{
    public interface IFilesRepository
    {
        Task SaveFileInfoAsync(FileEntry file);
        Task SaveFileLinesAsync(List<FileValuesEntry> file);
        Task RemoveValuesAsync(Guid fileEntryId);
        Task<FileEntry?> GetByIdAsync(Guid id);
        Task<FileEntry?> GetByNameAsync(string name);
        Task<bool> ExistsByIdAsync(Guid id);
        Task<bool> ExistsByNameAsync(string name);
    }
}
