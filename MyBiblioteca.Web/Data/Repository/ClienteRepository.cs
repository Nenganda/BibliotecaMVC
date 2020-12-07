using MyBiblioteca.Web.Data.Interfaces;
using MyBiblioteca.Web.Data.Model;

namespace MyBiblioteca.Web.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(BibliotecaDbContext context) : base(context) { }
    }
}
