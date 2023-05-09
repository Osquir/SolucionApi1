using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace InstitucionCrud.Shared
{
    public class AlumnoDTO
    {
        [Required(ErrorMessage = "El campo{0} es requerido")]
        public int IdAlumno { get; set; }

        [Required(ErrorMessage = "El campo{0} es requerido")]
        public string PrimerNombre { get; set; } = null!;

        public string? SegundoNombre { get; set; }

        [Required(ErrorMessage = "El campo{0} es requerido")]
        public string PrimerApellido { get; set; } = null!;

        public string? SegundoApellido { get; set; }

        [Required(ErrorMessage = "El campo{0} es requerido")]
        public string Codigo { get; set; } = null!;

    }
}
