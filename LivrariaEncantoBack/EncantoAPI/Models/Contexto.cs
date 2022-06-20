using EncantoLib.Entities;
using Microsoft.EntityFrameworkCore;

namespace EncantoAPI.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaLivro> VendaLivro { get; set; }
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }
    }
}
