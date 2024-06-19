using System;
using System.Collections.Generic;

namespace DigitalizacionAPI.Models;

public partial class Etiqueta
{
    public int Id { get; set; } 

    public string Nombre { get; set; } 
    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
}
