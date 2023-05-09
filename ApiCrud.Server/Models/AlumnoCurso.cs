using System;
using System.Collections.Generic;

namespace ApiCrud.Server.Models;

public partial class AlumnoCurso
{
    public int IdAlumnoCurso { get; set; }

    public int? IdAlumno { get; set; }

    public int? IdCurso { get; set; }

    public DateTime? Año { get; set; }

    public virtual Alumno? IdAlumnoNavigation { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; }
}
