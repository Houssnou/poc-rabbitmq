using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Transfer.Core.Entities
{
    public class Transfer : BaseEntity
    {
        public int From { get; set; }
        public int To { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

        public Transfer(int from, int to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}
