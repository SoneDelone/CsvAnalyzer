using CsvAnalyzer.Domain.Values.Entities;

namespace CsvAnalyzer.Domain.Value
{
    public class FileEntry
    {
        public Guid Id { get; private set; }
        public string FileName { get; private set; }

        public IEnumerable<ValuesEntry>? FileValues { get; private set; }

        public FileEntry(Guid id,
                     string fileName,
                     List<ValuesEntry> lines)
        {
            Id = id;
            FileName = fileName;
            FileValues = lines ?? new();
        }

        private FileEntry() { }

        public override string ToString() => $"Id: {Id}, FileName: {FileName}";
    }
}
