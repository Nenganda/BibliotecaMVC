using Microsoft.AspNetCore.Mvc;
using MyBiblioteca.Web.Data.Interfaces;
using MyBiblioteca.Web.Data.Model;
using MyBiblioteca.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBiblioteca.Web.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IAutorRepository _autorRepository;

        public LivroController(ILivroRepository livroRepository, IAutorRepository autorRepository)
        {
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
        }
        [Route("Livro")]
        public IActionResult List(int? autorId, int? mutuariaId)
        {
            if(autorId == null && mutuariaId == null)
            {
                //Ver Todos os Livros
                var livros = _livroRepository.FiltraTodosComAutor();
                //Checar os Livros
                return ChecarLivros(livros);
            }
            else if(autorId != null)
            {
                //Filtrar Autor por ID
                var autor = _autorRepository.FiltraComLivros((int)autorId);
                //Checar os Autores
                if(autor.Livros.Count() == 0)
                {
                    return View("AutorEmpty", autor);
                }
                else
                {
                    return View(autor.Livros);
                }
            }
            else if(mutuariaId != null)
            {
                //Filtrar Mutuaria por ID
                var livros = _livroRepository.FiltraComAutorEMutuaria(livro => livro.MutuariaId == mutuariaId);
                //Checar a Mutuaria
                return ChecarLivros(livros);
            }
            else
            {
                //Lançar exceção
                throw new ArgumentException();
            }
        }
        public IActionResult ChecarLivros(IEnumerable<Livro> livros)
        {
            if (livros.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(livros);
            }
        }
        public IActionResult Create()
        {
            var livroVM = new LivroViewModel()
            {
                Autores = _autorRepository.FiltraTodos()
            };
            return View(livroVM);
        }
        [HttpPost]
        public IActionResult Create(LivroViewModel livroViewModel)
        {
            if (!ModelState.IsValid)
            {
                livroViewModel.Autores = _autorRepository.FiltraTodos();
                return View(livroViewModel);
            }

            _livroRepository.Create(livroViewModel.Livro);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var livroVM = new LivroViewModel()
            {
                Livro = _livroRepository.FiltraPorId(id),
                Autores = _autorRepository.FiltraTodos()
            };
            return View(livroVM);
        }
        [HttpPost]
        public IActionResult Update(LivroViewModel livroViewModel)
        {
            if (!ModelState.IsValid)
            {
                livroViewModel.Autores = _autorRepository.FiltraTodos();
                return View(livroViewModel);
            }

            _livroRepository.Update(livroViewModel.Livro);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var livro = _livroRepository.FiltraPorId(id);
            _livroRepository.Delete(livro);
            return RedirectToAction("List");
        }
    }
}
