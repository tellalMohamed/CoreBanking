using CoreBanking.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreBanking.Application.DTO;

namespace CoreBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> Ajouter([FromBody] ClientDto client)
        {
            await _clientService.AjouterClient(client.LastName, client.FisrtName);
            return Ok("Client ajouté avec succès");
        }

        [HttpGet]
        public async Task<IActionResult> Liste()
        {
            var clients = await _clientService.ObtenirTous();
            return Ok(clients);
        }
    }
}