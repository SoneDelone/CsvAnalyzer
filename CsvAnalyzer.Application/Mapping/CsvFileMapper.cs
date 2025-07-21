using CsvAnalyzer.Application.Common.FilesModel;
using CsvHelper.Configuration;
using System.Globalization;

namespace CsvAnalyzer.Application.Mapping
{
    public class CsvFileMapper : ClassMap<CsvModel>
    {
        public CsvFileMapper()
        {
            Map(m => m.Date).Name("date")
                .TypeConverterOption
                .DateTimeStyles(DateTimeStyles.AllowInnerWhite | DateTimeStyles.RoundtripKind);
            Map(m => m.ExecutionTime).Name("executiontime");
            Map(m => m.Value).Name("value");
        }
    }
}
