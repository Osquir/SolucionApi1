using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitucionCrud.Shared
{
    public class RecuperarContraDTO
    {
        public int IdRcontra { get; set; }

        public int IdUsuario { get; set; }

        public string? Token { get; set; }
    }
}
