using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.Entities
{
    public class VendaLivro
    {
        public int Id { get; set; }
        public Venda Venda { get; set; }
        public Livro Livro { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
