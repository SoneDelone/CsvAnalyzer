using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Domain.Value;
using CsvAnalyzer.Domain.Values.Entities;
using ErrorOr;

namespace CsvAnalyzer.Infrastructure.Values.Persistence
{
    public class ValuesRepository : IValuesRepository
    {
        public Task<ErrorOr<Success>> AddValue(FileEntry file)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorOr<Success>> RemoveValue(Guid fileEntryId)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorOr<Success>> UpdateValues(LinesEntry lines)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorOr<Success>> ValueExists()
        {
            throw new NotImplementedException();
        }
    }
}
