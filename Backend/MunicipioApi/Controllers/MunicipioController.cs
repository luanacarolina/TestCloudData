using Microsoft.AspNetCore.Mvc;
using MunicipioApi.Models;
using MunicipioApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MunicipioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioRepository _municipioRepository;
       
        public MunicipioController(IMunicipioRepository municipioRepository)
        {
            _municipioRepository = municipioRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Entidade>> ObterMunicipios()
        {

            return await _municipioRepository.Get();
        }

   

        [HttpGet("{id}")]
        public async Task<ActionResult<Entidade>> ObterMunicipios(int id)
        {
           

            return await _municipioRepository.Get(id);
        }
        
        [HttpPost]
        public async Task<ActionResult<Entidade>> CriarMunicipio()
        {
            if (!await _municipioRepository.Post()) return Problem();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Entidade>> AtualizarMunicipios(int id ,[FromBody] Entidade entidade)
        {
            if (id != entidade.Id)
                return BadRequest();
                await _municipioRepository.Put(entidade);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Entidade>> ExcluirMunicipio(int id)
        {
            var excluirMunicipio = await _municipioRepository.Get(id);
            if (excluirMunicipio == null)
                return NotFound();
            await _municipioRepository.Delete(excluirMunicipio.Id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Entidade>> ExcluirMunicipios()
        {
            if (!await _municipioRepository.Delete()) return Problem();

            return Ok();
           
        }
    }
}
