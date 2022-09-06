namespace ECommerceApp.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CreateTransaction();
        Task Commit();
        Task Rollback();
        Task Save();
    }
}
