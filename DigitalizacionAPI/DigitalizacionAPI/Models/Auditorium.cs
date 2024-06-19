using System;
using System.Collections.Generic;

namespace DigitalizacionAPI.Models;

public partial class Auditorium
{
    public int Id { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string Transaccion { get; set; } = null!;

    public byte[] Anterior { get; set; } = null!;

    public byte[] Actual { get; set; } = null!;

    public string Usuario { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public int IdDocumento { get; set; }

    public virtual Documento IdDocumentoNavigation { get; set; } = null!;
}
