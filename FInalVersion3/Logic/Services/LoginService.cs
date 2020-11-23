using Logic.DAL;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Services
{
    public class LoginService
    {
        private Dictionary<string, Mechanic> _Mk;
        private Dictionary<string, User> _db;

        public LoginService()
        {
            _Mk = IUserDataAccess.Read<string, Mechanic>(Enum.GetName(typeof(IUserDataAccess.File_Type), 2));
            _db = IUserDataAccess.Read<string, User>(Enum.GetName(typeof(IUserDataAccess.File_Type), 1));
        }

        public bool Login(string username, string password)
        {
            return _db.TryGetValue(username, out User user) && user.Password == password;
        }
        public (string, string, User, Mechanic) GetCurrentUser(string name)
        {
            _db.TryGetValue(name, out User User_value);
            if (User_value.UserType == Enum.GetName(typeof(IUserDataAccess.TypeOfUser), 1)) { return (User_value.Username, User_value.UserId, User_value, null); }
            else 
            {
                _Mk.TryGetValue(User_value.UserId, out Mechanic Mechanic_value);
                return (User_value.Username, User_value.UserId, User_value, Mechanic_value);
            }
            
            
        }
    }
}
