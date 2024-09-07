using System;
using System.Collections.Generic;

namespace BlazorApp4.Models;

public class mDepartamento
{
    public int Departamentoid { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<mUsuario> Usuarios { get; set; } = [];
}
