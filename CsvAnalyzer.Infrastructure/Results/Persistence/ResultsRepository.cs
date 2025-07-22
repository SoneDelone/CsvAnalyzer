using CsvAnalyzer.Application.Common.FilesModel;
using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Domain.Results;
using CsvAnalyzer.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CsvAnalyzer.Infrastructure.Results.Persistence
{
    public class ResultsRepository(CsvDbContext _db) : IResultsRepository
    {
        public async Task AddResultAsync(ResultEntry result)
        {
            await _db.ResultsEntries.AddAsync(result);
        }
        public async Task<List<ResultEntry>> GetAllResultsAsQueryable(CsvFilterParams filter, Guid? id = null)
        {
            var queryable = _db.ResultsEntries.AsNoTracking().AsQueryable();

            if (id is not null)
                queryable = queryable.Where(f => f.FileEntryId == id);

            if (filter.MinStartTime.HasValue)
                queryable = queryable.Where(v => v.MinDate >= filter.MinStartTime.Value.ToUniversalTime());

            if (filter.MaxStartTime.HasValue)
                queryable = queryable.Where(v => v.MinDate <= filter.MaxStartTime.Value.ToUniversalTime());

            if (filter.MinAverageValue.HasValue)
                queryable = queryable.Where(f => f.MinValue >= filter.MinAverageValue.Value);

            if (filter.MaxAverageValue.HasValue)
                queryable = queryable.Where(f => f.MaxValue <= filter.MaxAverageValue.Value);

            if (filter.MinAverageExecutionTime.HasValue)
                queryable = queryable.Where(f => f.AvgExecutionTime >= filter.MinAverageExecutionTime.Value);

            if (filter.MaxAverageExecutionTime.HasValue)
                queryable = queryable.Where(f => f.AvgExecutionTime <= filter.MaxAverageExecutionTime.Value);

            return await queryable.ToListAsync();
        }
        public async Task<List<ResultEntry>> GetLastResultById(Guid id)
        {
            return _db.ResultsEntries.AsNoTracking().Where( f => f.FileEntryId == id).Take(10).ToList();
        }
    }
}
