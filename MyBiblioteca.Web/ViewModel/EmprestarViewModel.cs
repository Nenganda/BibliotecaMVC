using MyBiblioteca.Web.Data.Model;
using System.Collections.Generic;

namespace MyBiblioteca.Web.ViewModel
{
    public class EmprestarViewModel
    {
        public Livro Livro { get; set; }
        public IEnumerable<Cliente> Clientes { get; set; }
    }
}
