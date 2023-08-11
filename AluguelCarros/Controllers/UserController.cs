using AluguelCarros.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using AluguelCarros.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace AluguelCarros.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Tags("Usuarios")]
    public class UserController:ControllerBase
    {
        private UserService _usuarioService;

    public UserController(UserService cadastroService)
        {
            _usuarioService = cadastroService;
        }

        [HttpPost("cadastro")]
        [SwaggerOperation(Summary = "Metodo resposavel por cadastrar um usuario")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult CadastraUsuario(CreateUserDTO createUsuarioDto)
        {
            _usuarioService.Cadastrar(createUsuarioDto);
            return Ok("Usuario cadastrado !");
        }

        [HttpPost("login")]
        [SwaggerOperation(Summary = "Metodo resposavel por relizarlogin")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult Login(LoginUsuarioDTO logindto)
        {
            var token = _usuarioService.Login(logindto);
            return Ok(token);
        }
    }
}
