using EncantoLib.DAL.ADO;
using EncantoLib.Entities;
using EncantoLib.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.Services
{
    public class ClienteService
    {
        //private ClienteADO _clienteADO;
        //private EnderecoADO _enderecoADO;

        //public ClienteService(string connString)
        //{
        //    _clienteADO = new ClienteADO(connString);
        //    _enderecoADO = new EnderecoADO(connString);
        //}

        //public Cliente CarregarCliente(int id)
        //{
        //    Cliente cliente = _clienteADO.ClienteGet(id);
        //    cliente.Endereco = _enderecoADO.EnderecoGet(id);
        //    return cliente;
        //}

        //public List<Cliente> ListarClientes()
        //{
        //    List<Cliente> clientes = _clienteADO.ListClientes();
        //    foreach (Cliente item in clientes)
        //    {
        //        item.Endereco = _enderecoADO.EnderecoGet(item.Id);
        //    }
        //    return clientes;
        //}

        ////public void CadastrarCliente(Cliente cliente)
        ////{
        ////    cliente.Status = StatusCliente.Ativo;
        ////    _clienteADO.ClienteAdd(cliente);
        ////    cliente.Endereco.Id = cliente.Id;
        ////    _enderecoADO.EnderecoAdd(cliente.Endereco);
        ////}

        //public void AtualizarCliente(Cliente cliente)
        //{
        //    _clienteADO.ClienteUpdate(cliente);
        //}

        //public void DesativarCliente(int id)
        //{
        //    _clienteADO.ClienteSetStatus(id, StatusCliente.Inativo);
        //}

        //public void AtivarCliente(int id)
        //{
        //    _clienteADO.ClienteSetStatus(id, StatusCliente.Ativo);
        //}
    }
}
