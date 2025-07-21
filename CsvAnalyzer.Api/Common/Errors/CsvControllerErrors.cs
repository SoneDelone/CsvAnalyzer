using ErrorOr;

namespace CsvAnalyzer.Api.Common.Errors
{
    public class CsvControllerErrors
    {
        public static Error FileIsEmptyOrMissing => Error.Validation(
            code: "CsvUploader.FileIsEmptyOrMissing",
            description: "File is empty or not provided.");

        public static Error FileExtensionNotAllowed => Error.Validation(
            code: "CsvUploader.FileExtensionNotAllowed",
            description: "The file type is not allowed. Only .csv files are supported.");
    }
}
