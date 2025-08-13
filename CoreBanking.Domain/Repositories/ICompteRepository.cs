using CoreBanking.Domain.Entities;
using CoreBanking.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CoreBanking.Domain.Repositories
{
    public interface ICompteRepository : IGenericRepository<Account>
    {
        Task<Account> GetCompteByNumeroAsync(AccountNumber numero);
    }
}