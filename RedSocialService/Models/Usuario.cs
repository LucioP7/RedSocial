using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedSocialServices.Models;

public partial class Usuario
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Debes asignar un nombre")]
    public string NombreReal { get; set; } = null!;
    [Required(ErrorMessage = "Debes asignar un apodo")]
    public string NombreApodo { get; set; } = null!;
    public string Telefono { get; set; } = null!;

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FechaNacimiento { get; set; } 

    public int? PaisId { get; set; }
    [Required(ErrorMessage = "Debes asignar un pais")]
    public virtual Pais? Pais { get; set; }
    public bool Baneado { get; set; } = false;
    public bool Eliminado { get; set; } = false;

    public override string ToString()
    {
        return $"{NombreReal}, {NombreApodo}";
    }
}
