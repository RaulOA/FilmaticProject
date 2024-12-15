using Filmatic.Data;
using System;
using System.Data;
using System.Linq;
using System.Web.UI;

namespace Filmatic
{
    public partial class _Movies : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCarouselData();
                LoadMovies();
            }
        }

        private void LoadCarouselData()
        {
            // Crear el objeto para almacenar los datos del carrousel
            DataTable dtSlides = new DataTable();
            dtSlides.Columns.Add("SlideID");
            dtSlides.Columns.Add("Title");
            dtSlides.Columns.Add("ImageUrl");

            using (var context = new CineMaxTicketsDB11Entities3())
            {
                // Obtener los datos desde el procedimiento almacenado (solo las URLs de las imágenes)
                var dataMovies = context.sp_GetLastThreeMoviesCarrousel().ToList();

                // Verificar si dataMovies tiene exactamente 3 elementos
                if (dataMovies.Count == 3)
                {
                    // Recorrer los datos devueltos por el SP y llenar el DataTable
                    int slideID = 1;
                    for (int i = 0; i < dataMovies.Count; i++)
                    {
                        string title = $"Imagen {i + 1}";  // Generar el título "Imagen 1", "Imagen 2", "Imagen 3"
                        string imageUrl = dataMovies[i].ToString(); // Acceder a la URL utilizando el índice

                        // Agregar la fila al DataTable
                        dtSlides.Rows.Add(slideID++, title, imageUrl);
                    }
                }
            }

            // Enlazar los datos al Repeater de las imágenes
            rptCarouselItems.DataSource = dtSlides;
            rptCarouselItems.DataBind();

            // Enlazar los datos al Repeater de los indicadores
            rptCarouselIndicators.DataSource = dtSlides;
            rptCarouselIndicators.DataBind();
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
}
