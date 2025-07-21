using CsvAnalyzer.Domain.Results;
using CsvAnalyzer.Domain.Value;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CsvAnalyzer.Infrastructure.Values.Persistence
{
    public class FilesConfiguration : IEntityTypeConfiguration<FileEntry>
    {
        public void Configure(EntityTypeBuilder<FileEntry> builder)
        {
            builder.ToTable("files")
                .HasKey(fe => fe.Id);

            builder.HasMany(fe => fe.FileValues)
                .WithOne(ve => ve.FileEntry)
                .HasForeignKey(ve => ve.FileEntryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(fe => fe.ResultEntries)
                .WithOne(re => re.FileEntry)
                .HasForeignKey(re => re.FileEntryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}