using CsvAnalyzer.Domain.Result;
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
