using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{
    [Route("/api/servicetypes")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public ServiceTypeController(DataContext context)
        {
            _context = context;
        }

        // Select * from ServiceTypes
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.ServiceTypes.ToListAsync());
        }

        // Select * from ServiceTypes Where Id=""
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var serviceType = await _context.ServiceTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (serviceType == null)
            {
                return NotFound();
            }

            return Ok(serviceType);
        }

        // Insert into ServiceTypes values (...)
        [HttpPost]
        public async Task<ActionResult> Post(ServiceType serviceType)
        {
            _context.ServiceTypes.Add(serviceType);
            await _context.SaveChangesAsync();
            return Ok(serviceType); //200
        }

        // Update ServiceTypes set ... Where ...
        [HttpPut]
        public async Task<ActionResult> Put(ServiceType serviceType)
        {
            _context.ServiceTypes.Update(serviceType);
            await _context.SaveChangesAsync();
            return Ok(serviceType); //200
        }

        // Delete from ServiceTypes Where Id=""
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAfectadas = await _context.ServiceTypes
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