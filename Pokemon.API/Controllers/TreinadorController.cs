using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Domain.DTO;
using Pokemon.Domain.Models;
using Pokemon.Domain.Services;

namespace Pokemon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreinadorController : ControllerBase
    {
        private readonly TreinadorService _service;

        public TreinadorController(TreinadorService servico)
        {
            this._service = servico;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.AllTreinadores());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.IdListarTreinador(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] VinculoTreinadorPokemon obj)
        {
            var cadastra = _service.Cadastra(obj, out List<MensagemErro> msg);
            if (cadastra)
            {
                return Ok(obj);
            }
            return UnprocessableEntity(msg);
        }

        [HttpPut]
        public IActionResult Put([FromBody] VinculoTreinadorPokemon obj)
        {
            var edicao = _service.Editar(obj, out List<MensagemErro> msg);
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
            return NotFound();
        }
    }
}
