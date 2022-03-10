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
    public class LivroController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly LivroService _livroService;

        public LivroController(IConfiguration configuration)
        {
            _configuration = configuration;
            _livroService = new LivroService(_configuration.GetConnectionString("conn"));
        }
        public IActionResult Index()
        {
            List<Livro> livros = _livroService.ListarLivros();
            return View(livros);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Livro livro)
        {
            if (ModelState.IsValid)
            {
                _livroService.CadastrarLivro(livro);
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        public IActionResult Editar(int id)
        {
            var livro = _livroService.CarregarLivro(id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Livro livro)
        {
            if (ModelState.IsValid)
            {
                livro.Id = id;
                _livroService.AtualizarLivro(livro);
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        public IActionResult AtivarLivro(int id)
        {
            _livroService.AtivarLivro(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DesativarLivro(int id)
        {
            _livroService.DesativarLivro(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
