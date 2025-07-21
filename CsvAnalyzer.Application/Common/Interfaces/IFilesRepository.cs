using CsvAnalyzer.Domain.Value;
using CsvAnalyzer.Domain.Values.Entities;

namespace CsvAnalyzer.Application.Common.Interfaces
{
    public interface IFilesRepository
    {
        Task SaveFileInfo(FileEntry file);
        Task SaveFileLines(List<FileValuesEntry> file);
        Task RemoveValue(Guid fileEntryId);
        Task UpdateValues(FileValuesEntry lines);
        Task ValueExists();
    }
}
