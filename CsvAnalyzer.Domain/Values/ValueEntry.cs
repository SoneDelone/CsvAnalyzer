using CsvAnalyzer.Domain.Values.Entities;

namespace CsvAnalyzer.Domain.Value
{
    public class ValueEntry
    {
        public Guid Id { get; private set; }
        public string FileName { get; private set; }

        public IEnumerable<Lines>? Lines { get; private set; }

        public ValueEntry(Guid id,
                     string fileName,
                     List<Lines> lines)
        {
            Id = id;
            FileName = fileName;
            Lines = lines ?? new();
        }

        private ValueEntry() { }

        public override string ToString() => $"Id: {Id}, FileName: {FileName}";
    }
}
