using EncantoLib.Entities.Enums;
using EncantoLib.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.Entities
{
    public class Cliente : ICliente
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        [DisplayName("Data de Nascimento")]
        [DataType("Date")]
        public DateTime DataNasc { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        public StatusCliente Status { get; set; }
    }
}
