using CsvAnalyzer.Domain.Values.Entities;

namespace CsvAnalyzer.Domain.Value
{
    public class FileEntry
    {
        public Guid Id { get; private set; }
        public string FileName { get; private set; }

        public IEnumerable<FileValuesEntry>? FileValues { get; private set; }

        private FileEntry(string fileName)
        {
            Id = Guid.NewGuid();
            FileName = fileName;
        }

        public static FileEntry Create(string fileName)
        {
            var FileEntry = new FileEntry(fileName);

            return FileEntry;
        }

        private FileEntry() { }

        public override string ToString() => $"Id: {Id}, FileName: {FileName}";
    }
}
