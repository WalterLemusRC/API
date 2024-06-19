using Microsoft.AspNetCore.Mvc;
using DigitalizacionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalizacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriumController : ControllerBase
    {
        private readonly DigitalizacionContext _dbContext;

        public AuditoriumController(DigitalizacionContext context)
        {
            _dbContext = context;
        }

        // GET: api/Auditorium
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auditorium>>> GetAuditoriums()
        {
            return await _dbContext.Auditoria.ToListAsync();
        }

        // GET: api/Auditorium/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auditorium>> GetAuditorium(int id)
        {
            var auditorium = await _dbContext.Auditoria.FindAsync(id);

            if (auditorium == null)
            {
                return NotFound();
            }

            return auditorium;
        }

        // POST: api/Auditorium
        [HttpPost]
        public async Task<ActionResult<Auditorium>> PostAuditorium(Auditorium auditorium)
        {
            _dbContext.Auditoria.Add(auditorium);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuditorium), new { id = auditorium.Id }, auditorium);
        }

        // PUT: api/Auditorium/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditorium(int id, Auditorium auditorium)
        {
            if (id != auditorium.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(auditorium).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditoriumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Auditorium/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuditorium(int id)
        {
            var auditorium = await _dbContext.Auditoria.FindAsync(id);
            if (auditorium == null)
            {
                return NotFound();
            }

            _dbContext.Auditoria.Remove(auditorium);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool AuditoriumExists(int id)
        {
            return _dbContext.Auditoria.Any(e => e.Id == id);
        }
    }
}
