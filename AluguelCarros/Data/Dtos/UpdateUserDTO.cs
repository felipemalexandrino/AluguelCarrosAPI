using AluguelCarros.Model.Enum;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace AluguelCarros.Data.Dtos
{
    public class UpdateUserDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RePassword { get; set; }
        [Required]
        public TipoLogin Tipo { get; set; }
    }
}
