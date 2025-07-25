﻿using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Domain.Results;
using CsvAnalyzer.Domain.Value;
using CsvAnalyzer.Domain.Values.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CsvAnalyzer.Infrastructure.Common.Persistence
{
    public class CsvDbContext : DbContext, IUnitOfWork
    {

        public DbSet<FileEntry> FileEntries { get; set; } = null!;
        public DbSet<FileValuesEntry> FileValuesEntries { get; set; } = null!;
        public DbSet<ResultEntry> ResultsEntries { get; set; } = null!;

        public CsvDbContext(DbContextOptions<CsvDbContext> options)
            : base(options)
        {
        }

        public async Task CommitChanges()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }

}
