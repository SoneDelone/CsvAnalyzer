using CsvAnalyzer.Domain.Result;
using ErrorOr;

namespace CsvAnalyzer.Application.Common.Interfaces
{
    public interface IResultsRepository
    {
        Task<ErrorOr<Success>> AddResult(ResultEntry result);

        Task<ErrorOr<List<ResultEntry>>> GetAllResults();

        Task<ErrorOr<ResultEntry>> GetResultById(Guid id);
    }
}
