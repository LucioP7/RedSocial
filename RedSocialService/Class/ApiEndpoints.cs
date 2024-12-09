using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialServices.Class
{
    public class ApiEndpoints
    {
        public static string Usuario { get; set; } = "Usuarios";
        public static string Publicacion { get; set; } = "Publicaciones";
        public static string Comentario { get; set; } = "Comentarios";
        public static string Like { get; set; } = "Likes";
        public static string Pais { get; set; } = "Paises";
        public static string Configuracion { get; set; } = "Configuraciones";
    

    public static string GetEndpoint(string name)
        {
            return name switch
            {
                nameof(Usuario) => Usuario,
                nameof(Publicacion) => Publicacion,
                nameof(Comentario) => Comentario,
                nameof(Like) => Like,
                nameof(Pais) => Pais,
                nameof(Configuracion) => Configuracion,
                _ => throw new ArgumentException($"Endpoint '{name}' no está definido.")
            };
        }
    }
}
