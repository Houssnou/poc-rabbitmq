using POC.Banking.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.Banking.Core.Commands;
using POC.Banking.Core.Entities;
using POC.Banking.Core.Interfaces.Repositories;
using POC.Core.Bus;

namespace POC.Banking.Infrastructure.Services
{
    public class AccountService: IAccountService
    {
        private readonly IAccountRepository _accountRepo;
        private readonly IEventBus _eventBus;

        public AccountService(IAccountRepository accountRepo, IEventBus eventBus)
        {
            _accountRepo = accountRepo;
            _eventBus = eventBus;
        }
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _accountRepo.GetAllAsync();
        }

        public async Task TransfertAsync(int from, int to, decimal amt)
        {
            var newTransfer = new NewTransferCommand(from, to, amt);

            await _eventBus.SendCommand(newTransfer);
        }
    }
}
