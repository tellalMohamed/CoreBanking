using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CoreBanking.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; } // PK
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        // Relation avec Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Transactions
        public ICollection<Transaction> Transactions { get; set; }
    }
}