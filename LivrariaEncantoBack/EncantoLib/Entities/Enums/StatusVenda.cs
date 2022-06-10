using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.Entities.Enums
{
    public enum StatusVenda : int
    {
        PagamentoPendente = 1,
        Processando = 2,
        Enviado = 3,
        Entregue = 4
    }
}
