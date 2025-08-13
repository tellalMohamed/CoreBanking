using CoreBanking.Domain.Repositories;
using CoreBanking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBanking.Application.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task AjouterClient(string nom, string prenom)
        {
            var customer = new Customer
            {
                LastName = nom,
                FirstName = prenom
            };

            await _clientRepository.AddAsync(customer);
        }

        public async Task<IEnumerable<Customer>> ObtenirTous()
        {
            return await _clientRepository.GetAllAsync();
        }
    }
}