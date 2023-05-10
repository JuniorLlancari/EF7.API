using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;

namespace EF7.API.Entidades.Seeding
{
    public class SeedingInicial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {

            var listaGeneros = new List<Genero>()
            {
                 new Genero { Id = 1, Nombre = "Ciencia Ficción" },
                 new Genero { Id = 2, Nombre = "Animación" }
            };
            modelBuilder.Entity<Genero>().HasData(listaGeneros);



            var listaActores = new List<Actor>()
            {
                new Actor()
                {
                    Id = 1,
                    Nombre = "Samuel L. Jackson",
                    FechaNacimiento = new DateTime(1948, 12, 21),
                    Fortuna = 15000
                },new Actor()
                {
                    Id = 2,
                    Nombre = "Robert Downey Jr.",
                    FechaNacimiento = new DateTime(1965, 4, 4),
                    Fortuna = 18000
                }
            };
            modelBuilder.Entity<Actor>().HasData(listaActores);
             
            var listaPeliculas = new List<Pelicula>(){
                new Pelicula()
                {
                    Id = 1,
                    Titulo = "Avengers Endgame",
                    EnCines=true,
                    FechaEstreno = new DateTime(2019, 4, 22)
                },
                new Pelicula()
                {
                    Id = 2,
                    Titulo = "Spider-Man: No Way Home",
                    EnCines=true,
                    FechaEstreno = new DateTime(2021, 12, 13)
                },
                new Pelicula()
                {
                    Id = 3,
                    Titulo = "Spider-Man: Across the Spider-Verse (Part One)",
                    EnCines=true,
                    FechaEstreno = new DateTime(2022, 10, 7)
                }
            };
            modelBuilder.Entity<Pelicula>().HasData(listaPeliculas);

 
 
 
           
            var listaComentarios = new List<Comentario>()
            {
                new Comentario()
                {
                    Id = 1,
                    Recomendar = true,
                    Contenido = "Muy buena!!!",
                    PeliculaId = listaPeliculas[0].Id
                },
                new Comentario()
                {
                    Id = 2,
                    Recomendar = true,
                    Contenido = "Dura dura",
                    PeliculaId = listaPeliculas[0].Id
                },
                new Comentario()
                {
                    Id = 3,
                    Recomendar = false,
                    Contenido = "no debieron hacer eso...",
                    PeliculaId = listaPeliculas[1].Id
                }
            };
            modelBuilder.Entity<Comentario>().HasData(listaComentarios);


             

            // muchos a muchos con salto (esto es poquito avanzado)

            var tablaGeneroPelicula = "GeneroPelicula";
            var generoIdPropiedad = "GenerosId";
            var peliculaIdPropiedad = "PeliculasId";

            var cienciaFiccion = listaGeneros[0].Id;
            var animacion = listaGeneros[1].Id;

            List<Dictionary<string, object>> itemsGeneroPelicula = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>
                {
                    [generoIdPropiedad] = cienciaFiccion,
                    [peliculaIdPropiedad] = listaPeliculas[0].Id
                },

                new Dictionary<string, object>
                {
                    [generoIdPropiedad] = cienciaFiccion,
                    [peliculaIdPropiedad] = listaPeliculas[1].Id
                },

                new Dictionary<string, object>
                {
                    [generoIdPropiedad] = animacion,
                    [peliculaIdPropiedad] = listaPeliculas[1].Id
                }
             };


            modelBuilder.Entity(tablaGeneroPelicula).HasData(itemsGeneroPelicula);

            // muchos a muchos sin salto

            List<PeliculaActor> listapeliculaActores = new List<PeliculaActor>()
            {
                new PeliculaActor
                {
                    ActorId = listaActores[0].Id,
                    PeliculaId = listaPeliculas[0].Id,
                    Orden = 1,
                    Personaje = "Nick Fury"
                },
                new PeliculaActor
                {
                    ActorId = listaActores[0].Id,
                    PeliculaId = listaPeliculas[1].Id,
                    Orden = 2,
                    Personaje = "Nick Fury"
                },
                new PeliculaActor
                {
                    ActorId = listaActores[1].Id,
                    PeliculaId = listaPeliculas[1].Id,
                    Orden = 1,
                    Personaje = "Iron Man"
                }
            };




            modelBuilder.Entity<PeliculaActor>().
                HasData(listapeliculaActores);
 

        }
    }
}
