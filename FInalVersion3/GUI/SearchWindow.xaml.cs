using GUI.Home;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private Dictionary<string, Closed_Case> _closedC;
        private Dictionary<string, string> _regdb;
        private Dictionary<string, VehicleCase> _casedb;
        private Dictionary<string, Mechanic> _mechanicdb;
        private Dictionary<string, User> _userdb;

        public SearchWindow()
        {

            InitializeComponent();


        }


        public void GetSearchInfo(string serchbox)
        {
            _userdb = IUserDataAccess.Read<string, User>(Enum.GetName(typeof(IUserDataAccess.File_Type), 1));
            _casedb = IUserDataAccess.Read<string, VehicleCase>(Enum.GetName(typeof(IUserDataAccess.File_Type), 8));
            _regdb = IUserDataAccess.Read<string, string>(Enum.GetName(typeof(IUserDataAccess.File_Type), 9));
            _mechanicdb = IUserDataAccess.Read<string, Mechanic>(Enum.GetName(typeof(IUserDataAccess.File_Type), 2));
            _closedC = IUserDataAccess.Read<string, Closed_Case>(Enum.GetName(typeof(IUserDataAccess.File_Type), 10));


            if (_regdb.TryGetValue(serchbox, out string omfordon) ) 
            {
                TB_Defaultmsg.Visibility = Visibility.Collapsed;
                var fordondetails = (AProperties)IUserDataAccess.GetVehicleInfo(serchbox, omfordon);

                TB_1.Content = omfordon;
                TB_2.Content = fordondetails.Brand;
                TB_3.Content = fordondetails.Model;
                if (fordondetails.Caseid.Equals(string.Empty)) { TB_4.Content = "** Ingen ärende skapat ännu **"; } 
                else { TB_4.Content = "** Ärende har skapat redan **"; }


            }
            else if (_casedb.TryGetValue(serchbox, out VehicleCase omcase))
            {
                TB_Defaultmsg.Visibility = Visibility.Collapsed;
                TB_1.Content = omcase.Vehicle_Reg;
                TB_2.Content = omcase.Vehicle_Status;
                TB_3.Content = omcase.Vehicle_Type;

            }
            else if (_mechanicdb.TryGetValue(serchbox, out Mechanic ommekanik) && HomePage._GCU[1].Equals(IUserDataAccess.BosseID))
            {
                TB_Defaultmsg.Visibility = Visibility.Collapsed;
                TB_1.Content = ommekanik.Namn;
                TB_2.Content = string.Join(",", ommekanik.Skills.ToArray());
                TB_3.Content = ommekanik.Birthdate;
  
            }
            else if (_userdb.TryGetValue(serchbox, out User ommeUser) && HomePage._GCU[1].Equals(IUserDataAccess.BosseID))
            {
                TB_Defaultmsg.Visibility = Visibility.Collapsed;
                TB_1.Content = ommeUser.Username;
                TB_2.Content = ommeUser.UserType;
                TB_3.Content = ommeUser.UserId;

            }

            else if (_closedC.TryGetValue(serchbox, out Closed_Case _closecaseObj) )
            {
                TB_Defaultmsg.Visibility = Visibility.Collapsed;


                TB_1.Content = _closecaseObj.Vehicle_Reg;
                TB_2.Content = _closecaseObj.Vehicle_Type;
                TB_3.Content = _closecaseObj.VehicleBrand;
                TB_3.Content = _closecaseObj.Mechanic_ID;
                TB_4.Content = _closecaseObj.Vehicle_Status;

            }
        }



        private void BT_goBack_Click(object sender, RoutedEventArgs e)
        {
            var win = Application.Current.MainWindow;
            win.Show();
            this.Close();

        }
    }
}
