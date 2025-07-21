using CsvAnalyzer.Domain.Results;

namespace CsvAnalyzer.Application.Common.Interfaces
{
    public interface IResultsRepository
    {
        Task AddResultAsync(ResultEntry result);

        Task GetAllResults();

        Task GetResultById(Guid id);
    }
}
