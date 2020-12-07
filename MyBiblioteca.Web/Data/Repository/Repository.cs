using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyBiblioteca.Web.Data.Interfaces;

namespace MyBiblioteca.Web.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BibliotecaDbContext _context;
        public Repository(BibliotecaDbContext context)
        {
            _context = context;
        }
        protected void Save() => _context.SaveChanges();
        public T FiltraPorId(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> FiltraTodos()
        {
            return _context.Set<T>();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public IEnumerable<T> FiltraTodos(Func<T, bool> predicado)
        {
            return _context.Set<T>().Where(predicado);
        }

        public int Quantidade(Func<T, bool> predicado)
        {
            return _context.Set<T>().Where(predicado).Count();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
}
