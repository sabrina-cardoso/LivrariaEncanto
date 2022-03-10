using EncantoLib.Entities;
using EncantoLib.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.DAL.ADO
{
    class ClienteADO : IClienteDAL
    {
        readonly SqlConnection _conn;

        public ClienteADO(string connString)
        {
            _conn = new SqlConnection(connString);
        }

        public void ClienteAdd(Cliente cliente)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("dbo.sp_cliente_cadastrar", _conn)
                {
                    CommandType = CommandType.StoredProcedure

                };
                cmd.Parameters.Add(new SqlParameter("@nome", cliente.Nome));
                cmd.Parameters.Add(new SqlParameter("@cpf", cliente.Cpf));
                cmd.Parameters.Add(new SqlParameter("@data_nasc", cliente.DataNasc));
                cmd.Parameters.Add(new SqlParameter("@telefone", cliente.Telefone));
                cmd.Parameters.Add(new SqlParameter("@email", cliente.Email));
                cmd.Parameters.Add(new SqlParameter("@status", cliente.Status));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            cliente.Id = Convert.ToInt32(reader["id"]);              
                        }
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void ClienteSetStatus(int id, StatusCliente status)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("UPDATE tb_cliente SET [status] =" +  status + "WHERE id = " + id, _conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public Cliente ClienteGet(int id)
        {
            try
            {
                _conn.Open();
                Cliente cliente = new Cliente();
                SqlCommand cmd;
                cmd = new SqlCommand("SELECT * FROM tb_cliente WHERE id = '" + id + "'", _conn)
                {
                    CommandType = CommandType.Text
                };
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            cliente.Id = Convert.ToInt32(reader["id"]);
                            cliente.Nome = reader["nome"].ToString();
                            cliente.Cpf = reader["cpf"].ToString();
                            cliente.DataNasc = Convert.ToDateTime(reader["data_nasc"]);
                            cliente.Telefone = reader["telefone"].ToString();
                            cliente.Email = reader["email"].ToString();
                            cliente.Status = (StatusCliente)Convert.ToInt32(reader["status"]);
                        }
                    }

                }
                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void ClienteUpdate(Cliente cliente)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("dbo.sp_cliente_atualizar", _conn)
                {
                    CommandType = CommandType.StoredProcedure

                };
                cmd.Parameters.Add(new SqlParameter("@id", cliente.Id));
                cmd.Parameters.Add(new SqlParameter("@nome", cliente.Nome));
                cmd.Parameters.Add(new SqlParameter("@telefone", cliente.Telefone));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public List<Cliente> ListClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                _conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("select * from tb_cliente", _conn)
                {
                    CommandType = CommandType.Text
                };

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Cliente item = new Cliente();
                            item.Id = Convert.ToInt32(reader["id"]);
                            item.Nome = reader["nome"].ToString();
                            item.Cpf = reader["cpf"].ToString();
                            item.DataNasc = Convert.ToDateTime(reader["data_nasc"]);
                            item.Telefone = reader["telefone"].ToString();
                            item.Email = reader["email"].ToString();
                            item.Status = (StatusCliente)Convert.ToInt32(reader["status"]);
                            clientes.Add(item);
                        }
                    }

                }

                return clientes;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
