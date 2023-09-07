using AluguelCarros.Model.Enum;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace AluguelCarros.Data.Dtos
{
    public class UpdateUserDTO
    {
        [Required]
        [SwaggerSchema(Description = "Login usuario")]
        public string Login { get; set; }
        [Required]
        [SwaggerSchema(Description = "Senha do usuario")]
        public string Password { get; set; }
        [Required]
        [SwaggerSchema(Description = "Confirmar senha")]
        public string RePassword { get; set; }
    }
}
