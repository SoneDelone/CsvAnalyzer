using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Domain.Value;
using CsvAnalyzer.Domain.Values.Entities;
using CsvAnalyzer.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CsvAnalyzer.Infrastructure.Values.Persistence
{
    public class FilesRepository(CsvDbContext _db) : IFilesRepository
    {
        public async Task SaveFileInfoAsync(FileEntry file)
        {
            await _db.FileEntries.AddAsync(file);
        }

        public async Task SaveFileLinesAsync(List<FileValuesEntry> file)
        {
            await _db.FileValuesEntries.AddRangeAsync(file);
        }

        public async Task<FileEntry?> GetByIdAsync(Guid id)
        {
            return await _db.FileEntries
                .Include(l => l.FileValues)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<FileEntry?> GetByNameAsync(string name)
        {
            return await _db.FileEntries
                .Include(l => l.FileValues)
                .FirstOrDefaultAsync(x => x.FileName == name);
        }
        public async Task RemoveValuesAsync(Guid fileEntryId)
        {
            await _db.FileValuesEntries
                .Where(x => x.FileEntryId == fileEntryId)
                .ExecuteDeleteAsync();
        }
        public async Task<bool> ExistsByIdAsync(Guid id) => await _db.FileEntries.AsNoTracking().AnyAsync(x => x.Id == id);
        public async Task<bool> ExistsByNameAsync(string name) => await _db.FileEntries.AsNoTracking().AnyAsync(x => x.FileName == name);

    }
}
