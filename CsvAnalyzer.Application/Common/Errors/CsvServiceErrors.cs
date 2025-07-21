using ErrorOr;

namespace CsvAnalyzer.Application.Common.Errors
{
    public class CsvServiceErrors
    {
        public static Error CsvLinesNullValue => Error.Unexpected(
            code: "CsvService.NullLines",
            description: "CsvLines got null.");
    }
}
