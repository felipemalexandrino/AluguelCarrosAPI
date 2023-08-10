using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace AluguelCarros.Model
{
    public class Carro
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Modelo  { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public int Ano { get; set; }
        [Required]
        public string Cor { get; set; }
        [Required]
        public string Placa  { get; set; }
        [Required]
        public string Revanam { get; set; }
        public bool Ativo { get; set; }
        public DateTime DtCadastrado{ get; set; }

        public Carro()
        {
            Ativo = false;
            DtCadastrado = DateTime.Now;  
        }

    }
}
