using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CoreBanking.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }  // PK
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }

        // Navigation
        public ICollection<Account>? Accounts { get; set; }
    }
}