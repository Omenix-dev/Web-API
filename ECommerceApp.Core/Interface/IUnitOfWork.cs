namespace ECommerceApp.Core.Interface
{
    public interface IUnitOfWork
    {
        Task CreateTransaction();
        Task Commit();
        Task Rollback();
        Task Save();
    }
}
