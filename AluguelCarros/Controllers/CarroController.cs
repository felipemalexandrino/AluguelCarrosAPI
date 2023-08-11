using AluguelCarros.Data;
using AluguelCarros.Data.Dtos;
using AluguelCarros.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AluguelCarros.Controllers
{   
    [ApiController]

    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
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
        [SwaggerOperation(Summary = "Metodo resposavel por cadastrar um Veiculo")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult Cadastrar([FromBody] CreateCarroDTO carroDTO)
        {
            Carro carro = _mapper.Map<Carro>(carroDTO);
            _context.Carros.Add(carro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCarroId), new {Id= carro.Id }, carroDTO);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Metodo resposavel por atualizar dados de um Veiculo")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
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
        [SwaggerOperation(Summary = "Metodo resposavel por excluir um veiculo")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
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
        [SwaggerOperation(Summary = "Metodo resposavel por consultar um veiculo por ID")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult GetCarroId(int id)
        {
            var Carro = _context.Carros.Where(c=>c.Ativo==false).FirstOrDefault(Carro => Carro.Id == id);
            if (Carro == null) return NotFound();
            ReadCarroDTO CarroDTO = _mapper.Map<ReadCarroDTO>(Carro);
            return Ok(CarroDTO);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retornar uma Lista de Veiculos")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult GetCarros()
        {
            return Ok(_context.Carros.Where(c=>c.Ativo == false).ToList());

        }
    }
}
