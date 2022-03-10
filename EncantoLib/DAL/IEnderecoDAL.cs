using EncantoLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.DAL
{
    interface IEnderecoDAL
    {
        public Endereco EnderecoGet(int id);
        public void EnderecoUpdate(Endereco endereco);
        public void EnderecoAdd(Endereco endereco);
    }
}
