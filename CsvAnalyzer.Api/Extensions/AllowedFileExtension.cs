using CsvAnalyzer.Api.Enums;
using ErrorOr;

namespace CsvAnalyzer.Api.Extensions
{
    public static class AllowedFileExtension
    {
        public static ErrorOr<string> GetExtensions(this FileExtensions ext)
        {
            return ext switch
            {
                FileExtensions.Csv => ".csv",
                FileExtensions.Txt => ".txt",
                _ => Error.Validation(description: $"Extension {ext} not supported")
            };
        }

        public static bool IsAllowedExtension(this string extension)
        {
            return Enum.GetValues<FileExtensions>()
                       .Select(e => e.GetExtensions())
                       .Contains(extension.ToLower());
        }
    }
}
