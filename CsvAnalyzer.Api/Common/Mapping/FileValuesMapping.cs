using CsvAnalyzer.Application.Common.FilesModel;
using CsvAnalyzer.Domain.Values.Entities;
using Mapster;

namespace CsvAnalyzer.Api.Common.Mapping
{
    public class FileValuesMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CsvModel, FileValuesEntry>()
                .Map(src => src.Date, m => m.Date)
                .Map(src => src.ExecutionTime, m => m.ExecutionTime)
                .Map(src => src.Value, m => m.Value);
        }
    }
}
