using Microsoft.AspNetCore.Mvc;
using MyBiblioteca.Web.Data.Interfaces;
using MyBiblioteca.Web.ViewModel;

namespace MyBiblioteca.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IAutorRepository _autorRepository;
        private readonly IClienteRepository _clienteRepository;
        public HomeController(ILivroRepository livroRepository,
                                IAutorRepository autorReposity,
                                IClienteRepository clienteRepository)
        {
            _livroRepository = livroRepository;
            _autorRepository = autorReposity;
            _clienteRepository = clienteRepository;
        }
        public IActionResult Index()
        {
            //Criar modelo de vista inicial
            var homeVM = new HomeViewModel()
            {
                AutorQuantidade = _autorRepository.Quantidade(x => true),
                ClienteQuantidade = _clienteRepository.Quantidade(x => true),
                LivroQuantidade = _livroRepository.Quantidade(x => true),
                EmprestimoQuantidade = _livroRepository.Quantidade(x => x.Mutuaria != null)
            };
            //Vista de chamada
            return View(homeVM);
        }
    }
}
