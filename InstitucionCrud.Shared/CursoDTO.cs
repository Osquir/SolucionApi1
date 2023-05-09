using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitucionCrud.Shared
{
   public class CursoDTO
    {
        public int IdCurso { get; set; }

        [Required(ErrorMessage = "El campo{0} es requerido")]
        public string Codigo { get; set; } = null!;

        [Required(ErrorMessage = "El campo{0} es requerido")]
        public string NombreCurso { get; set; } = null!;

        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="El campo{0} es requerido")]
        public int Creditos { get; set; }

        public string? Descripcion { get; set; }

        public string? Temario { get; set; }

    }
}
