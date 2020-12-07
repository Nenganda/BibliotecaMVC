using Microsoft.AspNetCore.Mvc;
using MyBiblioteca.Web.Data.Interfaces;
using MyBiblioteca.Web.Data.Model;
using MyBiblioteca.Web.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MyBiblioteca.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ILivroRepository _livroRepository;

        public ClienteController(IClienteRepository clienteRepository, ILivroRepository livroRepository)
        {
            _clienteRepository = clienteRepository;
            _livroRepository = livroRepository;
        }

        [Route("Cliente")]
        public IActionResult List()
        {
            var clienteVM = new List<ClienteViewModel>();
            var clientes = _clienteRepository.FiltraTodos();
            if (clientes.Count() == 0)
            {
                return View("Empty");
            }
            foreach (var cliente in clientes)
            {
                clienteVM.Add(new ClienteViewModel
                {
                    Cliente = cliente,
                    LivroQuantidade = _livroRepository.Quantidade(x => x.MutuariaId == cliente.ClienteId)
                });
            }
            return View(clienteVM);
        }

        public IActionResult Delete(int id)
        {
            var cliente = _clienteRepository.FiltraPorId(id);
            _clienteRepository.Delete(cliente);
            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }
            _clienteRepository.Create(cliente);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var cliente = _clienteRepository.FiltraPorId(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Update(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }
            _clienteRepository.Update(cliente);
            return RedirectToAction("List");
        }
    }
}
