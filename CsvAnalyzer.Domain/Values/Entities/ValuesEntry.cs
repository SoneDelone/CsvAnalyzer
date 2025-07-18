using CsvAnalyzer.Domain.Value;

namespace CsvAnalyzer.Domain.Values.Entities
{
    public class ValuesEntry
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public double ExecutionTime { get; private set; }
        public double Value { get; private set; }

        public Guid FileEntryId { get; private set; }
        public FileEntry? FileEntry { get; private set; }

        public ValuesEntry(Guid id,
                     DateTime date,
                     double executionTime,
                     double value)
        {
            Date = date;
            ExecutionTime = executionTime;
            Value = value;
            FileEntryId = id;
        }

        private ValuesEntry() { }

        public override string ToString() => $"Date: {Date}, ExecutionTime: {ExecutionTime}, Value: {Value}";
    }
}
