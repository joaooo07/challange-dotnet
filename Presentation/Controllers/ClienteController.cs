using CP2.API.Application.Interfaces;
using CP2.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CP2.API.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _svc;
        public ClienteController(IClienteService svc) => _svc = svc;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? nome)
            => Ok(await _svc.GetAllAsync(nome));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var c = await _svc.GetByIdAsync(id);
            if (c is null) return NotFound();
            return Ok(c);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            await _svc.AddAsync(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id) return BadRequest();
            if (await _svc.GetByIdAsync(id) is null) return NotFound();
            await _svc.UpdateAsync(cliente);
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
