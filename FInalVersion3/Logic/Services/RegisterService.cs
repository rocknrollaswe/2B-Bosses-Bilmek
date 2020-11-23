using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Services
{
    class RegisterService
    {
        private static Dictionary<string, Mechanic> _db_M;
        private static Dictionary<string, User> _db_U;

        public RegisterService()
        {
            _db_M = IUserDataAccess.Read<string, Mechanic>(Enum.GetName(typeof(IUserDataAccess.File_Type),2));
            _db_U = IUserDataAccess.Read<string, User>(Enum.GetName(typeof(IUserDataAccess.File_Type), 1));

        }

        public static (bool,Dictionary<string, Mechanic>) Checking_RegisteraID(string ID)
        {
            return (_db_M.ContainsKey(ID), _db_M);
        }

        public static (bool, Dictionary<string, User>) Checking_Username(string Username)
        {
            return (_db_U.ContainsKey(Username), _db_U);
        }



    }
}
