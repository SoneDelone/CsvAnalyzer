using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Domain.Value;
using CsvAnalyzer.Domain.Values.Entities;
using ErrorOr;

namespace CsvAnalyzer.Infrastructure.Values.Persistence
{
    public class FilesRepository : IFilesRepository
    {
        public Task<ErrorOr<Success>> AddValue(Domain.Value.ValuesEntry file)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorOr<Success>> RemoveValue(Guid fileEntryId)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorOr<Success>> UpdateValues(Domain.Values.Entities.ValuesEntry lines)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorOr<Success>> ValueExists()
        {
            throw new NotImplementedException();
        }
    }
}
