using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBanking.Domain.Entities;
using CoreBanking.Domain.ValueObjects;

namespace CoreBanking.Domain.Repositories
{
    public interface IClientRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetClientByEmailAsync(string email);
    }
}