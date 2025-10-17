using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{
    [Route("/api/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {

        private readonly DataContext _context;

        public PetController(DataContext context)
        {

            _context = context;



        }

        // Select * from pets
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Pets.ToListAsync());

        }


        // Select * from pets Where Id=""
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);
            if (pet == null)
            {
                return NotFound();

            }

            return Ok(pet);


        }

        //Insert into ... values
        [HttpPost]
        public async Task<ActionResult> Post(Pet pet)
        {

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return Ok(pet);//200

        }

        //Update Table set Where
        [HttpPut]
        public async Task<ActionResult> Put(Pet pet)
        {

            _context.Pets.Update(pet);
            await _context.SaveChangesAsync();
            return Ok(pet); //200

        }

        // Delete from Table Where
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Pets
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (FilasAfectadas == 0)
            {

                return NotFound(); //404

            }

            return NoContent();//204

        }
    }

}