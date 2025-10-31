using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("/api/owners")]
    public class OwnersController:ControllerBase
    {

        private readonly DataContext _context;

        public OwnersController(DataContext context)
        {

            _context = context; 
                
        }



        // Get para obtoner una lista de resultados
        // Select * from table
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await  _context.Owners.ToListAsync());

        }



        //Get por parámetro
        //Select* from table Where Id=...

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var owner=await _context.Owners.FirstOrDefaultAsync(x=>x.Id==id);

            if (owner == null)
            {



                return NotFound();
            }

            return Ok(owner);




        }


        //Insert into ... values
        [HttpPost]
        public async Task<ActionResult> Post(Owner owner)
        {

            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);//200

        }
        //Update Table set Where
        [HttpPut]
        public async Task<ActionResult> Put(Owner owner)
        {

            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
            return Ok(owner); //200

        }

        // Delete from Table Where
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Owners
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

