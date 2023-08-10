using System.ComponentModel.DataAnnotations;

namespace AluguelCarros.Data.Dtos
{
    public class ReadClienteDTO
    {        
        public string Nome { get; set; }       
        public string Sobrenome { get; set; }             
        public string CPF { get; set; }       
        public string Email { get; set; }       
        public string Telefone { get; set; }
        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }
}
