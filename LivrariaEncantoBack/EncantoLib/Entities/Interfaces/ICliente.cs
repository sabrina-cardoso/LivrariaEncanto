using EncantoLib.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.Entities.Interfaces
{
    public interface ICliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public StatusCliente Status { get; set; }
    }
}
