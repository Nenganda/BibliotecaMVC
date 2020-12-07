using Microsoft.EntityFrameworkCore;
using MyBiblioteca.Web.Data.Model;

namespace MyBiblioteca.Web.Data
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}
