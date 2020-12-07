using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyBiblioteca.Web.Data.Model;
using System.Collections.Generic;

namespace MyBiblioteca.Web.Data
{
    public static class DbInitialize
    {
        public static void Semente(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BibliotecaDbContext>();

                //add Cliente
                var John = new Cliente { Descricao = "John Francis" };
                var Peter = new Cliente { Descricao = "Peter Kikela" };
                var Noe = new Cliente { Descricao = "Noe Kikela" };
                var Francisco = new Cliente { Descricao = "Francisco Sanda" };

                context.Clientes.Add(John);
                context.Clientes.Add(Peter);
                context.Clientes.Add(Noe);
                context.Clientes.Add(Francisco);

                //Add Autor
                var autorCarlinho = new Autor
                {
                    Descricao = "Kikela Carlinho",
                    Livros = new List<Livro>()
                    {
                        new Livro { Titulo = "O Homem mais Rico"},
                        new Livro { Titulo = "O Rico"}
                    }
                };

                var autorYohami = new Autor
                {
                    Descricao = "Francisco Yohami",
                    Livros = new List<Livro>()
                    {
                        new Livro { Titulo = "A vida a 2"},
                        new Livro { Titulo = "Casal inteligente Enriquecem Juntos"},
                        new Livro { Titulo = "Vida Saudável"}
                    }
                };

                context.Autores.Add(autorCarlinho);
                context.Autores.Add(autorYohami);

                context.SaveChanges();
            }
        }
    }
}
