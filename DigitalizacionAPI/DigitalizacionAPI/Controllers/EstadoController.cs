using Microsoft.AspNetCore.Mvc;
using DigitalizacionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalizacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        protected readonly DigitalizacionContext _dbContext;

    public EstadosController(DigitalizacionContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET: api/Estados
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
    {
        return await _dbContext.Estados.ToListAsync();
    }

    // GET: api/Estados/5
    [HttpGet("GetEstado")]
    public async Task<ActionResult<Estado>> GetEstado(int id)
    {
        var estado = await _dbContext.Estados.FindAsync(id);

        if (estado == null)
        {
            return NotFound();
        }

        return estado;
    }

    // PUT: api/Estados/5
    [HttpPut("PutEstado")]
    public async Task<IActionResult> PutEstado(int id, Estado estado)
    {
        if (id != estado.Id)
        {
            return BadRequest();
        }

        _dbContext.Entry(estado).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EstadoExists(id))
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

    // POST: api/Estados
    [HttpPost("PostEstado")]
    public async Task<ActionResult<Estado>> PostEstado(Estado estado)
    {
        _dbContext.Estados.Add(estado);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEstado), new { id = estado.Id }, estado);
    }

    // DELETE: api/Estados/5
    [HttpDelete("DeleteEstado")]
    public async Task<IActionResult> DeleteEstado(int id)
    {
        var estado = await _dbContext.Estados.FindAsync(id);
        if (estado == null)
        {
            return NotFound();
        }

        _dbContext.Estados.Remove(estado);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    private bool EstadoExists(int id)
    {
        return _dbContext.Estados.Any(e => e.Id == id);
    }
}
}
