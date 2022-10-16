using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json;
using POC.Banking.Core.Entities;

namespace POC.Banking.Infrastructure.Data;

public class BankingDbContextSeed
{
    public static async Task SeedAsync(BankingDbContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //if (!context.Accounts.Any())
            //{
                var data = File.ReadAllText(path + @"/Data/SeedData/accounts.json");

                var accounts = JsonSerializer.Deserialize<List<Account>>(data);

                //ef core sql server doesn't allow id field in seed data.
                //exception: Cannot insert explicit value for identity column in table '' when IDENTITY_INSERT is set to OFF.
                //it's too risky to remove the PK constraint from the column so i introduced the IDless seed data. see _old_****.json

                foreach (var item in accounts)
                {
                    context.Accounts.Add(item);
                }

                await context.SaveChangesAsync();

          //  }

            
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<BankingDbContextSeed>();
            logger.LogError(ex.Message);
        }
    }
}