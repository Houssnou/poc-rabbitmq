namespace POC.Transfer.Core.Interfaces;

public interface ITransferService
{
    Task<Entities.Transfer> GetByIdAsync(int id);
    Task<IEnumerable<Entities.Transfer>> GetAllAsync();
    Task<IEnumerable<Entities.Transfer>> GetAllBySenderAsync(int sender);
    Task<IEnumerable<Entities.Transfer>> GetAllByRecipientAsync(int recipient);
    Task<Core.Entities.Transfer> SaveTransfer(int from, int to, decimal amt);
}