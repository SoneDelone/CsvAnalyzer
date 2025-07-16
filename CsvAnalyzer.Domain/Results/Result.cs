namespace CsvAnalyzer.Domain.Result
{
    public class ResultEntry
    {
        public Guid Id { get; private set; }
        public string FileName { get; private set; }
        public double TimeDeltaSeconds { get; private set; }
        public DateTime MinDate { get; private set; }
        public double AvgExecutionTime { get; private set; }
        public double AvgValue { get; private set; }
        public double MedianValue { get; private set; }
        public double MaxValue { get; private set; }
        public double MinValue { get; private set; }

        public ResultEntry(Guid id,
                           string fileName,
                           DateTime date,
                           double executionTime,
                           double value)
        {
            Id = id;
            FileName = fileName;
            MinDate = date;
            TimeDeltaSeconds = executionTime;
            AvgValue = value;
            AvgExecutionTime = executionTime;
            MedianValue = value;
            MaxValue = value;
            MinValue = value;
        }

        private ResultEntry() { }

        public override string ToString() =>
            $"Id: {Id}, FileName: {FileName}, MinDate: {MinDate}, TimeDeltaSeconds: {TimeDeltaSeconds}, AvgValue: {AvgValue}";
    }
}
