using EncantoLib.Entities;
using EncantoLib.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.DAL
{
    interface ILivroDAL
    {
        public Livro LivroGet(int id);
        public List<Livro> ListLivros();
        public void LivroUpdate(Livro livro);
        public void LivroAdd(Livro livro);
        public void LivroSetDisponibilidade(int id, StatusLivro status);
    }
}
