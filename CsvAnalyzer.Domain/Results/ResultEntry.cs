using CsvAnalyzer.Domain.Value;

namespace CsvAnalyzer.Domain.Results
{
    public class ResultEntry
    {
        public Guid Id { get; private set; }
        public double TimeDeltaSeconds { get; private set; }
        public DateTime MinDate { get; private set; }
        public double AvgExecutionTime { get; private set; }
        public double AvgValue { get; private set; }
        public double MedianValue { get; private set; }
        public double MaxValue { get; private set; }
        public double MinValue { get; private set; }
        public Guid FileEntryId { get; private set; }
        public FileEntry? FileEntry { get; private set; }

        private ResultEntry(double timeDeltaSeconds,
                            DateTime date,
                            double avgExec,
                            double avgValue,
                            double medianValue,
                            double maxValue,
                            double minValue,
                            Guid fileEntryId)
        {
            Id = Guid.NewGuid();
            TimeDeltaSeconds = timeDeltaSeconds;
            MinDate = date;
            AvgExecutionTime = avgExec;
            AvgValue = avgValue;
            MedianValue = medianValue;
            MaxValue = maxValue;
            MinValue = minValue;
            FileEntryId = fileEntryId;
        }

        public static ResultEntry Create(double timeDeltaSeconds, DateTime date, double avgExec, double avgValue,
                                         double medianValue, double maxValue, double minValue, Guid fileEntryId)
        {
            return new ResultEntry(timeDeltaSeconds, date, avgExec, avgValue, medianValue, maxValue, minValue, fileEntryId);
        }

        private ResultEntry() { }

    }
}
