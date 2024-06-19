using DigitalizacionAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalizacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosHistoricoController : ControllerBase
    {

        protected readonly DigitalizacionContext _dbContext;

        public DocumentosHistoricoController(DigitalizacionContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/DocumentosHistoricos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentosHistorico>>> GetDocumentosHistoricos()
        {
            return await _dbContext.DocumentosHistoricos.ToListAsync();
        }

        // GET: api/DocumentosHistoricos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentosHistorico>> GetDocumentosHistorico(int id)
        {
            var DocumentosHistorico = await _dbContext.DocumentosHistoricos.FindAsync(id);

            if (DocumentosHistorico == null)
            {
                return NotFound();
            }

            return DocumentosHistorico;
        }

        // PUT: api/DocumentosHistoricos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentosHistorico(int id, DocumentosHistorico DocumentosHistorico)
        {
            if (id != DocumentosHistorico.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(DocumentosHistorico).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentosHistoricoExists(id))
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

        // POST: api/DocumentosHistoricos
        [HttpPost]
        public async Task<ActionResult<DocumentosHistorico>> PostDocumentosHistorico(DocumentosHistorico DocumentosHistorico)
        {
            _dbContext.DocumentosHistoricos.Add(DocumentosHistorico);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDocumentosHistorico), new { id = DocumentosHistorico.Id }, DocumentosHistorico);
        }

        // DELETE: api/DocumentosHistoricos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentosHistorico(int id)
        {
            var DocumentosHistorico = await _dbContext.DocumentosHistoricos.FindAsync(id);
            if (DocumentosHistorico == null)
            {
                return NotFound();
            }

            _dbContext.DocumentosHistoricos.Remove(DocumentosHistorico);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentosHistoricoExists(int id)
        {
            return _dbContext.DocumentosHistoricos.Any(e => e.Id == id);
        }
    }
}

