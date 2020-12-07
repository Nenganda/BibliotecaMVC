﻿using MyBiblioteca.Web.Data.Model;
using System.Collections.Generic;

namespace MyBiblioteca.Web.ViewModel
{
    public class LivroViewModel
    {
        public Livro Livro { get; set; }
        public IEnumerable<Autor> Autores { get; set; }
    }
}
