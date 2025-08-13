using CoreBanking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBanking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CoreBanking.Domain.ValueObjects;

namespace CoreBanking.Infrastructure.Repositories
{
    public class ClientRepository : GenericRepository<Customer>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Customer> GetClientByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}