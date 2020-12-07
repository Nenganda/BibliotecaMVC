using Microsoft.EntityFrameworkCore;
using MyBiblioteca.Web.Data.Interfaces;
using MyBiblioteca.Web.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyBiblioteca.Web.Data.Repository
{
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        public AutorRepository(BibliotecaDbContext context) : base(context)
        {
        }
        public IEnumerable<Autor> FiltraTodosComLivros()
        {
            return _context.Autores.Include(a => a.Livros);
        }
        public Autor FiltraComLivros(int id)
        {
            return _context.Autores
                  .Where(a => a.AutorId == id)
                  .Include(a => a.Livros)
                  .FirstOrDefault();
        }
    }
}
