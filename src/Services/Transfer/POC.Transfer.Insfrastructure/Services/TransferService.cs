using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.Core.Bus;
using POC.Transfer.Core.Interfaces;
using POC.Transfer.Core.Interfaces.Repositories;

namespace POC.Transfer.Infrastructure.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepo;
        private readonly IEventBus _eventBus;

        public TransferService(ITransferRepository transferRepo, IEventBus eventBus)
        {
            _transferRepo = transferRepo;
            _eventBus = eventBus;
        }
        public async Task<Core.Entities.Transfer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Core.Entities.Transfer>> GetAllAsync()
        {
            return await _transferRepo.GetAllAsync();
        }

        public async Task<IEnumerable<Core.Entities.Transfer>> GetAllBySenderAsync(int sender)
        {
            return await _transferRepo.GetAllBySenderAsync(sender);
        }

        public async Task<IEnumerable<Core.Entities.Transfer>> GetAllByRecipientAsync(int recipient)
        {
            return await _transferRepo.GetAllByRecipientAsync(recipient);
        }

        public async Task<Core.Entities.Transfer> SaveTransfer(int from, int to, decimal amt)
        {
            var transfer = new Core.Entities.Transfer(from, to, amt);
            await _transferRepo.SaveTransferAsync(transfer);
            return transfer;
        }
    }
}
