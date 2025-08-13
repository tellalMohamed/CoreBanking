using CoreBanking.Domain.ValueObjects;
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
        public int Id { get; private set; }
        public AccountNumber AccountNumber { get; private set; }
        public Money Balance { get; private set; } = Money.Zero;

        public int CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        private readonly List<Transaction> _transactions = new();
        public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();

        protected Account() { } // Pour EF Core

        public Account(AccountNumber accountNumber, int customerId)
        {
            AccountNumber = accountNumber ?? throw new ArgumentNullException(nameof(accountNumber));
            CustomerId = customerId;
        }

        public void Retirer(Money montant)
        {
            if (Balance.IsLessThan(montant))
                throw new InvalidOperationException("Solde insuffisant.");

            Balance = Balance.Subtract(montant);
            _transactions.Add(Transaction.CreateWithdrawal(Id, montant));
        }

        public void Deposer(Money montant)
        {
            Balance = Balance.Add(montant);
            _transactions.Add(Transaction.CreateDeposit(Id, montant));
        }
    }
}