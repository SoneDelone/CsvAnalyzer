using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Domain.Value;
using CsvAnalyzer.Domain.Values.Entities;
using CsvAnalyzer.Infrastructure.Common.Persistence;

namespace CsvAnalyzer.Infrastructure.Values.Persistence
{
    public class FilesRepository(CsvDbContext _db) : IFilesRepository
    {
        public Task SaveFileInfo(FileEntry file)
        {
            _db.FileEntries.Add(file);
            return Task.CompletedTask;
        }

        public Task SaveFileLines(List<FileValuesEntry> file)
        {
            _db.FileValuesEntries.AddRange(file);
            return Task.CompletedTask;
        }

        public Task RemoveValue(Guid fileEntryId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateValues(FileValuesEntry lines)
        {
            throw new NotImplementedException();
        }

        public Task ValueExists()
        {
            throw new NotImplementedException();
        }
    }
}
