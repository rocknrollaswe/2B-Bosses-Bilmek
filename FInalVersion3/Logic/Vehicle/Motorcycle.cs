using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Vehicle
{
    public class Motorcycle : AProperties
    {
        public Motorcycle(string vehicle_typ, string brand, string model, int odometer, string f_type, string registeringnummer)
        {
            this.Registration_Date = DateTime.Now;
            this.Vehicle_Type = vehicle_typ;
            this.Brand = brand;
            this.Model = model;
            this.Odometer = odometer;
            this.Fuel_Type = f_type;
            this.Registration_Nr = registeringnummer;
            this.Caseid = string.Empty;
            

        }
    }
}
