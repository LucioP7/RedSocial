namespace RedSocialServices.Models;
public partial class Like
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public int PublicacionId { get; set; }
    public virtual Publicacion? Publicacion { get; set; }
    public bool Eliminado { get; set; } = false;
    public override string ToString() => $"{Usuario}, {Publicacion}";
}

