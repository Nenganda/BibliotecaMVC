using System.ComponentModel.DataAnnotations;

namespace MyBiblioteca.Web.Data.Model
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Descricao { get; set; }
    }
}
