using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{
    [Route("/api/pettypes")]
    [ApiController]
    public class PetTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public PetTypeController(DataContext context)
        {
            _context = context;
        }

        // Select * from PetTypes
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.PetTypes.ToListAsync());
        }

        // Select * from PetTypes Where Id=""
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var petType = await _context.PetTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (petType == null)
            {
                return NotFound();
            }

            return Ok(petType);
        }

        // Insert into PetTypes values (...)
        [HttpPost]
        public async Task<ActionResult> Post(PetType petType)
        {
            _context.PetTypes.Add(petType);
            await _context.SaveChangesAsync();
            return Ok(petType); //200
        }

        // Update PetTypes set ... Where ...
        [HttpPut]
        public async Task<ActionResult> Put(PetType petType)
        {
            _context.PetTypes.Update(petType);
            await _context.SaveChangesAsync();
            return Ok(petType); //200
        }

        // Delete from PetTypes Where Id=""
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAfectadas = await _context.PetTypes
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