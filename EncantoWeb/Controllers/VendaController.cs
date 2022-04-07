using EncantoLib.Entities;
using EncantoLib.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncantoWeb.Controllers
{
    public class VendaController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly LivroService _livroService;
        private readonly ClienteService _clienteService;

        public VendaController(IConfiguration configuration)
        {
            _configuration = configuration;
            _livroService = new LivroService(_configuration.GetConnectionString("conn"));
            _clienteService = new ClienteService(_configuration.GetConnectionString("conn"));
        }
        public ActionResult Index()
        {
            List<Venda> vendas = new List<Venda>();
            return View(vendas);
        }

        public ActionResult ListaClientes()
        {
            List<Cliente> clientes = _clienteService.ListarClientes();
            return View(clientes);
        }

        public ActionResult Cadastrar(Cliente cliente)
        {
            Venda venda = new Venda();
            venda.Cliente = _clienteService.CarregarCliente(cliente.Id);
            return View(venda);
        }

        [HttpPost]
        public ActionResult Cadastrar(Venda venda)
        {
            var vvend = venda;
            return RedirectToAction(nameof(Index));
        }
    }
}
