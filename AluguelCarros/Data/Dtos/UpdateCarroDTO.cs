using System.ComponentModel.DataAnnotations;

namespace AluguelCarros.Data.Dtos
{
    public class UpdateCarroDTO
    {
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public int Ano { get; set; }
        [Required]
        public string Cor { get; set; }
        [Required]
        public string Placa { get; set; }
        [Required]
        public string Revanam { get; set; }
    }
}
