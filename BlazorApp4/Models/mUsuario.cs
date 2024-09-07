using System;
using System.Collections.Generic;

namespace BlazorApp4.Models;

public partial class mUsuario
{
    public int Usuarioid { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int Departamento { get; set; }

    public int Sueldo { get; set; }

    public DateTime? Fecharegistro { get; set; }

    public virtual mDepartamento DepartamentoNavigation { get; set; } = null!;
}
