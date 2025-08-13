using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBanking.Domain.ValueObjects
{
    public class AccountNumber
    {
        public string Value { get; }

        public AccountNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Numéro de compte invalide.");

            if (value.Length != 10)
                throw new ArgumentException("Le numéro de compte doit contenir 10 chiffres.");

            Value = value;
        }

        public override string ToString() => Value;
    }
}