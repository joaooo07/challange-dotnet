using CP2.API.Application.Interfaces;
using CP2.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CP2.API.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly IMotoService _svc;
        public MotoController(IMotoService svc) => _svc = svc;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? marca, [FromQuery] int? ano)
            => Ok(await _svc.GetAllAsync(marca, ano));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var m = await _svc.GetByIdAsync(id);
            if (m is null) return NotFound();
            return Ok(m);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Moto moto)
        {
            await _svc.AddAsync(moto);
            return CreatedAtAction(nameof(Get), new { id = moto.Id }, moto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Moto moto)
        {
            if (id != moto.Id) return BadRequest();
            if (await _svc.GetByIdAsync(id) is null) return NotFound();
            await _svc.UpdateAsync(moto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _svc.GetByIdAsync(id) is null) return NotFound();
            await _svc.DeleteAsync(id);
            return NoContent();
        }
    }
}
