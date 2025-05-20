using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Domain.Models;
using Pokemon.Domain.Services;

namespace Pokemon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonService _service;

        public PokemonController(PokemonService servico)
        {
            this._service = servico;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.AllPokemons());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.ListarPorId(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pokemon.Domain.Models.Pokemon obj)
        {
            var cadastra = _service.Cadastra(obj, out List<MensagemErro> msg);

            if (cadastra)
            {
                return Ok(obj);
            }

            return UnprocessableEntity(msg);
        }

        [HttpPut]
        public IActionResult Put ([FromBody] Pokemon.Domain.Models.Pokemon obj)
        {
            var edicao = _service.Atualiza(obj, out List<MensagemErro> msg);

            if (edicao)
            {
                return Ok(obj);
            }

            return UnprocessableEntity(msg);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleta = _service.Deletar(id);
            if (deleta)
            {
                return Ok();
            }
            return NotFound("Pokemon não encontrado");
        }

    }
}
