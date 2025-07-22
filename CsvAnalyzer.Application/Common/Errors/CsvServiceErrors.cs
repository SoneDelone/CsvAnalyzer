using ErrorOr;

namespace CsvAnalyzer.Application.Common.Errors
{
    public class CsvServiceErrors
    {
        public static Error CsvLinesNullValue => Error.Unexpected(
            code: "CsvService.NullLines",
            description: "CsvLines got null.");

        public static Error FileNotFound => Error.Unexpected(
            code: "CsvService.FileNotFound",
            description: "Provided name does not exist."); 
        public static Error FileNameIsEmpty => Error.Unexpected(
            code: "CsvService.FileNameIsEmpt",
            description: "Provide not empty name.");
    }
}
