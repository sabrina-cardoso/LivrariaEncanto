﻿using EncantoLib.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.Entities.Interfaces
{
    public interface ILivro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public GeneroLivro Genero { get; set; }
        public decimal Preco { get; set; }
        public StatusLivro Status { get; set; }
    }
}
