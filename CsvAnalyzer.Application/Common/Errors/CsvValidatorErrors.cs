using ErrorOr;

namespace CsvAnalyzer.Application.Common.Errors;

public class CsvValidatorErrors
{
    public static Error InvalidFileFormat => Error.Validation(
        code: "CsvValidator.InvalidFileFormat",
        description: "The provided file is not a valid CSV format.");

    public static Error NullReader => Error.Validation(
    code: "CsvValidator.NullReader",
    description: "Reader cannot be null.");

    public static Error NullDate => Error.Validation(
        code: "CsvValidator.NullDate",
        description: "Record has null Date.");

    public static Error NullExecutionTime => Error.Validation(
        code: "CsvValidator.NullExecutionTime",
        description: "Record has null ExecutionTime.");

    public static Error NullValue => Error.Validation(
        code: "CsvValidator.NullValue",
        description: "Record has null Value.");

    public static Error DateInFuture => Error.Validation(
        code: "CsvValidator.DateInFuture",
        description: "Date cannot be more than now.");

    public static Error OldDate => Error.Validation(
        code: "CsvValidator.OldDate",
        description: "Date cannot be smaller than min.");

    public static Error NegativeExecutionTime => Error.Validation(
        code: "CsvValidator.NegativeExecutionTime",
        description: "ExecutionTime cannot be smaller than 0.");

    public static Error NegativeValue => Error.Validation(
        code: "CsvValidator.NegativeValue",
        description: "Value cannot be smaller than 0.");

    public static Error CountOutOfRange => Error.Validation(
        code: "CsvValidator.CountOutOfRange",
        description: "Count cannot be more than 10000 or 0.");

    public static Error ReaderException => Error.Validation(
        code: "CsvHelper.ReaderException",
        description: "Error reading record.");

    public static Error HeaderValidationException => Error.Validation(
        code: "CsvHelper.HeaderValidationException",
        description: "Error reading header.");

    public static Error TypeConverterException => Error.Validation(
        code: "CsvHelper.TypeConverterException",
        description: "Error during type conversion.");
}
