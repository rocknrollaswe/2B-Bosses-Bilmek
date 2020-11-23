using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Vehicle
{
    public class Bus : AProperties
    {
        public int Max_Passengers { get; set; }
        public Bus(string vehicle_typ, string brand, string model, int odometer, int max_Passengers, string f_type, string registeringnummer)
        {
            this.Registration_Date = DateTime.Now;
            this.Vehicle_Type = vehicle_typ;
            this.Brand = brand;
            this.Model = model;
            this.Odometer = odometer;
            this.Fuel_Type = f_type;
            this.Max_Passengers = max_Passengers;
            this.Registration_Nr = registeringnummer;
            this.Caseid = string.Empty;


        }

    }
}
