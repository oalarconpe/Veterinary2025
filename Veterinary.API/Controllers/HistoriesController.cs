using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{
    [Route("/api/histories")]
    [ApiController]
    public class HistoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public HistoriesController(DataContext context)
        {
            _context = context;
        }

        // Select * from Histories
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Histories.ToListAsync());
        }

        // Select * from Histories Where Id=""
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var history = await _context.Histories.FirstOrDefaultAsync(x => x.Id == id);
            if (history == null)
            {
                return NotFound();
            }

            return Ok(history);
        }

        // Insert into Histories values (...)
        [HttpPost]
        public async Task<ActionResult> Post(History history)
        {
            _context.Histories.Add(history);
            await _context.SaveChangesAsync();
            return Ok(history); //200
        }

        // Update Histories set ... Where ...
        [HttpPut]
        public async Task<ActionResult> Put(History history)
        {
            _context.Histories.Update(history);
            await _context.SaveChangesAsync();
            return Ok(history); //200
        }

        // Delete from Histories Where Id=""
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAfectadas = await _context.Histories
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