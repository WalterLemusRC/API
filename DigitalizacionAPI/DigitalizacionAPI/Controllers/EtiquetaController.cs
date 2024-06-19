using Microsoft.AspNetCore.Mvc;
using DigitalizacionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalizacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtiquetaController : ControllerBase
    {
        protected readonly DigitalizacionContext _dbContext;

        public EtiquetaController(DigitalizacionContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Etiquetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etiqueta>>> GetEtiquetas()
        {
            return await _dbContext.Etiqueta.ToListAsync();
        }

        // GET: api/Etiquetas/5
        [HttpGet("GetEtiqueta")]
        public async Task<ActionResult<Etiqueta>> GetEtiqueta(int id)
        {
            var etiqueta = await _dbContext.Etiqueta.FindAsync(id);

            if (etiqueta == null)
            {
                return NotFound();
            }

            return etiqueta;
        }

        // PUT: api/Etiquetas/5
        [HttpPut("PutEtiqueta")]
        public async Task<IActionResult> PutEtiqueta(int id, Etiqueta etiqueta)
        {
            if (id != etiqueta.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(etiqueta).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtiquetaExists(id))
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

        // POST: api/Etiquetas
        [HttpPost("PostEtiqueta")]
        public async Task<ActionResult<Etiqueta>> PostEtiqueta(Etiqueta etiqueta)
        {
            _dbContext.Etiqueta.Add(etiqueta);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEtiqueta), new { id = etiqueta.Id }, etiqueta);
        }

        // DELETE: api/Etiquetas/5
        [HttpDelete("DeleteEtiqueta")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            var etiqueta = await _dbContext.Etiqueta.FindAsync(id);
            if (etiqueta == null)
            {
                return NotFound();
            }

            _dbContext.Etiqueta.Remove(etiqueta);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool EtiquetaExists(int id)
        {
            return _dbContext.Etiqueta.Any(e => e.Id == id);
        }
    }
}
