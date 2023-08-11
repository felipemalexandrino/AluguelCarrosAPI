using AluguelCarros.Data;
using AluguelCarros.Data.Dtos;
using AluguelCarros.Model;
using AutoMapper;

namespace AluguelCarros.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private TokenService _tokenService;
        private AluguelContext _context;

        public UserService(IMapper mapper, TokenService tokenService, AluguelContext context)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _context = context;
        }

        public void Cadastrar(CreateUserDTO dto)
        {

            User usuario = _mapper.Map<User>(dto);
            _context.Users.Add(usuario);
            _context.SaveChanges();
        }

        public async Task<string> Login(LoginUsuarioDTO logindto)
        {
            var resultado = _context.Users.Where(x => x.Login == logindto.Login && x.Password == logindto.Password);

            if (resultado == null)
            {
                throw new ApplicationException("Usuario não Autenticado !");
            }

            var usuario = _context.Users.FirstOrDefault(user => user.Login == logindto.Login.ToUpper());

            var token = _tokenService.GenereteToken(usuario);

            return token;
        }
    }
}
