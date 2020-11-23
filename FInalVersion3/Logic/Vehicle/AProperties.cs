using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Vehicle
{
    public abstract class AProperties
    {

        public DateTime Registration_Date { get; set; }
        public string Vehicle_Type { get; set; } 
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Odometer { get; set; }
        public string Fuel_Type { get; set; }
        public string Registration_Nr { get; set; }
        public string Caseid { get; set; }

        //-------------------------------------------------------------------**


    }
}
