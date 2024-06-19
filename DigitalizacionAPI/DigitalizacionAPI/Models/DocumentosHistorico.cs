using System;
using System.Collections.Generic;

namespace DigitalizacionAPI.Models;

public partial class DocumentosHistorico
{
    public int Id { get; set; }

    public string NombreArchivo { get; set; } = null!;

    public byte[] Contenido { get; set; } = null!;

    public int Tamaño { get; set; }

    public string Extension { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int IdEstado { get; set; }

    public int IdTipo { get; set; }

    public int IdOrigen { get; set; }

    public bool Borrado { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual OrigenDocumento IdOrigenNavigation { get; set; } = null!;

    public virtual TiposDocumento IdTipoNavigation { get; set; } = null!;
}
