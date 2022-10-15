using POC.Banking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.Banking.Core.Interfaces.Repositories;

namespace POC.Banking.Infrastructure.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _context;

        public AccountRepository(BankingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return _context.Accounts;
        }

        public Task<Account> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
