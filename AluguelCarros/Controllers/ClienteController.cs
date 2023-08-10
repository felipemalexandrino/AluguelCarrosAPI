using AluguelCarros.Data;
using AluguelCarros.Data.Dtos;
using AluguelCarros.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarros.Controllers
{   
    [ApiController]

    [Route("[controller]")]
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
        public IActionResult Cadastrar([FromBody] CreateClienteDTO clienteDTO)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetClienteCPF), new {cpf = cliente.CPF }, cliente);
        }

        [HttpPut("{cpf}")]
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
        public IActionResult Deletar(string cpf)
        {
            var cliente = _context.Clientes.FirstOrDefault(
            cliente => cliente.CPF == cpf);
            if (cliente == null) return NotFound();
            _context.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{cpf}")]
        public IActionResult GetClienteCPF(string cpf)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.CPF == cpf);
            if (cliente == null) return NotFound();
            ReadClienteDTO clienteDTO = _mapper.Map<ReadClienteDTO>(cliente);
            return Ok(clienteDTO);
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            return Ok(_context.Clientes.ToList());

        }



    }
}
