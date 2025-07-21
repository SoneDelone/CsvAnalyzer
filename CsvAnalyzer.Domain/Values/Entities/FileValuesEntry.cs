using CsvAnalyzer.Domain.Value;

namespace CsvAnalyzer.Domain.Values.Entities
{
    public class FileValuesEntry
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime Date { get; private set; }
        public double ExecutionTime { get; private set; }
        public double Value { get; private set; }

        public Guid FileEntryId { get; private set; }
        public FileEntry? FileEntry { get; private set; }

        public FileValuesEntry(Guid id,
                     DateTime date,
                     double executionTime,
                     double value)
        {
            Date = date;
            ExecutionTime = executionTime;
            Value = value;
            FileEntryId = id;
        }

        private FileValuesEntry() { }

        public override string ToString() => $"Date: {Date}, ExecutionTime: {ExecutionTime}, Value: {Value}";
    }
}
