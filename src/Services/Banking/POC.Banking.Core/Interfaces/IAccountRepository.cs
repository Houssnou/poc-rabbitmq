using POC.Banking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Banking.Core.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(int id);
        Task<IEnumerable<Account>> GetAllAsync();
    }
}
