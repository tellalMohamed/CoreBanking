using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBanking.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; } // PK
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // "Deposit" ou "Withdrawal"

        // Relation avec Account
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}