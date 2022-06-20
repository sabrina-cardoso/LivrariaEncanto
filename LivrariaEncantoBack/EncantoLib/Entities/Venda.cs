using EncantoLib.Entities.Enums;
using EncantoLib.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.Entities
{
    public class Venda : IVenda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public double Valor { get; set; }
        public StatusVenda Status { get; set; }
    }
}
