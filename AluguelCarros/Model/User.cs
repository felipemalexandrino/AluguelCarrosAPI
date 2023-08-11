using AluguelCarros.Model.Enum;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace AluguelCarros.Model
{
    public class User
    {        
        [Required]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public TipoLogin Tipo { get; set; }
        public bool Ativo { get; set; }
        public DateTime DtCadastro { get; set; }

        public User()
        {
            Ativo = false;
            DtCadastro = DateTime.Now;
            Tipo = TipoLogin.User;
        }




    }
}
