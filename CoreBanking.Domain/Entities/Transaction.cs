using CoreBanking.Domain.ValueObjects;
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
        public Money Amount { get; set; }
        public char Type { get; set; } // "Deposit" ou "Withdrawal"

        // Relation avec Account
        public int AccountId { get; set; }
        public Account Account { get; set; }

        private Transaction(int accountId, Money amount, char type)
        {
            AccountId = accountId;
            Amount = amount;
            Type = type;
            Date = DateTime.UtcNow;
        }

        public static Transaction CreateWithdrawal(int AccountId, Money montant)
        {
            return new Transaction(AccountId, montant, 'C');
        }

        public static Transaction CreateDeposit(int AccountId, Money montant)
        {
            return new Transaction(AccountId, montant, 'D');
        }
    }
}