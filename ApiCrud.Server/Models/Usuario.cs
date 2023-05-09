using System;
using System.Collections.Generic;

namespace ApiCrud.Server.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Usuario1 { get; set; }

    public string Nombre { get; set; }

    public string Correo { get; set; }

    public string Contra { get; set; }

    public virtual ICollection<RecuperarContra> RecuperarContras { get; } = new List<RecuperarContra>();

    public virtual ICollection<UsuarioRol> UsuarioRols { get; } = new List<UsuarioRol>();
}
