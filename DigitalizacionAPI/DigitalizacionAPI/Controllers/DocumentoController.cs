using Microsoft.AspNetCore.Mvc;
using DigitalizacionAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace DigitalizacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {

        protected readonly DigitalizacionContext _dbContext;

        public DocumentoController(DigitalizacionContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Documentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documento>>> GetDocumentos()
        {
            return await _dbContext.Documentos.ToListAsync();
        }

        // GET: api/Documentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Documento>> GetDocumento(int id)
        {
            var documento = await _dbContext.Documentos.FindAsync(id);

            if (documento == null)
            {
                return NotFound();
            }

            return documento;
        }

        // PUT: api/Documentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumento(int id, Documento documento)
        {
            if (id != documento.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(documento).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentoExists(id))
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

        // POST: api/Documentos
        [HttpPost]
        public async Task<ActionResult<Documento>> PostDocumento(Documento documento)
        {
            _dbContext.Documentos.Add(documento);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDocumento), new { id = documento.Id }, documento);
        }

        // DELETE: api/Documentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumento(int id)
        {
            var documento = await _dbContext.Documentos.FindAsync(id);
            if (documento == null)
            {
                return NotFound();
            }

            _dbContext.Documentos.Remove(documento);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentoExists(int id)
        {
            return _dbContext.Documentos.Any(e => e.Id == id);
        }
    }
}
