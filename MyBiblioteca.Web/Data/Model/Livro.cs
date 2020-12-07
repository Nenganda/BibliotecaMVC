using System.ComponentModel.DataAnnotations;

namespace MyBiblioteca.Web.Data.Model
{
    public class Livro
    {
        public int LivroId { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Titulo { get; set; }
        public virtual Autor Autor { get; set; }
        public int AutorId { get; set; }
        public virtual Cliente Mutuaria { get; set; }
        public int MutuariaId { get; set; }
    }
}
