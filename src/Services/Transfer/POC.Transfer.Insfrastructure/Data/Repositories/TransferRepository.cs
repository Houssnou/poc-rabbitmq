using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.Transfer.Core.Interfaces.Repositories;

namespace POC.Transfer.Infrastructure.Data.Repositories
{
    public class TransferRepository: ITransferRepository
    {
        private readonly TransferDbContext _context;

        public TransferRepository(TransferDbContext context)
        {
            _context = context;
        }
        public async Task<Core.Entities.Transfer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Core.Entities.Transfer>> GetAllAsync()
        {
            return _context.Transfers;
        }

        public async Task<IEnumerable<Core.Entities.Transfer>> GetAllBySenderAsync(int sender)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Core.Entities.Transfer>> GetAllByRecipientAsync(int recipient)
        {
            throw new NotImplementedException();
        }

        public async Task<Core.Entities.Transfer> SaveTransferAsync(Core.Entities.Transfer transfer)
        {
             await _context.Transfers.AddAsync(transfer);

             await _context.SaveChangesAsync();
             return transfer;

        }
    }
}
