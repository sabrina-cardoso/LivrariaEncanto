using EncantoLib.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncantoLib.DAL.ADO
{
    class EnderecoADO : IEnderecoDAL
    {
        readonly SqlConnection _conn;

        public EnderecoADO(string connString)
        {
            _conn = new SqlConnection(connString);
        }

        public void EnderecoAdd(Endereco endereco)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("dbo.sp_endereco_cadastrar", _conn)
                {
                    CommandType = CommandType.StoredProcedure

                };
                cmd.Parameters.Add(new SqlParameter("@id", endereco.Id));
                cmd.Parameters.Add(new SqlParameter("@cep", endereco.Cep));
                cmd.Parameters.Add(new SqlParameter("@rua", endereco.Rua));
                cmd.Parameters.Add(new SqlParameter("@numero", endereco.Numero));
                cmd.Parameters.Add(new SqlParameter("@complemento", endereco.Complemento));
                cmd.Parameters.Add(new SqlParameter("@bairro", endereco.Bairro));
                cmd.Parameters.Add(new SqlParameter("@cidade", endereco.Cidade));
                cmd.Parameters.Add(new SqlParameter("@estado", endereco.Estado));
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

        public Endereco EnderecoGet(int id)
        {
            try
            {
                _conn.Open();
                Endereco endereco = new Endereco();
                SqlCommand cmd;
                cmd = new SqlCommand("SELECT * FROM tb_endereco WHERE id = '" + id + "'", _conn)
                {
                    CommandType = CommandType.Text
                };
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            endereco.Id = Convert.ToInt32(reader["id"]);
                            endereco.Cep = reader["cep"].ToString();
                            endereco.Rua = reader["rua"].ToString();
                            endereco.Numero = reader["numero"].ToString();
                            endereco.Complemento = reader["complemento"].ToString();
                            endereco.Bairro = reader["bairro"].ToString();
                            endereco.Cidade = reader["cidade"].ToString();
                            endereco.Estado = reader["estado"].ToString();
                        }
                    }

                }
                return endereco;
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

        public void EnderecoUpdate(Endereco endereco)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("dbo.sp_endereco_atualizar", _conn)
                {
                    CommandType = CommandType.StoredProcedure

                };
                cmd.Parameters.Add(new SqlParameter("@id", endereco.Id));
                cmd.Parameters.Add(new SqlParameter("@cep", endereco.Cep));
                cmd.Parameters.Add(new SqlParameter("@rua", endereco.Rua));
                cmd.Parameters.Add(new SqlParameter("@numero", endereco.Numero));
                cmd.Parameters.Add(new SqlParameter("@complemento", endereco.Complemento));
                cmd.Parameters.Add(new SqlParameter("@bairro", endereco.Bairro));
                cmd.Parameters.Add(new SqlParameter("@cidade", endereco.Cidade));
                cmd.Parameters.Add(new SqlParameter("@estado", endereco.Estado));
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
    }
}
