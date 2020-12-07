using Microsoft.AspNetCore.Mvc;
using MyBiblioteca.Web.Data.Interfaces;
using MyBiblioteca.Web.Data.Model;
using MyBiblioteca.Web.ViewModel;
using System;
using System.Linq;

namespace MyBiblioteca.Web.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorRepository _autorRepository;

        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }
        [Route("Autor")]
        public IActionResult List()
        {
            var autores = _autorRepository.FiltraTodosComLivros();
            if (autores.Count() == 0) return View("Empty");
            return View(autores);
        }
        public IActionResult Update(int id)
        {
            var autor = _autorRepository.FiltraPorId(id);
            if (autor == null) return NotFound();
            return View(autor);
        }
        [HttpPost]
        public IActionResult Update(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return View(autor);
            }
            _autorRepository.Update(autor);
            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            var viewModel = new CreateAutorViewModel
            { RefererURL = Request.Headers["Referer"].ToString() };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateAutorViewModel autorVM)
        {
            if (!ModelState.IsValid)
            {
                return View(autorVM);
            }

            _autorRepository.Create(autorVM.Autor);

            if (!String.IsNullOrEmpty(autorVM.RefererURL))
            {
                return Redirect(autorVM.RefererURL);
            }

            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            var autor = _autorRepository.FiltraPorId(id);
            _autorRepository.Delete(autor);
            return RedirectToAction("List");
        }
    }
}
