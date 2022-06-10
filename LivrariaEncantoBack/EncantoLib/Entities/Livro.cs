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
    public class Livro : ILivro
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Título")]
        public string Titulo { get; set; }
        [Required]
        [DisplayName("Gênero")]
        public GeneroLivro Genero { get; set; }
        [Required]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }
        public StatusLivro Status { get; set; }
    }
}
