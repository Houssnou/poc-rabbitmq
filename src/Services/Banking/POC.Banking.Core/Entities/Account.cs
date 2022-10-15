using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Banking.Core.Entities
{
    public class Account:BaseEntity
    {
        public string Type { get; set; }
        public decimal Balance { get; set; }
    }
}
