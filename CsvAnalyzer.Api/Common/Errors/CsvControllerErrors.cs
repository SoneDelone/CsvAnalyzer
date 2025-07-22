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
        public static Error FileMissingName => Error.Validation(
                code: "FileName.MissingName",
                description: "File name is missing (e.g. only extension provided).");

        public static Error InvalidCharacters => Error.Validation(
                code: "FileName.InvalidChars",
                description: "File name contains invalid characters.");
    }
}
