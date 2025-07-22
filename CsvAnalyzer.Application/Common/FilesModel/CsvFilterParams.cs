namespace CsvAnalyzer.Application.Common.FilesModel
{
    public class CsvFilterParams
    {
        public string? FileName { get; set; }
        public DateTime? MinStartTime { get; set; }
        public DateTime? MaxStartTime { get; set; }
        public double? MinAverageValue { get; set; }
        public double? MaxAverageValue { get; set; }
        public double? MinAverageExecutionTime { get; set; }
        public double? MaxAverageExecutionTime { get; set; }
    }
}
