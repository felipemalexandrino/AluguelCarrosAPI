using AluguelCarros.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AluguelCarros.Services
{
    public class TokenService
    {
        private IConfiguration _configurarion;

        public TokenService(IConfiguration configurarion)
        {
            _configurarion = configurarion;
        }
        public string GenereteToken(User usuario)
        {
            string Ids = Convert.ToString(usuario.Id);
            Claim[] claims = new Claim[]
            {
                new Claim("usename",usuario.Login),
                new Claim("usename",usuario.Password),
                new Claim("id",Ids),
                new Claim("loginTimestamp",DateTime.UtcNow.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configurarion["SymmetricSecurityKey"]));

            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    expires: DateTime.Now.AddMinutes(10),
                    claims: claims,
                    signingCredentials:signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}