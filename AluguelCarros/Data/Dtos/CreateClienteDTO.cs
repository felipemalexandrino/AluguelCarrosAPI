using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace AluguelCarros.Data.Dtos
{
    public class CreateClienteDTO
    {       
        [Required]
        [SwaggerSchema(Description = "Nome do Cliente")]
        public string Nome { get; set; }
        [Required]
        [SwaggerSchema(Description = "Sobrenome do Cliente")]
        public string Sobrenome { get; set; }
        [Required]
        [SwaggerSchema(Description = "CPF do Cliente")]
        public string CPF { get; set; }
        [Required]
        [SwaggerSchema(Description = "Email do Cliente")]
        public string Email { get; set; }
        [Required]
        [SwaggerSchema(Description = "Telefone ou celular do Cliente")]
        public string Telefone { get; set; }
    }
}
