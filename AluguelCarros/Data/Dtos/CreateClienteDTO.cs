using System.ComponentModel.DataAnnotations;

namespace AluguelCarros.Data.Dtos
{
    public class CreateClienteDTO
    {       
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
    }
}
