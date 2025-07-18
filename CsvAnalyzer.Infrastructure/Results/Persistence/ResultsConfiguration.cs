using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Domain.Result;
using CsvAnalyzer.Domain.Value;
using CsvAnalyzer.Domain.Values.Entities;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CsvAnalyzer.Infrastructure.Results.Persistence
{
    public class ResultsConfiguration : IEntityTypeConfiguration<ResultEntry>
    {
        public void Configure(EntityTypeBuilder<ResultEntry> builder)
        {
            builder.ToTable("results")
                .HasKey(re => re.Id);
        }
    }
}
