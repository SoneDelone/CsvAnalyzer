namespace CsvAnalyzer.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitChanges();
    }
}
