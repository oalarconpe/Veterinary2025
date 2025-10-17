using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{
    [Route("/api/agendas")]
    [ApiController]
    public class AgendasController : ControllerBase
    {
        private readonly DataContext _context;

        public AgendasController(DataContext context)
        {
            _context = context;
        }

        // Select * from Agendas
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Agendas.ToListAsync());
        }

        // Select * from Agendas Where Id=""
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var agenda = await _context.Agendas.FirstOrDefaultAsync(x => x.Id == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return Ok(agenda);
        }

        // Insert into Agendas values (...)
        [HttpPost]
        public async Task<ActionResult> Post(Agenda agenda)
        {
            _context.Agendas.Add(agenda);
            await _context.SaveChangesAsync();
            return Ok(agenda); //200
        }

        // Update Agendas set ... Where ...
        [HttpPut]
        public async Task<ActionResult> Put(Agenda agenda)
        {
            _context.Agendas.Update(agenda);
            await _context.SaveChangesAsync();
            return Ok(agenda); //200
        }

        // Delete from Agendas Where Id=""
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAfectadas = await _context.Agendas
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (filasAfectadas == 0)
            {
                return NotFound(); //404
            }

            return NoContent(); //204
        }
    }
}