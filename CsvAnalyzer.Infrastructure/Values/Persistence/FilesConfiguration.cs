using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Domain.Value;
using CsvAnalyzer.Domain.Values.Entities;
using ErrorOr;
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

            builder.Property(fe => fe.Id)
                .ValueGeneratedOnAdd();

            builder.HasMany(fe => fe.FileValues)
                .WithOne(ve => ve.FileEntry)
                .HasForeignKey(ve => ve.FileEntryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}