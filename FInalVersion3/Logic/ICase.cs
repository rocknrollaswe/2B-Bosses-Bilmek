using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface ICase
    {
   
        public string Comments { get; set; }
        public string Vehicle_Type { get; set; }
        public string Vehicle_Issue { get; set; }
        public string Mechanic_ID { get; set; }
        public string Mechanic_namn { get; set; }
        public string Vehicle_Status { get; set; }
        public string Vehicle_Reg { get; set; }

    }
}
