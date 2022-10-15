using POC.Banking.Core.Entities;
using POC.Banking.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Banking.Infrastructure.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository(BankingDbContext context)
        {
        }

        public Task<IEnumerable<Account>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
