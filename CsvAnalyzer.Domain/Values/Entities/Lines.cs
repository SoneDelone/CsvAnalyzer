using CsvAnalyzer.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAnalyzer.Domain.Values.Entities
{
    public class Lines
    {
        public DateTime Date { get; private set; }
        public double ExecutionTime { get; private set; }
        public double Value { get; private set; }

        public Guid ValueEntryId { get; private set; }
        public ValueEntry? ValueEntry { get; private set; }

        public Lines(Guid id,
                     DateTime date,
                     double executionTime,
                     double value)
        {
            Date = date;
            ExecutionTime = executionTime;
            Value = value;
            ValueEntryId = id;
        }
        
        private Lines() { }

        public override string ToString() => $"Date: {Date}, ExecutionTime: {ExecutionTime}, Value: {Value}";
    }
}
