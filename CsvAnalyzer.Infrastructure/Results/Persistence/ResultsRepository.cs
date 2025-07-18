using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Domain.Result;
using CsvAnalyzer.Infrastructure.Common.Persistence;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace CsvAnalyzer.Infrastructure.Results.Persistence
{
    public class ResultsRepository : IResultsRepository
    {
        private readonly CsvDbContext _context;
        public ResultsRepository(CsvDbContext context)
        {
            _context = context;
        }
        public async Task<ErrorOr<Success>> AddResult(ResultEntry result)
        {
            _context.ResultsEntries.Add(result);
            await _context.SaveChangesAsync();
            return Result.Success;
        }
        public async Task<ErrorOr<List<ResultEntry>>> GetAllResults()
        {
            var results = await _context.ResultsEntries.ToListAsync();
            return results;
        }
        public async Task<ErrorOr<ResultEntry>> GetResultById(Guid id)
        {
            var result = await _context.ResultsEntries.FindAsync(id);

            if (result is null)
            {
                return Error.NotFound();
            }
            return result;
        }
    }
}
