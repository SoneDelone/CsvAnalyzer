namespace CsvAnalyzer.Application.Common.FilesModel
{
    public class ResultsDTO
    {
        public double TimeDeltaSeconds { get; set; }
        public DateTime MinDate { get; set; }
        public double AvgExecutionTime { get; set; }
        public double AvgValue { get; set; }
        public double MedianValue { get; set; }
        public double MaxValue { get; set; }
        public double MinValue { get; set; }
        public Guid FileEntryId { get; set; }
    }
}
