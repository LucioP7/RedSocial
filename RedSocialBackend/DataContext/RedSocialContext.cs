using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Microsoft.Extensions.Configuration;
using RedSocialServices.Models;

namespace RedSocialBackend.DataContext;

public partial class RedSocialContext : DbContext
{
    public RedSocialContext()
    {
    }

    public RedSocialContext(DbContextOptions<RedSocialContext> options)
        : base(options)
    {
    }

    //Code firts
    // dotnet tool install --global dotnet-ef
    // dotnet ef migrations add Inicio
    // dotnet ef database update

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Publicacion> Publicaciones { get; set; }
    public virtual DbSet<Comentario> Comentarios { get; set; }
    public virtual DbSet<Like> Likes { get; set; }
    public virtual DbSet<DisLike> DisLikes { get; set; }
    public virtual DbSet<Pais> Paises { get; set; }
    public virtual DbSet<Configuracion> Configuraciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        string? cadenaConexion = configuration.GetConnectionString("mysqlRemoto");

        optionsBuilder.UseMySql(cadenaConexion, ServerVersion.AutoDetect(cadenaConexion));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region  Datos semilla
        // Carga de datos semilla
        modelBuilder.Entity<Usuario>().HasData(
            new Usuario
            {
                Id = 1,
                NombreReal = "Juan Perez",
                NombreApodo = "juanperez",
                Telefono = "123456789",
                FechaNacimiento = new DateTime(1990, 1, 1),
                PaisId = 1,
                Eliminado = false,
                Baneado = false
            },
            new Usuario
            {
                Id = 2,
                NombreReal = "Maria Lopez",
                NombreApodo = "marialopez",
                Telefono = "987654321",
                FechaNacimiento = new DateTime(1995, 1, 1),
                PaisId = 2,
                Eliminado = false,
                Baneado = false
            },
            new Usuario
            {
                Id = 3,
                NombreReal = "Pedro Ramirez",
                NombreApodo = "pedroramirez",
                Telefono = "456789123",
                FechaNacimiento = new DateTime(1998, 1, 1),
                PaisId = 3,
                Eliminado = false,
                Baneado = false
            },
            new Usuario
            {
                Id = 4,
                NombreReal = "Ana Garcia",
                NombreApodo = "anagarcia",
                Telefono = "789123456",
                FechaNacimiento = new DateTime(2000, 1, 1),
                PaisId = 4,
                Eliminado = false,
                Baneado = false
            },
            new Usuario
            {
                Id = 5,
                NombreReal = "Carlos Rodriguez",
                NombreApodo = "carlosrodriguez",
                Telefono = "321654987",
                FechaNacimiento = new DateTime(2005, 1, 1),
                PaisId = 5,
                Eliminado = false,
                Baneado = false
            });
        modelBuilder.Entity<Publicacion>().HasData(
            new Publicacion
            {
                Id = 1,
                Fecha = new DateTime(2021, 1, 1),
                Contenido = "Publicacion 1",
                UsuarioId = 1,
                Eliminado = false
            },
            new Publicacion
            {
                Id = 2,
                Fecha = new DateTime(2021, 1, 2),
                Contenido = "Publicacion 2",
                UsuarioId = 2,
                Eliminado = false
            },
            new Publicacion
            {
                Id = 3,
                Fecha = new DateTime(2021, 1, 3),
                Contenido = "Publicacion 3",
                UsuarioId = 3,
                Eliminado = false
            },
            new Publicacion
            {
                Id = 4,
                Fecha = new DateTime(2021, 1, 4),
                Contenido = "Publicacion 4",
                UsuarioId = 4,
                Eliminado = false
            },
            new Publicacion
            {
                Id = 5,
                Fecha = new DateTime(2021, 1, 5),
                Contenido = "Publicacion 5",
                UsuarioId = 5,
                Eliminado = false
            });
        modelBuilder.Entity<Comentario>().HasData(
            new Comentario
            {
                Id = 1,
                Fecha = new DateTime(2021, 1, 1),
                Contenido = "Comentario 1",
                UsuarioId = 1,
                PublicacionId = 1,
                Eliminado = false
            },
            new Comentario
            {
                Id = 2,
                Fecha = new DateTime(2021, 1, 2),
                Contenido = "Comentario 2",
                UsuarioId = 2,
                PublicacionId = 2,
                Eliminado = false
            },
            new Comentario
            {
                Id = 3,
                Fecha = new DateTime(2021, 1, 3),
                Contenido = "Comentario 3",
                UsuarioId = 3,
                PublicacionId = 3,
                Eliminado = false
            },
            new Comentario
            {
                Id = 4,
                Fecha = new DateTime(2021, 1, 4),
                Contenido = "Comentario 4",
                UsuarioId = 4,
                PublicacionId = 4,
                Eliminado = false
            },
            new Comentario
            {
                Id = 5,
                Fecha = new DateTime(2021, 1, 5),
                Contenido = "Comentario 5",
                UsuarioId = 5,
                PublicacionId = 5,
                Eliminado = false
            });
        modelBuilder.Entity<Like>().HasData(
            new { Id = 1, UsuarioId = 1, PublicacionId = 1, Eliminado = false },
            new { Id = 2, UsuarioId = 2, PublicacionId = 2, Eliminado = false },
            new { Id = 3, UsuarioId = 3, PublicacionId = 3, Eliminado = false },
            new { Id = 4, UsuarioId = 4, PublicacionId = 4, Eliminado = false },
            new { Id = 5, UsuarioId = 5, PublicacionId = 5, Eliminado = false },
            new { Id = 6, UsuarioId = 2, PublicacionId = 5, Eliminado = false },
            new { Id = 7, UsuarioId = 3, PublicacionId = 2, Eliminado = false },
            new { Id = 8, UsuarioId = 4, PublicacionId = 3, Eliminado = false },
            new { Id = 9, UsuarioId = 5, PublicacionId = 1, Eliminado = false },
            new { Id = 10, UsuarioId = 1, PublicacionId = 4, Eliminado = false });
        modelBuilder.Entity<Pais>().HasData(
            new Pais { Id = 1, Nombre = "Argentina", Eliminado = false },
            new Pais { Id = 2, Nombre = "Brasil", Eliminado = false },
            new Pais { Id = 3, Nombre = "Chile", Eliminado = false },
            new Pais { Id = 4, Nombre = "Uruguay", Eliminado = false },
            new Pais { Id = 5, Nombre = "Paraguay", Eliminado = false });
        modelBuilder.Entity<Configuracion>().HasData(
            new Configuracion { Id = 1, Nombre = "Configuracion 1", Valor = "Valor 1", Eliminado = false },
            new Configuracion { Id = 2, Nombre = "Configuracion 2", Valor = "Valor 2", Eliminado = false },
            new Configuracion { Id = 3, Nombre = "Configuracion 3", Valor = "Valor 3", Eliminado = false },
            new Configuracion { Id = 4, Nombre = "Configuracion 4", Valor = "Valor 4", Eliminado = false },
            new Configuracion { Id = 5, Nombre = "Configuracion 5", Valor = "Valor 5", Eliminado = false });
        modelBuilder.Entity<DisLike>().HasData(
            new { Id = 1, UsuarioId = 1, PublicacionId = 1, Eliminado = false },
            new { Id = 2, UsuarioId = 2, PublicacionId = 2, Eliminado = false },
            new { Id = 3, UsuarioId = 3, PublicacionId = 3, Eliminado = false },
            new { Id = 4, UsuarioId = 4, PublicacionId = 4, Eliminado = false },
            new { Id = 5, UsuarioId = 5, PublicacionId = 5, Eliminado = false },
            new { Id = 6, UsuarioId = 2, PublicacionId = 5, Eliminado = false },
            new { Id = 7, UsuarioId = 3, PublicacionId = 2, Eliminado = false },
            new { Id = 8, UsuarioId = 4, PublicacionId = 3, Eliminado = false },
            new { Id = 9, UsuarioId = 5, PublicacionId = 1, Eliminado = false },
            new { Id = 10, UsuarioId = 1, PublicacionId = 4, Eliminado = false });
        #endregion

        #region definición de filtros de eliminación
        // (este código no lo habilitamos todavía porque es cuando agregamos un campo Eliminado a las tablas y modificamos los
        // ApiControllers para que al mandar a eliminar solo cambien este campo y lo pongan en verdadero, esta configuración de
        // eliminación hace que el sistema ignore los registros que tengan el eliminado en verdadero, así que hace que en
        // apariencia y funcionalidad esté "eliminado", pero van a seguir estando ahí para que podamos observar las eliminaciones que hubo)
        modelBuilder.Entity<Usuario>().HasQueryFilter(m => !m.Eliminado);
        modelBuilder.Entity<Publicacion>().HasQueryFilter(m => !m.Eliminado);
        modelBuilder.Entity<Comentario>().HasQueryFilter(m => !m.Eliminado);
        modelBuilder.Entity<Like>().HasQueryFilter(m => !m.Eliminado);
        modelBuilder.Entity<DisLike>().HasQueryFilter(m => !m.Eliminado);
        modelBuilder.Entity<Pais>().HasQueryFilter(m => !m.Eliminado);
        modelBuilder.Entity<Configuracion>().HasQueryFilter(m => !m.Eliminado);
        #endregion
    }

}