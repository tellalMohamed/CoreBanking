using CoreBanking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBanking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreBanking.Infrastructure.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Transaction>> GetTransactionsByCompteIdAsync(int compteId)
        {
            return await _context.Transactions
                .Where(t => t.AccountId == compteId)
                .ToListAsync();
        }
    }
}