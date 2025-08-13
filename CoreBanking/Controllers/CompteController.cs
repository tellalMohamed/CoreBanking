using CoreBanking.Application.DTO;
using CoreBanking.Application.Services;
using CoreBanking.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompteController : ControllerBase
    {
        private readonly CompteService _compteService;

        public CompteController(CompteService compteService)
        {
            _compteService = compteService;
        }

        [HttpPost]
        public async Task<IActionResult> Ajouter([FromBody] CompteDto compte)
        {
            await _compteService.CreerCompteAsync(compte.AccountNumber, compte.CustomerId);
            return Ok("Client ajouté avec succès");
        }

        [HttpGet]
        public async Task<IActionResult> Liste()
        {
            var comptes = await _compteService.ObtenirTousAsync();
            return Ok(comptes);
        }

        [HttpPost("{compteId}/depot")]
        public async Task<IActionResult> Depot(int compteId, [FromBody] Money montant)
        {
            await _compteService.DeposerAsync(compteId, montant);
            return Ok("Dépôt effectué.");
        }

        [HttpPost("{compteId}/retrait")]
        public async Task<IActionResult> Retrait(int compteId, [FromBody] Money montant)
        {
            await _compteService.RetirerAsync(compteId, montant);
            return Ok("Retrait effectué.");
        }
    }
}