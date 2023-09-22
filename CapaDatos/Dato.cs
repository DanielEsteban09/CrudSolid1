using System;
using System.Collections.Generic;

namespace CapaDatos;

public partial class Dato
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int Telefono { get; set; }

    public string Profesion { get; set; } = null!;

    public int Edad { get; set; }
}
