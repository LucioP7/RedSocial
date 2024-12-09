namespace RedSocialServices.Models;
public partial class Comentario
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public int PublicacionId { get; set; }
    public virtual Publicacion? Publicacion { get; set; }
    public string Contenido { get; set; } = null!;
    public DateTime Fecha { get; set; } = DateTime.Now;
    public bool Eliminado { get; set; } = false;
    public override string ToString() => Contenido;
}

