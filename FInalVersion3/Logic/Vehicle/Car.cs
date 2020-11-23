using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Vehicle
{
    public class Car : AProperties
    {
        public bool Dragkrok { get; set; }

        public string Type_Of_Car { get; set; }





        public Car(string vehicle_typ, string brand, string model, int odometer, bool drag_krok, string car_type, string f_type, string registeringnummer)
        {
            this.Registration_Date = DateTime.Now;
            this.Vehicle_Type = vehicle_typ;
            this.Type_Of_Car = car_type;
            this.Brand = brand;
            this.Model = model;
            this.Odometer = odometer;
            this.Dragkrok = drag_krok;
            this.Fuel_Type = f_type;
            this.Registration_Nr = registeringnummer;
            this.Caseid = string.Empty;

        }

    }
}
