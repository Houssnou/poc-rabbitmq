using POC.Banking.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.Banking.Core.Entities;
using POC.Banking.Core.Interfaces.Repositories;

namespace POC.Banking.Infrastructure.Services
{
    public class AccountService: IAccountService
    {
        private readonly IAccountRepository _accountRepo;

        public AccountService(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _accountRepo.GetAllAsync();
        }
    }
}
