using Microsoft.AspNetCore.Mvc;
using MyBiblioteca.Web.Data.Interfaces;
using MyBiblioteca.Web.ViewModel;
using System.Linq;

namespace MyBiblioteca.Web.Controllers
{
    public class EmprestarController : Controller
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IClienteRepository _clienteRepository;

        public EmprestarController(ILivroRepository livroRepository, IClienteRepository clienteRepository)
        {
            _livroRepository = livroRepository;
            _clienteRepository = clienteRepository;
        }
        [Route("Emprestar")]
        public IActionResult List()
        {
            //Carregar Todos os Livros Avaliado
            var avaliarLivros = _livroRepository.FiltraComAutor(x => x.MutuariaId == 0);
            //Checar a coleção
            if(avaliarLivros.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(avaliarLivros);
                //return Json(new
                //{
                //    data = avaliarLivros
                //});
            }
        }

        public IActionResult EmprestarLivro(int livroId)
        {
            //Carregar livro atual e todos os clientes
            var emprestarVM = new EmprestarViewModel()
            {
                Livro = _livroRepository.FiltraPorId(livroId),
                Clientes = _clienteRepository.FiltraTodos()
            };
            //Enviar dados para a exibição de empréstimo
            return View(emprestarVM);
        }
        [HttpPost]
        public IActionResult EmprestarLivro(EmprestarViewModel emprestarViewModel)
        {
            //Actualizar os dados
            var livro = _livroRepository.FiltraPorId(emprestarViewModel.Livro.MutuariaId);
            var cliente = _clienteRepository.FiltraPorId(emprestarViewModel.Livro.MutuariaId);

            livro.Mutuaria = cliente;
            _livroRepository.Update(livro);

            //redirecionar para lista
            return RedirectToAction("List");
        }
    }
}
