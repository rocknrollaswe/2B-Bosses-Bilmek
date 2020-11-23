using Logic.Vehicle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class VehicleCase : ICase
    { 
        public string Comments { get; set; }
        public string Vehicle_Type { get; set; } 
        public string Vehicle_Issue { get; set; }
        public string Mechanic_ID { get; set; } 
        public string Mechanic_namn { get; set; } 
        public string Vehicle_Status { get; set; }
        public string Vehicle_Reg { get; set; }
        public DateTime  CaseRegistrationDate{ get; set; }


        public VehicleCase(string reg, string vehicle_Type, string vehicle_Issue, string mechanic_ID, string mechanic_name, string vehicle_Status, string comments)
        {
            this.Vehicle_Reg = reg;
            this.Vehicle_Type = vehicle_Type;
            this.Vehicle_Issue = vehicle_Issue;
            this.Mechanic_ID = mechanic_ID;
            this.Mechanic_namn = mechanic_name;
            this.Vehicle_Status = vehicle_Status;
            this.Comments = comments;
            this.CaseRegistrationDate = DateTime.Now;


        }



    }
}
