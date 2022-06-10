using EncantoLib.DAL.ADO;
using EncantoLib.Entities;
using EncantoLib.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.Services
{
    public class LivroService
    {
        private LivroADO _livroADO;

        public LivroService(string connString)
        {
            _livroADO = new LivroADO(connString);
        }

        public Livro CarregarLivro(int id)
        {
            return _livroADO.LivroGet(id);
        }

        public List<Livro> ListarLivros()
        {
            return _livroADO.ListLivros();
        }

        public void CadastrarLivro(Livro livro) 
        {
            _livroADO.LivroAdd(livro);
        }

        public void AtualizarLivro(Livro livro)
        {
            _livroADO.LivroUpdate(livro);
        }

        public void AtivarLivro(int id)
        {
            _livroADO.LivroSetDisponibilidade(id, StatusLivro.Disponivel);
        }

        public void DesativarLivro(int id)
        {
            _livroADO.LivroSetDisponibilidade(id, StatusLivro.Indisponivel);
        }

    }
}
