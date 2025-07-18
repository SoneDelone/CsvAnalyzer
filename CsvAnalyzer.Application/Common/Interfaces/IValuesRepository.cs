using CsvAnalyzer.Domain.Value;
using CsvAnalyzer.Domain.Values.Entities;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAnalyzer.Application.Common.Interfaces
{
    public interface IValuesRepository
    {
        Task<ErrorOr<Success>> AddValue(FileEntry file);
        Task<ErrorOr<Success>> RemoveValue(Guid fileEntryId);
        Task<ErrorOr<Success>> UpdateValues(LinesEntry lines);
        Task<ErrorOr<Success>> ValueExists();
    }
}
