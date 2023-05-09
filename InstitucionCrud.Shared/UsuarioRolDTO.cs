using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace InstitucionCrud.Shared
{
    public class UsuarioRolDTO
    {
        public int IdUsuarioRol { get; set; }

        public int UsuarioId { get; set; }

        public int RolId { get; set; }
        
        public UsuarioDTO? Usuarios { get; set; }

        public RolDTO? Rols { get; set; }
    }
}
