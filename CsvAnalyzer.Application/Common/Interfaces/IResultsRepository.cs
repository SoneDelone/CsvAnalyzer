using CsvAnalyzer.Domain.Result;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAnalyzer.Application.Common.Interfaces
{
    public interface IResultsRepository
    {
        Task<ErrorOr<Success>> AddResult(ResultEntry result);

        Task<ErrorOr<List<ResultEntry>>> GetAllResults();

        Task<ErrorOr<ResultEntry>> GetResultById(Guid id);
    }
}
