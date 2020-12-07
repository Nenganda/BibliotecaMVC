using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBiblioteca.Web.Data.Model
{
    public class Autor
    {
        public int AutorId { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Descricao { get; set; }
        public virtual ICollection<Livro> Livros{ get; set; }
    }
}
