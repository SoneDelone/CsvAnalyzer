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
    public interface IFilesRepository
    {
        Task<ErrorOr<Success>> AddValue(FilesEntry file);
        Task<ErrorOr<Success>> RemoveValue(Guid fileEntryId);
        Task<ErrorOr<Success>> UpdateValues(Domain.Values.Entities.ValuesEntry lines);
        Task<ErrorOr<Success>> ValueExists();
    }
}
