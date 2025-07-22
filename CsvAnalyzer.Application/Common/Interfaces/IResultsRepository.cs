using CsvAnalyzer.Application.Common.FilesModel;
using CsvAnalyzer.Domain.Results;

namespace CsvAnalyzer.Application.Common.Interfaces
{
    public interface IResultsRepository
    {
        Task AddResultAsync(ResultEntry result);

        Task<List<ResultEntry>> GetAllResultsAsQueryable(CsvFilterParams filter, Guid? id = null);

        Task<List<ResultEntry>> GetLastResultById(Guid id);
    }
}
