using Logic;
using Logic.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
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
using System.Linq;

namespace GUI.Pages
{
    /// <summary>
    /// Interaction logic for Add_Mechanic.xaml
    /// </summary>
    public partial class Add_Mechanic : Page
    {
        VehicleCase _caseObj;
        private Dictionary<string, VehicleCase> _casedb;
        private readonly string Case_message = "**Finns inget ärende**";
        private readonly string Wrong_msg = "** Fel inmatning **";
        private string Mekaniknamn = "-- Ange Namn --";
        private string Mekanibirth = "-- Ange födelsedatum --";
        private string MekanikEmail =  "-- Ange E-mail --";
        private string MekanikId = "-- Ange Mekaniker Id --";
        private string Mekaniklastdate = "-- Ange slutdatum för anställd --";
        private Dictionary<string, Mechanic> _mechanicdb;
        private Dictionary<string, User> _userdb;


        public Add_Mechanic()
        {

            InitializeComponent(); 
            _mechanicdb = IUserDataAccess.Read<string, Mechanic>(Enum.GetName(typeof(IUserDataAccess.File_Type), 2));
            _userdb = IUserDataAccess.Read<string, User>(Enum.GetName(typeof(IUserDataAccess.File_Type), 1));

            _casedb = IUserDataAccess.Read<string, VehicleCase>(Enum.GetName(typeof(IUserDataAccess.File_Type), 8));
        }

        private void DP_mekanik_birth_CalendarClosed(object sender, RoutedEventArgs e)
        {

            try
            {
                DP_mekanik_lastdate.DisplayDateStart = DateTime.Now;   
                tb_mekanik_birt.Text = DP_mekanik_birth.SelectedDate.Value.ToString("dd - MMMM - yyyy");
                DP_mekanik_lastdate.IsEnabled = true;
            }
            catch (Exception)
            {

                Error_msg.Content = Wrong_msg;
            }
   

            
        }



        private void DP_mekanik_lastdate_CalendarClosed(object sender, RoutedEventArgs e)
        {

            try
            {
                tb_mekanik_lastdate.Text = DP_mekanik_lastdate.SelectedDate.Value.ToString("dd - MMMM - yyyy");
                Bt_add_mekanik.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {

                Error_msg.Content = Wrong_msg;
            }



        }




        private void cb_mekanik_till_user_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_mekanik_till_user.SelectedIndex.Equals(0))
            {
                Sp_email_tb_box.Visibility = Visibility.Visible; Sp_password_tb_box.Visibility = Visibility.Visible;
            }
            else if (cb_mekanik_till_user.SelectedIndex.Equals(1))
            {
                Sp_email_tb_box.Visibility = Visibility.Collapsed; Sp_password_tb_box.Visibility = Visibility.Collapsed;
            }

        }

