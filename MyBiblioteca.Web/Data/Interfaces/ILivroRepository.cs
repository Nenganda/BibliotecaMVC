using MyBiblioteca.Web.Data.Model;
using System;
using System.Collections.Generic;

namespace MyBiblioteca.Web.Data.Interfaces
{
    public interface ILivroRepository : IRepository<Livro>
    {
        IEnumerable<Livro> FiltraTodosComAutor();
        IEnumerable<Livro> FiltraComAutor(Func<Livro, bool> predicado);
        IEnumerable<Livro> FiltraComAutorEMutuaria(Func<Livro, bool> predicado);
    }
}
