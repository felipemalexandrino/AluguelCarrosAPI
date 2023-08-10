using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AluguelCarros.Model
{
    
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public bool Ativo { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required] 
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }

        public Cliente()
        {
            Ativo = false;
        }

    }
}
