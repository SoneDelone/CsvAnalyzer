using CsvAnalyzer.Domain.Value;

namespace CsvAnalyzer.Domain.Values.Entities
{
    public class FileValuesEntry
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public double ExecutionTime { get; private set; }
        public double Value { get; private set; }

        public Guid FileEntryId { get; private set; }
        public FileEntry? FileEntry { get; private set; }

        private FileValuesEntry(DateTime date,
                                double executionTime,
                                double value,
                                Guid fileEntryId)
        {
            Id = Guid.NewGuid();
            Date = date;
            ExecutionTime = executionTime;
            Value = value;
            FileEntryId = fileEntryId;
        }

        public static FileValuesEntry Create(DateTime date,
                                             double executionTime,
                                             double value,
                                             Guid fileEntryId)
        {
            var fileValuesEntry = new FileValuesEntry(date, executionTime, value, fileEntryId);
            return fileValuesEntry;
        }

        private FileValuesEntry() { }

        public override string ToString() => $"Date: {Date}, ExecutionTime: {ExecutionTime}, Value: {Value}";
    }
}
