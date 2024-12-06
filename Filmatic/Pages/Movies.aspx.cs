using Filmatic.Data;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Filmatic
{
    public partial class _Movies : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMovies();
                return;
                // Crear una lista de películas de ejemplo
                var movies = new List<Movie>
                {
                    new Movie { Id = 1, Title = "El Gran Viaje", Description = "Una emocionante aventura por tierras desconocidas.", Duration = "2h 10m", Rating = "PG-13", ImagePath = "https://image.tmdb.org/t/p/w600_and_h900_bestv2/f4voSsbPTvaQwicwd1dyxICow6c.jpg" },
                    new Movie { Id = 2, Title = "Misterio en la Ciudad", Description = "Un thriller psicológico que te mantendrá al borde de tu asiento.", Duration = "1h 45m", Rating = "R", ImagePath = "~/Images/misterio_ciudad.jpg" },
                    new Movie { Id = 3, Title = "El Reino Perdido", Description = "Una historia fantástica de reinos antiguos, magia y batallas épicas.", Duration = "2h 20m", Rating = "PG", ImagePath = "~/Images/el_reino_perdido.jpg" }
                };

                // Asignar la lista de películas al Repeater
                MoviesRepeater.DataSource = movies;
                MoviesRepeater.DataBind();

            }
        }


        private void LoadMovies()
        {
            using (var context = new CineMaxTicketsDB11Entities3())
            {
                var dataMovies = context.sp_GetCinemaMoviesForMainScreen();
                MoviesRepeater.DataSource = dataMovies;
                MoviesRepeater.DataBind();
            }
        }
    }

    // Clase Movie para almacenar la información de cada película
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Rating { get; set; }
        public string ImagePath { get; set; }
    }

    // Clase CarouselItem para almacenar la información de cada imagen del carrusel
    public class CarouselItem
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
