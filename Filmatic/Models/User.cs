using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmatic.Models
{
    public interface IUser
    {
        string IdUser { get; set; }
        string UserName { get; set; }
        string Name { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Status { get; set; }
        DateTime BirthdayDate { get; set; }
    }

    public class User : IUser
    {
        public string IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public DateTime BirthdayDate { get; set; } 
    }
}