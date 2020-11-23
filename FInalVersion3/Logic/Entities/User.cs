using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public string UserType { get; set; }



        public User(string name, string pass, string id, string usertyp = "Mekanik")
        {
            UserType = usertyp;
            Username = name;
            Password = pass;
            UserId = id;
            
        }
    }
}
