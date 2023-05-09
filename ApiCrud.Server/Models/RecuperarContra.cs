using System;
using System.Collections.Generic;

namespace ApiCrud.Server.Models;

public partial class RecuperarContra
{
    public int IdRcontra { get; set; }

    public int? IdUsuario { get; set; }

    public string? Token { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
