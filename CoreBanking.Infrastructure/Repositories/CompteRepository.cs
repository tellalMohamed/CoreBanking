using CoreBanking.Domain.Entities;
using CoreBanking.Domain.Repositories;
using CoreBanking.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CoreBanking.Infrastructure.Repositories
{
    public class CompteRepository : GenericRepository<Account>, ICompteRepository
    {
        public CompteRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Account> GetCompteByNumeroAsync(AccountNumber numero)
        {
            return await _context.Accounts.FirstOrDefaultAsync(c => c.AccountNumber == numero);
        }
    }
}
