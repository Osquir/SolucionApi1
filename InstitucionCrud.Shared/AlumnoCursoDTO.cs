using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace InstitucionCrud.Shared
{
    public class AlumnoCursoDTO
    {
        public int IdAlumnoCurso { get; set; }
       
        public int? IdAlumno { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
        public int? IdCurso { get; set; }

        public DateTime? Año { get; set; } = null!;

        public AlumnoDTO? Alumno { get; set; }

        public CursoDTO? Curso{ get; set; }
      
    }
}
