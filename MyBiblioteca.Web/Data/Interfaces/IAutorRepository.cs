using MyBiblioteca.Web.Data.Model;
using System.Collections.Generic;

namespace MyBiblioteca.Web.Data.Interfaces
{
    public interface IAutorRepository : IRepository<Autor>
    {
        IEnumerable<Autor> FiltraTodosComLivros();
        Autor FiltraComLivros(int id);
    }
}
