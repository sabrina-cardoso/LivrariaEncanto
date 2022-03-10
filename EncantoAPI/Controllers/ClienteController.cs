using EncantoLib.Entities;
using EncantoLib.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncantoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ClienteService _clienteService;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger, IConfiguration configuration )
        {
            _logger = logger;
            _configuration = configuration;
            _clienteService = new ClienteService(_configuration.GetConnectionString("conn"));
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult List()
        {
            return Ok(_clienteService.ListarClientes());
        }

        [HttpGet()]
        [Route("Cliente")]
        public IActionResult GetCliente(int id)
        {
            var cliente = _clienteService.CarregarCliente(id);
            if(cliente.Id != 0)
                return Ok(_clienteService.CarregarCliente(id));
            else
                return NotFound();
        }

        [HttpPost()]
        [Route("Cadastrar")]
        public void Post(Cliente cliente)
        {
            _clienteService.CadastrarCliente(cliente);
        }

        [HttpPut()]
        [Route("Atualizar")]
        public void Put(int id, Cliente cliente)
        {
            cliente.Id = id;
            _clienteService.AtualizarCliente(cliente);
        }

        [HttpDelete()]
        [Route("Desativar")]
        public void Delete(int id)
        {
            _clienteService.DesativarCliente(id);
        }

    }
}
