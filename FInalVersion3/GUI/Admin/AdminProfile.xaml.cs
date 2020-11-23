using Logic;
using Logic.Entities;
using Logic.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace GUI.Pages
{
    /// <summary>
    /// Interaction logic for AdminProfile.xaml
    /// </summary>
    public partial class AdminProfile : Page
    {
        private Dictionary<string, Components> _komponentdb;
        private Dictionary<string, VehicleCase> _casedb;
        private Dictionary<string, Mechanic> _mechanicdb;
        private Dictionary<string, User> _userdb;
        private Dictionary<string, string> _regdb;
        public AdminProfile()
        {
            InitializeComponent();
            Adminfo();
            MekanikInfo();
            GarageInfo();
        }


        private void MekanikInfo()
        {
            _userdb = IUserDataAccess.Read<string, User>(Enum.GetName(typeof(IUserDataAccess.File_Type), 1));
            _mechanicdb = IUserDataAccess.Read<string, Mechanic>(Enum.GetName(typeof(IUserDataAccess.File_Type), 2));
            int _broms = 0, _motor = 0, _Kaross = 0, _Vindruta = 0, _wheel = 0;

            foreach (var item in _mechanicdb.Values)
            {
                if (item.Skills.Contains(Enum.GetName(typeof(IUserDataAccess.Components),1))) _broms += 1;
                if (item.Skills.Contains(Enum.GetName(typeof(IUserDataAccess.Components), 2))) _motor += 1;
                if (item.Skills.Contains(Enum.GetName(typeof(IUserDataAccess.Components), 3))) _Kaross += 1;
                if (item.Skills.Contains(Enum.GetName(typeof(IUserDataAccess.Components), 4))) _Vindruta += 1;
                if (item.Skills.Contains(Enum.GetName(typeof(IUserDataAccess.Components), 5))) _wheel += 1;

            }


        TB_Total_mekanik.Content = _mechanicdb.Count();
            TB_Total_mekanik_konto.Content = _userdb.Count()-1;
            TB_Total_mekanik_skill_broms.Content = _broms;
            TB_Total_mekanik_motor.Content = _motor;
            TB_Total_mekanik_Kaross.Content = _Kaross;
            TB_Total_mekanik_Vindruta.Content = _Vindruta;
            TB_Total_mekanik_wheel.Content = _wheel;
        }


        private void GarageInfo()
        {
            new AllMechanic();
            _regdb = IUserDataAccess.Read<string, string>(Enum.GetName(typeof(IUserDataAccess.File_Type), 9));
            _casedb = IUserDataAccess.Read<string, VehicleCase>(Enum.GetName(typeof(IUserDataAccess.File_Type), 8));
            _komponentdb = IUserDataAccess.Read<string, Components>(Enum.GetName(typeof(IUserDataAccess.File_Type), 11));
 



            TB_Total_fordoninfo.Content = _regdb.Count();
            TB_Total_MC.Content = _regdb.Where(x => x.Value.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 4))).Count();
            TB_Total_BIl.Content = _regdb.Where(x => x.Value.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 5))).Count();
            TB_Total_lastbil.Content = _regdb.Where(x => x.Value.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 6))).Count();
            TB_Total_Buss.Content = _regdb.Where(x => x.Value.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 7))).Count();
            TB_Total_case.Content = _casedb.Count();
            TB_Total_Nocase.Content = _regdb
                .Where(x => !_casedb.Values.Select(y => y.Vehicle_Reg).Contains(x.Key))
                .Count();


            _komponentdb.TryGetValue("Components", out Components ComObj);

            Tb_Fordon_broms.Content = ComObj.Breaks;
            Tb_Fordon_Motor.Content = ComObj.Engine;
            Tb_Fordon_Kaross.Content = ComObj.VehicleBody;
            Tb_Fordon_Vindruta.Content = ComObj.Windshield;
            Tb_Fordon_wheel.Content = ComObj.Wheel;




        }


        private void Adminfo()
        {
            Tb_date_today.Content = $"Idag är {DateTime.Now.ToString("D")} ";
        }
    }
}
