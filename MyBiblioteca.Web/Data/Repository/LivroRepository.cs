using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyBiblioteca.Web.Data.Interfaces;
using MyBiblioteca.Web.Data.Model;

namespace MyBiblioteca.Web.Data.Repository
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(BibliotecaDbContext context) : base(context) { }
        public IEnumerable<Livro> FiltraComAutor(Func<Livro, bool> predicado)
        {
            return _context.Livros
                .Include(a => a.Autor)
                .Where(predicado);
        }

        public IEnumerable<Livro> FiltraComAutorEMutuaria(Func<Livro, bool> predicado)
        {
            return _context.Livros
                .Include(a => a.Autor)
                .Include(a => a.Mutuaria)
                .Where(predicado);
        }

        public IEnumerable<Livro> FiltraTodosComAutor()
        {
            return _context.Livros.Include(a => a.Autor);
        }
    }
}
