using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Components
    {
        public int Breaks { get; set; }
        public int Engine { get; set; }
        public int VehicleBody { get; set; }
        public int Windshield { get; set; } 
        public int Wheel { get; set; } 




        public Components(int breaks, int engine, int vehicleBody, int windshield, int wheel )
        {
            this.Breaks = breaks;
            this.Engine = engine;
            this.VehicleBody = vehicleBody;
            this.Windshield = windshield;
            this.Wheel = wheel;
        }
    }
}
