using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace AluguelCarros.Data.Dtos
{
    public class LoginUsuarioDTO
    {
        [Required]
        [SwaggerSchema(Description = "Login do usuario")]
        public string Login { get; set; }
        [Required]
        [SwaggerSchema(Description = "Senha do usuario")]
        public string Password { get; set; }
    }
}
