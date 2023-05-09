using System;
using System.Collections.Generic;

namespace ApiCrud.Server.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string? PrimerNombre { get; set; }

    public string? SegundoNombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public string? Codigo { get; set; }

    public virtual ICollection<AlumnoCurso> AlumnoCursos { get; } = new List<AlumnoCurso>();
}
