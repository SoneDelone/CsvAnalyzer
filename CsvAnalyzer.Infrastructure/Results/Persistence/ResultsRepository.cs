using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Domain.Results;
using CsvAnalyzer.Infrastructure.Common.Persistence;

namespace CsvAnalyzer.Infrastructure.Results.Persistence
{
    public class ResultsRepository(CsvDbContext _db) : IResultsRepository
    {
        public async Task AddResultAsync(ResultEntry result)
        {
            await _db.ResultsEntries.AddAsync(result);
        }
        public Task GetAllResults()
        {
            return Task.CompletedTask;
        }
        public Task GetResultById(Guid id)
        {
            return Task.CompletedTask;
        }
    }
}
