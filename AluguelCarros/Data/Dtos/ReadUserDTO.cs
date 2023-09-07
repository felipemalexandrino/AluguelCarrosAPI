using AluguelCarros.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace AluguelCarros.Data.Dtos
{
    public class ReadUserDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]      
        public TipoLogin Tipo { get; set; }
    }
}
