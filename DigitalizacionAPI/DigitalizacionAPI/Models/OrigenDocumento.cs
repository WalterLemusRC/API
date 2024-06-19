using System;
using System.Collections.Generic;

namespace DigitalizacionAPI.Models;

public partial class OrigenDocumento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();

    public virtual ICollection<DocumentosHistorico> DocumentosHistoricos { get; set; } = new List<DocumentosHistorico>();
}
