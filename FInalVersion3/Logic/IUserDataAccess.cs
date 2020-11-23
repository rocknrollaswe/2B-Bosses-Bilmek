using System;
using System.Collections.Generic;
using System.Text;
using Logic.DAL;
using Logic.Entities;
using Logic;
using Logic.Services;
using Logic.Vehicle;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Linq;

namespace Logic
{
    public interface IUserDataAccess
    {



        public enum File_Type { Users = 1, Mekanik, Komponent, Motorcykel, Bil, Lastbil, Buss, Ärande, Registreringsskylt, Avslutat_ärende, Lagerstatus };
        public enum Components { Bromsar = 1, Motor, Kaross, Vindruta, Däck }
        public enum TypeOfUser { Bosse = 1, Mekanik }
        public static string BosseID { get { return "1234"; } }
        public static string BosseName { get { return "Bosse"; } }
        public static string BossePassword { get { return "Meckarn123"; } }
        public enum VStatus { Avvaktar = 1, Pågående, Klart }
        public static object Current_user { get; set; }


        public static Dictionary<T, J> Read<T, J>(string file_type)
        {
            return UserDataAccess.Read<T, J>(file_type);
        }

        public static void Write<T, J>(Dictionary<T, J> dict, string file_type)
        {
            UserDataAccess.Write<T, J>(dict, file_type);
        }


        public static (bool, LoginService) LoginCheck(string Username, string Password)
        {
            LoginService _loginService = new LoginService();

            return _loginService.Login(Username, Password) ? (true, _loginService) : (false, null);
        }

        public static object GetVehicleInfo( string rgnr, string vehicle_typ)
        {
            if (vehicle_typ == Enum.GetName(typeof(IUserDataAccess.File_Type), 4))
            {return IUserDataAccess.Read<string, Motorcycle>(Enum.GetName(typeof(IUserDataAccess.File_Type), 4))[rgnr]; }
            else if (vehicle_typ == Enum.GetName(typeof(IUserDataAccess.File_Type), 5))
            { return IUserDataAccess.Read<string, Car>(Enum.GetName(typeof(IUserDataAccess.File_Type), 5))[rgnr]; }
            else if (vehicle_typ == Enum.GetName(typeof(IUserDataAccess.File_Type), 6))
            { return IUserDataAccess.Read<string, Truck>(Enum.GetName(typeof(IUserDataAccess.File_Type), 6))[rgnr]; }
            else 
            { return IUserDataAccess.Read<string, Bus>(Enum.GetName(typeof(IUserDataAccess.File_Type), 7))[rgnr]; }

        }



        public static bool IsValidEmail(string strIn)
        { 
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") && 
                                            !IUserDataAccess.Read<string, User>(Enum.GetName(typeof(IUserDataAccess.File_Type),1)).ContainsKey(strIn) ;
        }

        public static void DefaultUser()
        {
            string path = $"DAL\\Users.json";
            if (!File.Exists(path))
            {
                Directory.CreateDirectory("DAL\\");
                Dictionary<string, User> Default_dict = new Dictionary<string, User>();
                var Bosse = new User(IUserDataAccess.BosseName, IUserDataAccess.BossePassword, IUserDataAccess.BosseID, Enum.GetName(typeof(IUserDataAccess.TypeOfUser), 1));
                Default_dict.Add("Bosse", Bosse);

                IUserDataAccess.Write<string, User>(Default_dict, "Users");
            }
        }

        public static bool LicenseVerification(string regnr)
        {
            if (regnr.Length == 6)
            {
                string letters = regnr.Substring(0, 3);

                bool isNumbers = int.TryParse(regnr.Substring(3, 3), out int numbers);

                if (isNumbers && !letters.Any(char.IsDigit))
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }



        }

    }
}
