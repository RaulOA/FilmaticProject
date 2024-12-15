using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmatic.Models
{
    public interface IUser
    {
         string id_usuario { get; set; }
         string usuario { get; set; }
         string cedula { get; set; }
         string nombre { get; set; }
         string apellido { get; set; }
         string mail { get; set; }
         string telefono { get; set; }
         DateTime? nacimiento { get; set; }
         string estado { get; set; }
        Boolean IsAdmin { get; set; }
    }

    public class User : IUser
    {
        public string id_usuario { get; set; }
        public string usuario { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
        public DateTime? nacimiento { get; set; }
        public string estado { get; set; }
        public Boolean IsAdmin { get; set; }
    }
}