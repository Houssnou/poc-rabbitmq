using POC.Banking.Core.Entities;

namespace POC.Banking.Core.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(int id);
        Task<IEnumerable<Account>> GetAllAsync();
    }
}
