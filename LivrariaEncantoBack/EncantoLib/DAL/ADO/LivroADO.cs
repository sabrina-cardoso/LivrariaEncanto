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
    class LivroADO : ILivroDAL
    {
        readonly SqlConnection _conn;
        public LivroADO(string connString)
        {
            _conn = new SqlConnection(connString);
        }
        public List<Livro> ListLivros()
        {
            List<Livro> livros = new List<Livro>();
            try
            {
                _conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("select * from tb_livro", _conn)
                {
                    CommandType = CommandType.Text
                };

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Livro item = new Livro();
                            item.Id = Convert.ToInt32(reader["id"]);
                            item.Titulo = reader["titulo"].ToString();
                            item.Genero = (GeneroLivro)Convert.ToInt32(reader["genero"]);
                            item.Preco =  Convert.ToDecimal(reader["preco"]);
                            item.Status = (StatusLivro)Convert.ToInt32(reader["del_flag"]);
                            livros.Add(item);
                        }
                    }

                }

                return livros;
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

        public void LivroAdd(Livro livro)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("dbo.sp_livro_cadastrar", _conn)
                {
                    CommandType = CommandType.StoredProcedure

                };
                cmd.Parameters.Add(new SqlParameter("@titulo", livro.Titulo));
                cmd.Parameters.Add(new SqlParameter("@genero", livro.Genero));
                cmd.Parameters.Add(new SqlParameter("@preco", livro.Preco));
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

        public void LivroSetDisponibilidade(int id, StatusLivro status)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("UPDATE tb_livro SET del_flag = " +  ((int)status) + " WHERE id = " + id, _conn)
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

        public Livro LivroGet(int id)
        {
            try
            {
                _conn.Open();
                Livro livro = new Livro();
                SqlCommand cmd;
                cmd = new SqlCommand("SELECT * FROM tb_livro WHERE id = '" + id + "'", _conn)
                {
                    CommandType = CommandType.Text
                };
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            livro.Id = Convert.ToInt32(reader["id"]);
                            livro.Titulo = reader["titulo"].ToString();
                            livro.Genero = (GeneroLivro)Convert.ToInt32(reader["genero"]);
                            livro.Preco = Convert.ToDecimal(reader["preco"]);
                            livro.Status = (StatusLivro)Convert.ToInt32(reader["del_flag"]);
                        }
                    }
                }
                return livro;
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

        public void LivroUpdate(Livro livro)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("dbo.sp_livro_atualizar", _conn)
                {
                    CommandType = CommandType.StoredProcedure

                };
                cmd.Parameters.Add(new SqlParameter("@id", livro.Id));
                cmd.Parameters.Add(new SqlParameter("@titulo", livro.Titulo));
                cmd.Parameters.Add(new SqlParameter("@genero", livro.Genero));
                cmd.Parameters.Add(new SqlParameter("@preco", livro.Preco));
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
