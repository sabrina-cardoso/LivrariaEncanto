using EncantoLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.DAL
{
    interface IVendaDAL
    {
        public Venda VendaGet(int id);
        public List<Venda> ListVendas();
        public void VendaUpdate(Livro livro);
        public void VendaAdd(Livro livro);
        public void VendaDelete(int id);
    }
}
