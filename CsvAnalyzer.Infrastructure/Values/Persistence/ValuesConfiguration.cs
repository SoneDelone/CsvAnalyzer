using CsvAnalyzer.Domain.Values.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CsvAnalyzer.Infrastructure.Values.Persistence
{
    public class ValuesConfiguration : IEntityTypeConfiguration<ValuesEntry>
    {
        public void Configure(EntityTypeBuilder<ValuesEntry> builder)
        {
            builder.ToTable("values")
                .HasKey(fe => fe.Id);

            builder.Property(fe => fe.Id)
                .ValueGeneratedOnAdd();
        }
    }
}