using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedSocialServices.Models;

public partial class Publicacion
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public string Contenido { get; set; } = null!;
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Fecha { get; set; } = DateTime.Now;
    public bool Eliminado { get; set; } = false;
    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
    public virtual ICollection<DisLike> DisLikes { get; set; } = new List<DisLike>();
    [NotMapped]
    public int LikesCount => Likes.Count;
    [NotMapped]
    public int DisLikesCount => DisLikes.Count;
    [NotMapped]
    public int ComentariosCount => Comentarios.Count;
    public override string ToString() => Contenido;
}
//dotnet ef database update
//dotnet ef migrations add<NombreDeLaMigracion>
