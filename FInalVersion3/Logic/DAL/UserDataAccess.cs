using Logic.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Logic.DAL
{
    public class UserDataAccess 
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to
        /// </summary>
        /// <returns></returns>


        //######################################################################################################################
        public static void Write<T, J>(Dictionary<T, J> dict, string file_type)
        {
            Directory.CreateDirectory("DAL\\");
            string path = $"DAL\\{file_type.ToString()}.json";
            using (StreamWriter file = File.CreateText(path))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(file, dict);
            }

        }

        public static Dictionary<T, J> Read<T, J>(string file_Type)
        {
            string path = $"DAL\\{file_Type.ToString()}.json";
            if (File.Exists(path))
            {
                using (StreamReader file = File.OpenText(path))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    Dictionary<T, J> Dict = (Dictionary<T, J>)serializer.Deserialize(file, typeof(Dictionary<T, J>));
                    return Dict;
                }
            }
            else
            {                
                Dictionary<T, J> Dict = new Dictionary<T, J>();
                return Dict;
            }
        }


    }
}
