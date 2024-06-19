using DigitalizacionAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalizacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrigenDocumentoController : ControllerBase
    {
        private readonly DigitalizacionContext _dbContextt;

        public OrigenDocumentoController(DigitalizacionContext context)
        {
            _dbContextt = context;
        }

        // GET: api/OrigenDocumento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrigenDocumento>>> GetOrigenDocumentos()
        {
            return await _dbContextt.OrigenDocumentos.ToListAsync();
        }

        // GET: api/OrigenDocumento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrigenDocumento>> GetOrigenDocumento(int id)
        {
            var origenDocumento = await _dbContextt.OrigenDocumentos.FindAsync(id);

            if (origenDocumento == null)
            {
                return NotFound();
            }

            return origenDocumento;
        }

        // POST: api/OrigenDocumento
        [HttpPost]
        public async Task<ActionResult<OrigenDocumento>> PostOrigenDocumento(OrigenDocumento origenDocumento)
        {
            _dbContextt.OrigenDocumentos.Add(origenDocumento);
            await _dbContextt.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrigenDocumento), new { id = origenDocumento.Id }, origenDocumento);
        }

        // PUT: api/OrigenDocumento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrigenDocumento(int id, OrigenDocumento origenDocumento)
        {
            if (id != origenDocumento.Id)
            {
                return BadRequest();
            }

            _dbContextt.Entry(origenDocumento).State = EntityState.Modified;

            try
            {
                await _dbContextt.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrigenDocumentoExists(id))
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

        // DELETE: api/OrigenDocumento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrigenDocumento(int id)
        {
            var origenDocumento = await _dbContextt.OrigenDocumentos.FindAsync(id);
            if (origenDocumento == null)
            {
                return NotFound();
            }

            _dbContextt.OrigenDocumentos.Remove(origenDocumento);
            await _dbContextt.SaveChangesAsync();

            return NoContent();
        }

        private bool OrigenDocumentoExists(int id)
        {
            return _dbContextt.OrigenDocumentos.Any(e => e.Id == id);
        }
    }
}