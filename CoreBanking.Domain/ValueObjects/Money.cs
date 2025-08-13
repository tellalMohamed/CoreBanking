using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBanking.Domain.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; }
        public static Money Zero => new Money(0);

        public Money(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Le montant ne peut pas être négatif.");
            Amount = amount;
        }

        public bool IsLessThan(Money other) => Amount < other.Amount;
        public Money Add(Money other) => new Money(Amount + other.Amount);
        public Money Subtract(Money other) => new Money(Amount - other.Amount);
    }
}