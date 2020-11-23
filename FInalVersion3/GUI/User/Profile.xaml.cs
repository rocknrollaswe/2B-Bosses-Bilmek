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

namespace GUI.Pages
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        private Dictionary<string, User> _userdb;
        private Dictionary<string, Mechanic> _mechanicdb;
        private Dictionary<string, Closed_Case> _closedC;
        public  Profile()
        {
            InitializeComponent();
            _closedC = IUserDataAccess.Read<string, Closed_Case>(Enum.GetName(typeof(IUserDataAccess.File_Type), 10));
            _mechanicdb = IUserDataAccess.Read<string, Mechanic>(Enum.GetName(typeof(IUserDataAccess.File_Type), 2));
            _userdb = IUserDataAccess.Read<string, User>(Enum.GetName(typeof(IUserDataAccess.File_Type), 1));

            var curentuser = (User)HomePage._GCU[2];

            if (!curentuser.UserType.Equals(Enum.GetName(typeof(IUserDataAccess.TypeOfUser), 1))) { Userinfo(); Userskills(); }     


            if (_closedC.Where(x=>x.Value.Mechanic_ID.Equals(HomePage._GCU[1])).Count() > 0) { cb_finshed_case.IsEnabled = true; cb_finshed_case.ItemsSource = _closedC.Where(x => x.Value.Mechanic_ID.Equals(HomePage._GCU[1])).Select(x => x.Key); }


        }

        private void cb_finshed_case_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _closedC.TryGetValue(cb_finshed_case.SelectedItem.ToString(), out Closed_Case _closevalue);

            tb_fordon_reg.Text = _closevalue.Vehicle_Reg;            ;
            tb_fordontyp.Text = _closevalue.Vehicle_Type;
            tb_fordonbrand.Text = _closevalue.VehicleBrand;
            tb_fordonmodel.Text = _closevalue.VehicleModel;
            tb_caseid.Text = cb_finshed_case.SelectedItem.ToString();
            tb_issue.Text = _closevalue.Vehicle_Issue;
            tb_comments.Text = _closevalue.Comments;
        }

        private void Userinfo()
        {
            _mechanicdb.TryGetValue(HomePage._GCU[1].ToString(), out Mechanic mkObj);
            tb_username.Content = mkObj.Namn;
            tb_useremail.Content = _userdb.Where(x => x.Value.UserId.Equals(HomePage._GCU[1].ToString())).Select(x => x.Key).ToArray()[0];
            tb_userbirth.Content = mkObj.Birthdate;
            tb_usertotal_case.Content = _closedC.Where(x => x.Value.Mechanic_ID.Equals(HomePage._GCU[1])).Count();
            tb_resignmentdate.Content = mkObj.LastDate;

            tb_case1_Info.Content = mkObj.Vehicles_case[0];
            tb_case2_Info.Content = mkObj.Vehicles_case[1];
        }

        private void Userskills()
        {
            _mechanicdb.TryGetValue(HomePage._GCU[1].ToString(), out Mechanic _mekObj);


            foreach (var item in _mekObj.Skills)
            {
                if (item.Equals(Enum.GetName(typeof(IUserDataAccess.Components), 1))) { Cb_Bromsar.IsChecked = true; }
                else if (item.Equals(Enum.GetName(typeof(IUserDataAccess.Components), 2))) { Cb_Motor.IsChecked = true; }
                else if (item.Equals(Enum.GetName(typeof(IUserDataAccess.Components), 3))) { Cb_Kaross.IsChecked = true; }
                else if (item.Equals(Enum.GetName(typeof(IUserDataAccess.Components), 4))) { Cb_Vindruta.IsChecked = true; }
                else if (item.Equals(Enum.GetName(typeof(IUserDataAccess.Components), 5))) { Cb_wheel.IsChecked = true; }
            }

        }

        private void BT_chnageSkills_Click(object sender, RoutedEventArgs e)
        {
            _mechanicdb.TryGetValue(HomePage._GCU[1].ToString(), out Mechanic _mekObj);

            string msg = $"Vill du ändra dina kompetens ?";
            string result = MessageBox.Show(msg, "Bekräftelse", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();



            if (result.Equals("Yes"))
            {

                if (Cb_Bromsar.IsChecked.Equals(true)) { _mekObj.Skills.Add(Cb_Bromsar.Content.ToString()); }
                if (Cb_Kaross.IsChecked.Equals(true)) { _mekObj.Skills.Add(Cb_Kaross.Content.ToString()); }
                if (Cb_Motor.IsChecked.Equals(true)) { _mekObj.Skills.Add(Cb_Motor.Content.ToString()); }
                if (Cb_Vindruta.IsChecked.Equals(true)) { _mekObj.Skills.Add(Cb_Vindruta.Content.ToString()); }
                if (Cb_wheel.IsChecked.Equals(true)) { _mekObj.Skills.Add(Cb_wheel.Content.ToString()); }

                _mechanicdb.Remove(HomePage._GCU[1].ToString());

                _mechanicdb.Add(HomePage._GCU[1].ToString(), _mekObj);

                IUserDataAccess.Write<string, Mechanic>(_mechanicdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 2));

            }






        }
    }
}
