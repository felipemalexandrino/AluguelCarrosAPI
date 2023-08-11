using AluguelCarros.Data;
using AluguelCarros.Data.Dtos;
using AluguelCarros.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.Formats.Asn1;

namespace AluguelCarros.Controllers
{   
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Tags("Clientes")]
    public class ClienteController : Controller
    {
        private AluguelContext _context;
        private IMapper _mapper;
        public ClienteController(AluguelContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerOperation(Summary = "Metodo resposavel por cadastrar um cliente")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult Cadastrar([FromBody] CreateClienteDTO clienteDTO)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetClienteCPF), new {cpf = cliente.CPF }, cliente);
        }

        [HttpPut("{cpf}")]
        [SwaggerOperation(Summary = "Metodo resposavel por atualizar os dados cliente")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult Atualizar(string cpf, [FromBody] UpdateClienteDTO clienteDTO)
        {
            var cliente = _context.Clientes.FirstOrDefault(
            cliente => cliente.CPF == cpf);
            if (cliente == null) return NotFound();
            _mapper.Map(clienteDTO, cliente);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{cpf}")]
        [SwaggerOperation(Summary = "Metodo resposavel por excluir um cliente")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult Deletar(string cpf)
        {
            var cliente = _context.Clientes.FirstOrDefault(
            cliente => cliente.CPF == cpf);
            if (cliente == null) return NotFound();
            _context.Update(cliente.Ativo == true);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{cpf}")]
        [SwaggerOperation(Summary = "Metodo resposavel por consultar um cliente pelo CPF")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult GetClienteCPF(string cpf)
        {
            var cliente = _context.Clientes.Where(c=>c.Ativo==false).FirstOrDefault(cliente => cliente.CPF == cpf);
            if (cliente == null) return NotFound();
            ReadClienteDTO clienteDTO = _mapper.Map<ReadClienteDTO>(cliente);
            return Ok(clienteDTO);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Metodo resposavel para retornar uma lista de Clientes")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult GetClientes()
        {
            return Ok(_context.Clientes.Where(c=>c.Ativo == false).ToList());

        }



    }
}
