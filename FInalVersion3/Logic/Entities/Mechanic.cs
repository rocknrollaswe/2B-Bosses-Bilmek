using System;
using System.Collections.Generic;
using System.Text;
using Logic.Vehicle;

namespace Logic.Entities
{
    public class Mechanic
    {
        private readonly string Case_message = "**Finns inget ärende**";


        public string Birthdate { get; set; }
        public string Namn { get; set; }
        public List<string> Skills { get; set; }
        public string[] Vehicles_case { get; set;}
        public string RegisteradeDatum { get; set; }
        public string LastDate { get; set; }






        public Mechanic(string namn, string birth, string lastdate)
        {
            Birthdate = birth;
            Namn = namn;
            Vehicles_case = new string[2];
            Vehicles_case[0] = Case_message;
            Vehicles_case[1] = Case_message;
            Skills = new List<string>();
            RegisteradeDatum = DateTime.Now.ToString("dd/MMM/yyyy");
            LastDate = lastdate;
        }




    }
}
