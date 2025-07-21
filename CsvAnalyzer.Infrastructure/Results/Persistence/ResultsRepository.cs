using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Domain.Results;
using CsvAnalyzer.Infrastructure.Common.Persistence;

namespace CsvAnalyzer.Infrastructure.Results.Persistence
{
    public class ResultsRepository(CsvDbContext _db) : IResultsRepository
    {
        public Task AddResult(ResultEntry result)
        {
            return Task.CompletedTask;
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
