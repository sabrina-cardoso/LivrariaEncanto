using EncantoLib.Entities;
using EncantoLib.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.DAL
{
    interface IClienteDAL
    {
        public Cliente ClienteGet(int id);
        public List<Cliente> ListClientes();
        public void ClienteUpdate(Cliente cliente);
        public void ClienteAdd(Cliente cliente);
        public void ClienteSetStatus(int id, StatusCliente status);

    }
}
