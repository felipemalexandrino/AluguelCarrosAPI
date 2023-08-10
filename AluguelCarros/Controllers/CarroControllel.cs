using AluguelCarros.Data;
using AluguelCarros.Data.Dtos;
using AluguelCarros.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarros.Controllers
{   
    [ApiController]

    [Route("[controller]")]
    public class CarroController : Controller
    {
        private AluguelContext _context;
        private IMapper _mapper;
        public CarroController(AluguelContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Cadastrar([FromBody] CreateCarroDTO carroDTO)
        {
            Carro carro = _mapper.Map<Carro>(carroDTO);
            _context.Carros.Add(carro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCarroCPF), new {Id= carro.Id }, carroDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] UpdateCarroDTO CarroDTO)
        {
            var Carro = _context.Carros.FirstOrDefault(
            Carro => Carro.Id == id);
            if (Carro == null) return NotFound();
            _mapper.Map(CarroDTO, Carro);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var Carro = _context.Carros.FirstOrDefault(
            Carro => Carro.Id == id);
            if (Carro == null) return NotFound();
            _context.Update(Carro.Ativo == true);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetCarroCPF(int id)
        {
            var Carro = _context.Carros.Where(c=>c.Ativo==false).FirstOrDefault(Carro => Carro.Id == id);
            if (Carro == null) return NotFound();
            ReadCarroDTO CarroDTO = _mapper.Map<ReadCarroDTO>(Carro);
            return Ok(CarroDTO);
        }

        [HttpGet]
        public IActionResult GetCarros()
        {
            return Ok(_context.Carros.Where(c=>c.Ativo == false).ToList());

        }
    }
}
