using CsvAnalyzer.Domain.Value;

namespace CsvAnalyzer.Domain.Values.Entities
{
    public class LinesEntry
    {
        public DateTime Date { get; private set; }
        public double ExecutionTime { get; private set; }
        public double Value { get; private set; }

        public Guid ValueEntryId { get; private set; }
        public FileEntry? ValueEntry { get; private set; }

        public LinesEntry(Guid id,
                     DateTime date,
                     double executionTime,
                     double value)
        {
            Date = date;
            ExecutionTime = executionTime;
            Value = value;
            ValueEntryId = id;
        }

        private LinesEntry() { }

        public override string ToString() => $"Date: {Date}, ExecutionTime: {ExecutionTime}, Value: {Value}";
    }
}
