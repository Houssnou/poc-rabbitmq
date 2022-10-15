using Microsoft.EntityFrameworkCore;
using POC.Banking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Banking.Infrastructure.Data
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
