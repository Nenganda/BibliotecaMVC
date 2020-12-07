using System;
using System.Collections.Generic;

namespace MyBiblioteca.Web.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FiltraTodos();

        IEnumerable<T> FiltraTodos(Func<T, bool> predicado);

        T FiltraPorId(int id);
        void Create(T entity);

        void Update(T entity);
        void Delete(T entity);

        int Quantidade(Func<T, bool> predicado);
    }
}
