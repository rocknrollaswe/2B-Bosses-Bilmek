using Logic.Vehicle;
using System;
using System.Collections.Generic;

namespace Logic.Services
{
    public class CheckPost
    {       


        public (bool, string) Reg_check(string rgn)
        {
            var reg_list = IUserDataAccess.Read<string, string >(Enum.GetName(typeof(IUserDataAccess.File_Type), 9));
            if (reg_list.ContainsKey(rgn))
            {  reg_list.TryGetValue(rgn, out string value);
                return (true, value); }
            return (false, null);
        }



        public (bool, string, Dictionary<string,Motorcycle>) MC_check(string rgn)
        {
            var mc = IUserDataAccess.Read<string, Motorcycle>(Enum.GetName(typeof(IUserDataAccess.File_Type), 4));
            if (mc.ContainsKey(rgn))
            { return (true, mc[rgn].Vehicle_Type, mc);  }
            return (false, null, null);
        }

        public (bool, string, Dictionary<string, Car>) Car_check(string rgn)
        {
            var car = IUserDataAccess.Read<string, Car>(Enum.GetName(typeof(IUserDataAccess.File_Type), 5));
            if (car.ContainsKey(rgn))
            { return (true, car[rgn].Vehicle_Type, car); }
            return (false, null, null);
        }

        public (bool, string, Dictionary<string, Truck>) Truck_check(string rgn)
        {
            var truck = IUserDataAccess.Read<string, Truck>(Enum.GetName(typeof(IUserDataAccess.File_Type), 4));
            if (truck.ContainsKey(rgn))
            { return (true, truck[rgn].Vehicle_Type, truck); }
            return (false, null, null);
        }

        public (bool, string, Dictionary<string, Bus>) Bus_check(string rgn)
        {
            var bus = IUserDataAccess.Read<string, Bus>(Enum.GetName(typeof(IUserDataAccess.File_Type), 4));
            if (bus.ContainsKey(rgn))
            { return (true, bus[rgn].Vehicle_Type, bus); }
            return (false, null, null);
        }

    }
}
