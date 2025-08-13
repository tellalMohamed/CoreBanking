using CoreBanking.Domain.Entities;
using CoreBanking.Domain.Repositories;
using CoreBanking.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBanking.Application.Services
{
    public class CompteService
    {
        private readonly ICompteRepository  _compteRepository;

        public CompteService(ICompteRepository compteRepository)
        {
            _compteRepository = compteRepository ?? throw new ArgumentNullException(nameof(compteRepository));
        }

        public async Task CreerCompteAsync(AccountNumber accountNumber, int customerId)
        {
            if (accountNumber == null)
                throw new ArgumentNullException(nameof(accountNumber));

            var account = new Account(accountNumber, customerId);
            await _compteRepository.AddAsync(account);
        }

        public async Task<IEnumerable<Account>> ObtenirTousAsync()
        {
            return await _compteRepository.GetAllAsync();
        }

        public async Task RetirerAsync(int compteId, Money montant)
        {
            if (montant == null)
                throw new ArgumentNullException(nameof(montant));

            var compte = await _compteRepository.GetByIdAsync(compteId);
            if (compte == null)
                    throw new KeyNotFoundException($"Compte {compteId} introuvable.");

            compte.Retirer(montant);
            await _compteRepository.UpdateAsync(compte);
        }

        public async Task DeposerAsync(int compteId, Money montant)
        {
            if (montant == null)
                throw new ArgumentNullException(nameof(montant));

            var compte = await _compteRepository.GetByIdAsync(compteId);
            if (compte == null)
                throw new KeyNotFoundException($"Compte {compteId} introuvable.");

            compte.Deposer(montant);
            await _compteRepository.UpdateAsync(compte);
        }
    }
}