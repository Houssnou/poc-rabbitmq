using System.Security.Principal;

namespace POC.Transfer.Core.Interfaces.Repositories;

public interface ITransferRepository
{
    Task<Entities.Transfer> GetByIdAsync(int id);
    Task<IEnumerable<Entities.Transfer>> GetAllAsync();
    Task<IEnumerable<Entities.Transfer>> GetAllBySenderAsync(int sender);
    Task<IEnumerable<Entities.Transfer>> GetAllByRecipientAsync(int recipient);
    Task<Entities.Transfer> SaveTransferAsync(Entities.Transfer transfer);
}