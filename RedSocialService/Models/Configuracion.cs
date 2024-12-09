using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedSocialServices.Models;

public partial class Configuracion
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Valor { get; set; } = null!;
    public bool Eliminado { get; set; } = false;
    public override string ToString() => $"{Nombre}, {Valor}";
}
