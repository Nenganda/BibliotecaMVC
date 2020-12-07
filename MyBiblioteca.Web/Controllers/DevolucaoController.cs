using Microsoft.AspNetCore.Mvc;
using MyBiblioteca.Web.Data.Interfaces;
using System.Linq;

namespace MyBiblioteca.Web.Controllers
{
    public class DevolucaoController : Controller
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IClienteRepository _clienteRepository;
        public DevolucaoController(ILivroRepository livroRepository, IClienteRepository clienteRepository)
        {
            _livroRepository = livroRepository;
            _clienteRepository = clienteRepository;
        }

        [Route("Devolucao")]
        public IActionResult List()
        {
            //Carregar todos os livros emprestados
            var mutuariaLivros = _livroRepository.FiltraComAutorEMutuaria(x => x.MutuariaId != 0);
            //Confira a coleção de livros
            if(mutuariaLivros == null || mutuariaLivros.ToList().Count() == 0)
            {
                return View("Empty");
            }
            return View(mutuariaLivros);
        }
        public IActionResult DevolucaoDoLivro(int livroId)
        {
            //carregar o livro atual
            var livro = _livroRepository.FiltraPorId(livroId);
            //remover mutuário
            livro.Mutuaria = null;

            livro.MutuariaId = 0;
            //atualizar o banco de dados
            _livroRepository.Update(livro);
            //redirecionar para o método de lista
            return RedirectToAction("List");
        }
    }
}