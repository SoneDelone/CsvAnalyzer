using CsvAnalyzer.Application.Common.FilesModel;
using CsvAnalyzer.Domain.Results;
using Mapster;

namespace CsvAnalyzer.Api.Common.Mapping
{
    public class ResultsMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ResultsDTO, ResultEntry>()
                .Map(dest => dest.TimeDeltaSeconds, src => src.TimeDeltaSeconds)
                .Map(dest => dest.MinDate, src => src.MinDate)
                .Map(dest => dest.AvgExecutionTime, src => src.AvgExecutionTime)
                .Map(dest => dest.AvgValue, src => src.AvgValue)
                .Map(dest => dest.MedianValue, src => src.MedianValue)
                .Map(dest => dest.MaxValue, src => src.MaxValue)
                .Map(dest => dest.MinValue, src => src.MinValue)
                .Map(dest => dest.FileEntryId, src => src.FileEntryId);
        }
    }
}
