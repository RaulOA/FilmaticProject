//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Filmatic.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class cinema_functions
    {
        public string id { get; set; }
        public string id_room { get; set; }
        public System.DateTime create_at { get; set; }
        public Nullable<decimal> duration { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public string id_movie { get; set; }
        public string format_movie { get; set; }
    
        public virtual cat_movies cat_movies { get; set; }
        public virtual cinema_rooms cinema_rooms { get; set; }
    }
}
