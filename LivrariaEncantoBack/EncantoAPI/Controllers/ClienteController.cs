using EncantoAPI.Models;
using EncantoLib.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EncantoAPI.Controllers
{
    
    public class ClienteController : Controller
    {
        private readonly Contexto _contexto;

        public ClienteController(Contexto contexto)
        {
            _contexto = contexto;

        }
        public IEnumerable<Cliente> GetClientes()
        {
            return _contexto.Clientes;
        }

        public void CadastrarCliente(int id)
        {
            
        }
    }
}
