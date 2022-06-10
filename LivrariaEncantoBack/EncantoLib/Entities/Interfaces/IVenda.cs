using EncantoLib.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.Entities.Interfaces
{
    public interface IVenda
    {
        public int Id { get; set; }
        public ICliente Cliente { get; set; }
        public List<ILivro> Livros { get; set; }
        public double Valor { get; set; }
        public StatusVenda Status { get; set; }
    }
}
