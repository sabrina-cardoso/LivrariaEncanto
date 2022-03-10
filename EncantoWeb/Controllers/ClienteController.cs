using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using EncantoLib.Services;
using EncantoLib.Entities;
using System.Collections.Generic;

namespace EncantoWeb.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ClienteService _clienteService;

        public ClienteController(IConfiguration configuration)
        {
            _configuration = configuration;
            _clienteService = new ClienteService(_configuration.GetConnectionString("conn"));
        }
        public IActionResult Index()
        {
            List<Cliente> clientes = _clienteService.ListarClientes();
            return View(clientes);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteService.CadastrarCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Editar(int id)
        {
            var cliente = _clienteService.CarregarCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Id = id;
                _clienteService.AtualizarCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Ativar(int id)
        {
            _clienteService.AtivarCliente(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Desativar(int id)
        {
            _clienteService.DesativarCliente(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
