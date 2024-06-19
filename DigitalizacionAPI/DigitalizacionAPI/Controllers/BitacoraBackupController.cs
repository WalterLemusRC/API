using DigitalizacionAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace DigitalizacionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BitacoraBackupController : ControllerBase
    {
        private readonly List<BitacoraBackup> _bitacoraBackups = new List<BitacoraBackup>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bitacoraBackups);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bitacoraBackup = _bitacoraBackups.FirstOrDefault(b => b.Id == id);
            if (bitacoraBackup == null)
            {
                return NotFound();
            }
            return Ok(bitacoraBackup);
        }

        [HttpPost]
        public IActionResult Create(BitacoraBackup bitacoraBackup)
        {
            // You might want to add some validation here before adding the bitacoraBackup to the list
            _bitacoraBackups.Add(bitacoraBackup);
            return CreatedAtAction(nameof(GetById), new { id = bitacoraBackup.Id }, bitacoraBackup);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BitacoraBackup updatedBitacoraBackup)
        {
            var existingBitacoraBackup = _bitacoraBackups.FirstOrDefault(b => b.Id == id);
            if (existingBitacoraBackup == null)
            {
                return NotFound();
            }

            // You might want to add some validation here before updating the bitacoraBackup
            existingBitacoraBackup.Ruta = updatedBitacoraBackup.Ruta;
            existingBitacoraBackup.NombreArchivo = updatedBitacoraBackup.NombreArchivo;
            existingBitacoraBackup.FechaCreacion = updatedBitacoraBackup.FechaCreacion;
            existingBitacoraBackup.Estado = updatedBitacoraBackup.Estado;
            existingBitacoraBackup.LogDeError = updatedBitacoraBackup.LogDeError;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bitacoraBackupToRemove = _bitacoraBackups.FirstOrDefault(b => b.Id == id);
            if (bitacoraBackupToRemove == null)
            {
                return NotFound();
            }
            _bitacoraBackups.Remove(bitacoraBackupToRemove);
            return NoContent();
        }
    }
}