        private void cb_SC_mekanik_till_user_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_sc_mekanik_till_user.SelectedIndex.Equals(0))
            {
                tb_sc_mekanik_email.IsReadOnly = false;
                Sp_sc_email.Visibility = Visibility.Visible; Sp_sc_password.Visibility = Visibility.Visible;
            }
            else if (cb_sc_mekanik_till_user.SelectedIndex.Equals(1))
            {
                Sp_sc_email.Visibility = Visibility.Collapsed; Sp_sc_password.Visibility = Visibility.Collapsed;
            }

        }

        private void Bt_add_mekanik_Click(object sender, RoutedEventArgs e)
        {

            string getId = Guid.NewGuid().ToString();
            Mechanic Creat_mechanic = new Mechanic(tb_mekanik_namn.Text, tb_mekanik_birt.Text, tb_mekanik_lastdate.Text);
            if (Cb_sc_Bromsar.IsChecked.Equals(true)) { Creat_mechanic.Skills.Add(Cb_sc_Bromsar.Content.ToString()); }
            if (Cb_sc_Kaross.IsChecked.Equals(true)) { Creat_mechanic.Skills.Add(Cb_sc_Kaross.Content.ToString()); }
            if (Cb_sc_Motor.IsChecked.Equals(true)) { Creat_mechanic.Skills.Add(Cb_sc_Motor.Content.ToString()); }
            if (Cb_sc_Vindruta.IsChecked.Equals(true)) { Creat_mechanic.Skills.Add(Cb_sc_Vindruta.Content.ToString()); }
            if (Cb_sc_wheel.IsChecked.Equals(true)) { Creat_mechanic.Skills.Add(Cb_sc_wheel.Content.ToString()); }

            if (cb_mekanik_till_user.SelectedIndex.Equals(0) && IUserDataAccess.IsValidEmail(tb_mekanik_email.Text) && !tb_mekanik_password.Password.Equals(string.Empty)
                && !tb_mekanik_namn.Text.Equals(string.Empty) && !tb_mekanik_namn.Text.Equals(Mekaniknamn) && !tb_mekanik_birt.Text.Equals(string.Empty) && !tb_mekanik_birt.Text.Equals(Mekanibirth))
            {



                _mechanicdb.Add(getId, Creat_mechanic);
                _userdb.Add(tb_mekanik_email.Text, new User(tb_mekanik_namn.Text, tb_mekanik_password.Password, getId));

                IUserDataAccess.Write<string, Mechanic>(_mechanicdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 2));
                IUserDataAccess.Write<string, User>(_userdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 1));
                NavigationService.Navigate(new Add_Mechanic());
            }
            else if (!cb_mekanik_till_user.SelectedIndex.Equals(0) && !tb_mekanik_namn.Text.Equals(string.Empty) && !tb_mekanik_birt.Text.Equals(string.Empty) && !tb_mekanik_birt.Text.Equals(Mekanibirth) && !tb_mekanik_namn.Text.Equals(Mekaniknamn))
            {

                _mechanicdb.Add(getId, Creat_mechanic);

                IUserDataAccess.Write<string, Mechanic>(_mechanicdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 2));
                NavigationService.Navigate(new Add_Mechanic());
            }
            else { Error_msg.Content = Wrong_msg; }
        }



        private void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }





        private void search_bt_Click(object sender, RoutedEventArgs e)
        {


            bool find = _mechanicdb.TryGetValue(tb_sc_search_mekanik.Text, out Mechanic _mkObj);



            if (find)
            {
        

                tb_sc_search_mekanik.IsReadOnly = true;
                tb_sc_mekanik_namn.Text = _mkObj.Namn;
                tb_sc_mekanik_birth.Text = _mkObj.Birthdate;
                tb_sc_mekanik_lastdate.Text = _mkObj.LastDate;


                Sp_sc_mekanik_namn.Visibility = Visibility.Visible;
                Sp_sc_mekanik_birth.Visibility = Visibility.Visible;
                Sp_sc_Kompetens.Visibility = Visibility.Visible;
                SP_sc_mekanik_case.Visibility = Visibility.Visible;
                Sp_sc_mekanik_lastdate.Visibility = Visibility.Visible;
                Bt_Add_remove_mekanik.Visibility = Visibility.Visible;




                if (!_mkObj.Vehicles_case[0].Equals(Case_message) || !_mkObj.Vehicles_case[1].Equals(Case_message))
                { cb_sc_mekanik_case.IsEnabled = true; cb_sc_mekanik_case.ItemsSource = _mkObj.Vehicles_case.Where( x => !x.Equals(Case_message)); }



                foreach (var item in _mkObj.Skills)
                {
                    if (Cb_Bromsar.Content.Equals(item)){ Cb_Bromsar.IsChecked = true; }
                    else if (Cb_Kaross.Content.Equals(item)) { Cb_Kaross.IsChecked = true; }
                    else if (Cb_Motor.Content.Equals(item)) { Cb_Motor.IsChecked = true; }
                    else if (Cb_Vindruta.Content.Equals(item)) { Cb_Vindruta.IsChecked = true; } 
                    else if (Cb_wheel.Content.Equals(item)) { Cb_wheel.IsChecked = true; }
                }






                foreach (var item in _userdb)
                {
                    if (item.Value.UserId .Equals(tb_sc_search_mekanik.Text))
                    {

                        Sp_sc_email.Visibility = Visibility.Visible;
                        Sp_sc_password.Visibility = Visibility.Visible;

                        tb_sc_mekanik_email.Text = item.Key;
                        return;
                    }

                }


                SP_sc_mekanik_till_user.Visibility = Visibility.Visible;







            }
            else
            {
                Error_msg.Content = "** Angav fel Mekanik Id **";
            }

        }


        private void Tb_mekanik_sc_email_Gotfocus(object sender, RoutedEventArgs e)
        {
            if (tb_sc_mekanik_email.Text.Equals(MekanikEmail)) { tb_sc_mekanik_email.Text = string.Empty; }
        }
        private void Tb_mekanik_sc_email_lostfocus(object sender, RoutedEventArgs e)
        {
            if (tb_sc_mekanik_email.Text.Equals(string.Empty)) { tb_sc_mekanik_email.Text = MekanikEmail; }
        }


        private void tb_remove_skill_Click(object sender, RoutedEventArgs e)
        {

           
        }

        private void Tb_mekanik_namn_Gotfocus(object sender, RoutedEventArgs e)
        {
            if (tb_mekanik_namn.Text.Equals(Mekaniknamn)) { tb_mekanik_namn.Text = string.Empty; DP_mekanik_birth.IsEnabled = true; }
        }
        private void Tb_mekanik_namn_lostfocus(object sender, RoutedEventArgs e)
        {
            if (tb_mekanik_namn.Text.Equals(string.Empty)) { tb_mekanik_namn.Text = Mekaniknamn; DP_mekanik_birth.IsEnabled = false; }
        }


        private void Tb_mekanik_Email_Gotfocus(object sender, RoutedEventArgs e)
        {
            if (tb_mekanik_email.Text.Equals(MekanikEmail)) { tb_mekanik_email.Text = string.Empty; }
        }
        private void Tb_mekanik_Email_lostfocus(object sender, RoutedEventArgs e)
        {
            if (tb_mekanik_email.Text.Equals(string.Empty)) { tb_mekanik_email.Text = MekanikEmail; }
        }


        private void Tb_mekanik_ID_search_Gotfocus(object sender, RoutedEventArgs e)
        {
            if (tb_sc_search_mekanik.Text.Equals(MekanikId)) { tb_sc_search_mekanik.Text = string.Empty; }
        }
        private void Tb_mekanik_ID_search_lostfocus(object sender, RoutedEventArgs e)
        {
            if (tb_sc_search_mekanik.Text.Equals(string.Empty)) { tb_sc_search_mekanik.Text = MekanikId; }
        }

        private void Remove_mekanik(object sender, RoutedEventArgs e)
        {
            _mechanicdb.TryGetValue(tb_sc_search_mekanik.Text, out Mechanic _mekObj);

            string msg = $"Vill du ta bort [ {_mekObj.Namn} ] från systemet ?";
            string result = MessageBox.Show(msg, "Bekräftelse", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();



            if (result.Equals("Yes"))
                {

                foreach (var item in _userdb)
                {
                    if (item.Value.UserId.Equals(tb_sc_search_mekanik.Text))
                    {
                        _userdb.Remove(item.Key);
                        IUserDataAccess.Write<string, User>(_userdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 1));
                    }
                }

                _mechanicdb.Remove(tb_sc_search_mekanik.Text);

                IUserDataAccess.Write<string, Mechanic>(_mechanicdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 2));

                NavigationService.Navigate(new Add_Mechanic());
            }

        }

        private void Eddit_mechanic_info(object sender, RoutedEventArgs e)
        {
      
            _mechanicdb.TryGetValue(tb_sc_search_mekanik.Text, out Mechanic _mekObj);


        


            string msg = $"Vill du ändra [ {_mekObj.Namn} ] information ?";
            string result = MessageBox.Show(msg, "Bekräftelse", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();



            if (result.Equals("Yes")) {


                if (Cb_Bromsar.IsChecked.Equals(true) && !_mekObj.Skills.Contains(Cb_Bromsar.Content)) _mekObj.Skills.Add(Cb_Bromsar.Content.ToString());
                else if (Cb_Bromsar.IsChecked.Equals(false) && _mekObj.Skills.Contains(Cb_Bromsar.Content)) _mekObj.Skills.Remove(Cb_Bromsar.Content.ToString());

                if (Cb_Kaross.IsChecked.Equals(true) && !_mekObj.Skills.Contains(Cb_Kaross.Content)) _mekObj.Skills.Add(Cb_Kaross.Content.ToString()); 
                else if (Cb_Kaross.IsChecked.Equals(false) && _mekObj.Skills.Contains(Cb_Kaross.Content)) _mekObj.Skills.Remove(Cb_Kaross.Content.ToString());


                if (Cb_Motor.IsChecked.Equals(true) && !_mekObj.Skills.Contains(Cb_Motor.Content)) _mekObj.Skills.Add(Cb_Motor.Content.ToString());
                else if (Cb_Motor.IsChecked.Equals(false) && _mekObj.Skills.Contains(Cb_Motor.Content)) _mekObj.Skills.Remove(Cb_Motor.Content.ToString());



                if (Cb_Vindruta.IsChecked.Equals(true) && !_mekObj.Skills.Contains(Cb_Vindruta.Content)) _mekObj.Skills.Add(Cb_Vindruta.Content.ToString());
                else if (Cb_Vindruta.IsChecked.Equals(false) && _mekObj.Skills.Contains(Cb_Vindruta.Content)) _mekObj.Skills.Remove(Cb_Vindruta.Content.ToString());

                if (Cb_wheel.IsChecked.Equals(true) && !_mekObj.Skills.Contains(Cb_wheel.Content)) _mekObj.Skills.Add(Cb_wheel.Content.ToString());
                else if (Cb_wheel.IsChecked.Equals(false) && _mekObj.Skills.Contains(Cb_wheel.Content)) _mekObj.Skills.Remove(Cb_wheel.Content.ToString());




                if (cb_sc_mekanik_case.IsEnabled.Equals(true) && !cb_sc_mekanik_case.SelectedIndex.Equals(-1))
                { _casedb.TryGetValue(cb_sc_mekanik_case.SelectedItem.ToString(), out _caseObj);
                    _caseObj.Vehicle_Status = cb_sc_fordon_status.Text;
                }

                _mekObj.Namn = tb_sc_mekanik_namn.Text;
          

                if (SP_sc_mekanik_till_user.Visibility.Equals(Visibility.Collapsed))
                {

                    
                    _userdb.Where(x => x.Value.UserId.Equals(tb_sc_search_mekanik.Text)).Select(x => x.Value.Password = tb_sc_mekanik_password.Password);

                    IUserDataAccess.Write<string, User>(_userdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 1));

                }
                else if (SP_sc_mekanik_till_user.Visibility.Equals(Visibility.Visible) && cb_sc_mekanik_till_user.SelectedIndex.Equals(0) && IUserDataAccess.IsValidEmail(tb_sc_mekanik_email.Text))
                {
                    _userdb.Add(tb_sc_mekanik_email.Text, new User(_mekObj.Namn, tb_sc_mekanik_password.Password, tb_sc_search_mekanik.Text));
                    IUserDataAccess.Write<string, User>(_userdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 1));

                }
                else if (SP_sc_mekanik_till_user.Visibility.Equals(Visibility.Visible) && cb_sc_mekanik_till_user.SelectedIndex < 0 )
                {

                    IUserDataAccess.Write<string, User>(_userdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 1));
                }
                else
                {
                    Error_msg.Content = Wrong_msg;
                    return;
                }


                IUserDataAccess.Write<string, Mechanic>(_mechanicdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 2));

                IUserDataAccess.Write<string, VehicleCase>(_casedb, Enum.GetName(typeof(IUserDataAccess.File_Type), 8));



                if (cb_sc_fordon_status.SelectedIndex.Equals(2)) 
                {
                    Case new_case = new Case();
                    new_case.Case_done(cb_sc_mekanik_case.SelectedItem.ToString());         
                
                
                }



                NavigationService.Navigate(new Add_Mechanic());
            }

        }

        private void cb_sc_mekanik_case_selected(object sender, SelectionChangedEventArgs e)
        {
            SP_sc_fordon_status.Visibility = Visibility.Visible;

            _casedb.TryGetValue(cb_sc_mekanik_case.SelectedItem.ToString(), out VehicleCase obj);

            if (obj.Vehicle_Status.Equals(Enum.GetName(typeof(IUserDataAccess.VStatus), 1))) { cb_sc_fordon_status.SelectedIndex = 0; }
            else if (obj.Vehicle_Status.Equals(Enum.GetName(typeof(IUserDataAccess.VStatus), 2))) { cb_sc_fordon_status.SelectedIndex = 1; }
            else { cb_sc_fordon_status.SelectedIndex = 2; }
        }
    }
}
