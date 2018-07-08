
namespace DataManager.Context.Contracts
{
    public interface IMyDbContextFactory
    {
        IMyDbContext CreateMyDbContext();
    }
}
