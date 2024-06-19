using DigitalizacionAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalizacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDocumentoController : ControllerBase
    {
        private readonly DigitalizacionContext _dbContext;

        public TiposDocumentoController(DigitalizacionContext context)
        {
            _dbContext = context;
        }

        // GET: api/TiposDocumento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposDocumento>>> GetTiposDocumentos()
        {
            return await _dbContext.TiposDocumentos.ToListAsync();
        }

        // GET: api/TiposDocumento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposDocumento>> GetTiposDocumento(int id)
        {
            var TiposDocumento = await _dbContext.TiposDocumentos.FindAsync(id);

            if (TiposDocumento == null)
            {
                return NotFound();
            }

            return TiposDocumento;
        }

        // POST: api/TiposDocumento
        [HttpPost]
        public async Task<ActionResult<TiposDocumento>> PostTiposDocumento(TiposDocumento TiposDocumento)
        {
            _dbContext.TiposDocumentos.Add(TiposDocumento);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTiposDocumento), new { id = TiposDocumento.Id }, TiposDocumento);
        }

        // PUT: api/TiposDocumento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposDocumento(int id, TiposDocumento TiposDocumento)
        {
            if (id != TiposDocumento.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(TiposDocumento).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposDocumentoExists(id))
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

        // DELETE: api/TiposDocumento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposDocumento(int id)
        {
            var TiposDocumento = await _dbContext.TiposDocumentos.FindAsync(id);
            if (TiposDocumento == null)
            {
                return NotFound();
            }

            _dbContext.TiposDocumentos.Remove(TiposDocumento);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposDocumentoExists(int id)
        {
            return _dbContext.TiposDocumentos.Any(e => e.Id == id);
        }
    }
}
