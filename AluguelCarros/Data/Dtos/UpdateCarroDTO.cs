using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace AluguelCarros.Data.Dtos
{
    public class UpdateCarroDTO
    {
        [Required]
        [SwaggerSchema(Description = "Modelo do Veiculo")]
        public string Modelo { get; set; }
        [Required]
        [SwaggerSchema(Description = "Marca do Veiculo")]
        public string Marca { get; set; }
        [Required]
        [SwaggerSchema(Description = "Ano do Veiculo")]
        public int Ano { get; set; }
        [Required]
        [SwaggerSchema(Description = "Cor do Veiculo")]
        public string Cor { get; set; }
        [Required]
        [SwaggerSchema(Description = "Placa do Veiculo")]
        public string Placa { get; set; }
        [Required]
        [SwaggerSchema(Description = "Renavam do Veiculo")]
        public string Revanam { get; set; }
    }
}
