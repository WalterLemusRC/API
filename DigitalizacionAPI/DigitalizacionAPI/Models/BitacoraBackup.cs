using System;
using System.Collections.Generic;

namespace DigitalizacionAPI.Models;

public partial class BitacoraBackup
{
    public int Id { get; set; }

    public string Ruta { get; set; } = null!;

    public string NombreArchivo { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public string Estado { get; set; } = null!;

    public string LogDeError { get; set; } = null!;
}
