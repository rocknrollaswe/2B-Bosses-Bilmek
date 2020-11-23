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
    /// Interaction logic for Case.xaml
    /// </summary>
    public partial class Case : Page
    {
        private Dictionary<string, string> _regdb;
        private Dictionary<string, VehicleCase> _casedb;
        private Dictionary<string, Mechanic> _mechanicdb;
        private Dictionary<string, string> _sortedMekanik;
        private Dictionary<string, Components> _komponentdb;
        private readonly string _komponent = "Components";


        private dynamic _tempRegnr;
        private Dictionary<string, Closed_Case> _closedC;

        private Dictionary<string, Motorcycle> _mcdb;
        private Dictionary<string, Car> _cardb;
        private Dictionary<string, Truck> _trucdb;
        private Dictionary<string, Bus> _busdb;

        private readonly string Wrong_msg = "** Fel inmatning **";
        private readonly string TextRegNr = "-- Ange ärandenummer --";
        private readonly string Textcomment = " Skriv din kommentar ";
        private readonly string Case_message = "**Finns inget ärende**";
        public Case()
        {
 

            _casedb = IUserDataAccess.Read<string, VehicleCase>(Enum.GetName(typeof(IUserDataAccess.File_Type), 8));
            _regdb = IUserDataAccess.Read<string, string>(Enum.GetName(typeof(IUserDataAccess.File_Type), 9));
            _mechanicdb = IUserDataAccess.Read<string, Mechanic>(Enum.GetName(typeof(IUserDataAccess.File_Type), 2));
            _closedC = IUserDataAccess.Read<string, Closed_Case>(Enum.GetName(typeof(IUserDataAccess.File_Type), 10));


            _komponentdb = IUserDataAccess.Read<string, Components>(Enum.GetName(typeof(IUserDataAccess.File_Type), 11));



            _mcdb = IUserDataAccess.Read<string, Motorcycle>(Enum.GetName(typeof(IUserDataAccess.File_Type), 4));

            _cardb = IUserDataAccess.Read<string, Car>(Enum.GetName(typeof(IUserDataAccess.File_Type), 5));

            _trucdb = IUserDataAccess.Read<string, Truck>(Enum.GetName(typeof(IUserDataAccess.File_Type), 6));

            _busdb = IUserDataAccess.Read<string, Bus>(Enum.GetName(typeof(IUserDataAccess.File_Type), 7));

            new AllMechanic();


            //------------------------------- Sorterar fordon som har inte utdelat ärande ännu  och lägger till i lista

            InitializeComponent();


            _tempRegnr = _regdb
                .Where(x => !_casedb.Values.Select(y=>y.Vehicle_Reg).Contains(x.Key))
                .ToDictionary(x=>x.Key, x=>x.Value);
          
            if (_tempRegnr.Count > 0) { cb_vehicle_list.IsEnabled = true; cb_vehicle_list.ItemsSource = _tempRegnr.Keys; }



        }

     

        private void cb_vehicle_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _tempRegnr.TryGetValue(cb_vehicle_list.SelectedItem.ToString(), out string value);

            tb_vehicle_type.Text = value;
            sp_vehicle_typ.Visibility = Visibility.Visible;
            cb_issu_option.IsEnabled = true ;


        }

        private void cb_mechanic_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            _sortedMekanik.TryGetValue(cb_mechanic_list.SelectedItem.ToString(), out string mekanik_name);

            sp_mekanik.Visibility = Visibility.Visible;

            tb_mekanikname.Text = mekanik_name;

            if (cb_mechanic_list.SelectedIndex >= 0)
            {
                Bt_add_case.Visibility = Visibility.Visible;
            }

        }

        private void cb_sc_issu_option_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            _sortedMekanik = new Dictionary<string, string>();

            var Casted = (ComboBoxItem)cb_issu_option.SelectedItem;

            foreach (var item in _mechanicdb)
            {

                if (item.Value.Skills.Contains(Casted.Content) && (item.Value.Vehicles_case[0].Equals(Case_message) || item.Value.Vehicles_case[1].Equals(Case_message))) 
                { _sortedMekanik.Add(item.Key, item.Value.Namn); }
            }
            cb_mechanic_list.ItemsSource = _sortedMekanik.Keys;

          

            if (_sortedMekanik.Count > 0 ) { cb_mechanic_list.IsEnabled = true; cb_fordon_status.IsEnabled = true; cb_issu_option.IsEnabled = false; }





        }

        private void search_bt_Click(object sender, RoutedEventArgs e)
        {
            Error_msg.Content = string.Empty;
            tb_sc_caseId.IsReadOnly = true;


            if (_casedb.TryGetValue(tb_sc_caseId.Text, out VehicleCase obj))
            {
     
                Sp_sc_fordontyp.Visibility = Visibility.Visible;
                SP_sc_fordonreg.Visibility = Visibility.Visible;
                SP_sc_case_issu.Visibility = Visibility.Visible;
                Sp_sc_mekanik.Visibility = Visibility.Visible;
                Sp_sc_MekanikID.Visibility = Visibility.Visible;
                Sp_sc_Vehicle_Status.Visibility = Visibility.Visible;
                Sp_sc_coments.Visibility = Visibility.Visible;
                grid_edit_add.Visibility = Visibility.Visible;

                tb_sc_fordontyp.Text = obj.Vehicle_Type;
                tb_sc_fordonreg.Text = obj.Vehicle_Reg;
                tb_sc_caseissu.Text = obj.Vehicle_Issue;
                tb_sc_Mekanik.Text = obj.Mechanic_namn;
                tb_sc_MekanikID.Text = obj.Mechanic_ID.ToString();


                if (obj.Vehicle_Status.Equals("Avvaktar")) { cb_sc_fordon_status.SelectedIndex = 0; }
                else if (obj.Vehicle_Status.Equals("Pågående")) { cb_sc_fordon_status.SelectedIndex = 1; }
                else { cb_sc_fordon_status.SelectedIndex = 2; }
                Tb_sc_Comments.Text = obj.Comments;



            }
            else
            {
                Error_msg.Content = Wrong_msg;
                tb_sc_caseId.Text = string.Empty;
                tb_sc_caseId.IsReadOnly = false;
            }
            
        }


        private bool EnoughComponents(string issuProduct, string fordon)
        { _komponentdb.TryGetValue(_komponent, out Components _kompObj);

            bool _enoughcomponents = false;

            if (issuProduct.Equals(Enum.GetName(typeof(IUserDataAccess.Components), 1)))
            {
                var reserv = _kompObj.Breaks;
                if (fordon.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 4)))
                {
                    if (_kompObj.Breaks >= 2)
                    {
                        _kompObj.Breaks -= 2;
                        _enoughcomponents = reserv >= 2;

                    }
                }

                else if (fordon.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 5)))
                {
                    if (_kompObj.Breaks >= 4)
                    {

                        _kompObj.Breaks -= 4;
                        _enoughcomponents = reserv >= 4;

                    }
                }
                else 
                
                { 
                    
                    if (_kompObj.Breaks >= 6) 
                    {                       
                        _kompObj.Breaks -= 6;
                        _enoughcomponents = reserv >= 6;
                    }
                }
            }

            else if (issuProduct.Equals(Enum.GetName(typeof(IUserDataAccess.Components), 2)))
            {
                var reserv = _kompObj.Engine;
                if (_kompObj.Engine >= 1)
                {
                    _kompObj.Engine -= 1;
                    _enoughcomponents = reserv >= 1;

                }
            }
            else if (issuProduct.Equals(Enum.GetName(typeof(IUserDataAccess.Components), 3)))
            {
                var reserv = _kompObj.VehicleBody;
                if (_kompObj.VehicleBody >= 1)
                {                    
                    _kompObj.VehicleBody -= 1;
                    _enoughcomponents = reserv >= 1;

                }
            }
            else if (issuProduct.Equals(Enum.GetName(typeof(IUserDataAccess.Components), 4)))
            {
                var reserv = _kompObj.Windshield;
                if (_kompObj.Windshield >= 1)
                {
                   
                    _kompObj.Windshield -= 1;
                    _enoughcomponents = reserv >= 1;

                }
                    
            }
            else if (issuProduct.Equals(Enum.GetName(typeof(IUserDataAccess.Components), 5)))
            {
                var reserv = _kompObj.Wheel;
                if (fordon.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 4)))
                {
                    if (_kompObj.Wheel >= 2)
                    {                        
                        _kompObj.Wheel -= 2;
                        _enoughcomponents = reserv >= 2;

                    }
                }

                else if (fordon.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 5)))
                {
                    if (_kompObj.Wheel >= 4)
                    {
                        
                        _kompObj.Wheel -= 4;
                        _enoughcomponents = reserv >= 4;

                    }
                }

                else
                {
                    if (_kompObj.Wheel >= 6)
                    {
                        _kompObj.Wheel -= 6;
                        _enoughcomponents = reserv >= 6;

                    }
                }
            }


            Dictionary<int, int> a = new Dictionary<int, int>();

            _komponentdb.Remove(_komponent);
            _komponentdb.Add(_komponent, _kompObj);

            IUserDataAccess.Write<string, Components>(_komponentdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 11));

            return _enoughcomponents;
        }

        private void Bt_add_case_Click(object sender, RoutedEventArgs e)
        {
            string _caseid = Guid.NewGuid().ToString();

            var cb_issu = (ComboBoxItem)cb_issu_option.SelectedItem;


 
            if (cb_vehicle_list.SelectedIndex >= 0 &&
                cb_issu_option.SelectedIndex >= 0 &&
                cb_mechanic_list.SelectedIndex >= 0)
            {
      
                if (EnoughComponents(cb_issu.Content.ToString(), tb_vehicle_type.Text))
                {
                    _casedb.Add(_caseid, new VehicleCase(cb_vehicle_list.SelectedItem.ToString(), tb_vehicle_type.Text, cb_issu_option.Text, cb_mechanic_list.SelectedItem.ToString(), tb_mekanikname.Text, cb_fordon_status.Text, tb_case_comments.Text));
                    IUserDataAccess.Write<string, VehicleCase>(_casedb, Enum.GetName(typeof(IUserDataAccess.File_Type), 8));



                    if (tb_vehicle_type.Text.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 4)))
                    {             
      
                        _mcdb.TryGetValue(cb_vehicle_list.SelectedItem.ToString(), out Motorcycle _mObj);

                        _mObj.Caseid = _caseid;

                        _mcdb.Remove(cb_vehicle_list.SelectedItem.ToString());

                        _mcdb.Add(cb_vehicle_list.SelectedItem.ToString(), _mObj);

                        IUserDataAccess.Write<string, Motorcycle>(_mcdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 4));
                    }

                    else if (tb_vehicle_type.Text.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 5)))
                    {

                        _cardb.TryGetValue(cb_vehicle_list.SelectedItem.ToString(), out Car _cObj);

                        _cObj.Caseid = _caseid;

                        _cardb.Remove(cb_vehicle_list.SelectedItem.ToString());

                        _cardb.Add(cb_vehicle_list.SelectedItem.ToString(), _cObj);

                        IUserDataAccess.Write<string, Car>(_cardb, Enum.GetName(typeof(IUserDataAccess.File_Type), 5));
                    }

                    else if (tb_vehicle_type.Text.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 6)))
                    {

                        _trucdb.TryGetValue(cb_vehicle_list.SelectedItem.ToString(), out Truck _TObj);

                        _TObj.Caseid = _caseid;

                        _trucdb.Remove(cb_vehicle_list.SelectedItem.ToString());

                        _trucdb.Add(cb_vehicle_list.SelectedItem.ToString(), _TObj);

                        IUserDataAccess.Write<string, Truck>(_trucdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 6));
                    }


                    else if (tb_vehicle_type.Text.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 7)))
                    {

                        _busdb.TryGetValue(cb_vehicle_list.SelectedItem.ToString(), out Bus _bObj);

                        _bObj.Caseid = _caseid;

                        _busdb.Remove(cb_vehicle_list.SelectedItem.ToString());

                        _busdb.Add(cb_vehicle_list.SelectedItem.ToString(), _bObj);

                        IUserDataAccess.Write<string, Bus>(_busdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 7));
                    }

                    _tempRegnr.Remove(cb_vehicle_list.SelectedItem.ToString());

                    _mechanicdb.TryGetValue(cb_mechanic_list.SelectedItem.ToString(), out Mechanic _mecanicObj);
                    if (_mecanicObj.Vehicles_case[0].Equals(Case_message))
                    {
                        _mecanicObj.Vehicles_case[0] = _caseid;
                    }
                    else if (_mecanicObj.Vehicles_case[1].Equals(Case_message))
                    {
                        _mecanicObj.Vehicles_case[1] = _caseid;
                    }

                    _tempRegnr.Remove(cb_vehicle_list.SelectedItem.ToString());
                    cb_vehicle_list.Items.Refresh();

                    IUserDataAccess.Write<string, Mechanic>(_mechanicdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 2));

                }
                else 

                {
                    string msg = $"Finns inte tillräckligt komponenter.\n Vill du betälla ?";
                    string result = MessageBox.Show(msg, "Bekräftelse", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();
                    if (result.Equals("Yes")) { NavigationService.Navigate(new AllMechanic()); }
                    return;
                }

                NavigationService.Navigate(new Case());



            }
            else { Error_msg.Content = Wrong_msg; }
            

        }


        private void Tb_sc_searchbox_gotfocus(object sender, RoutedEventArgs e)
        {
            if (tb_sc_caseId.Text.Equals(TextRegNr)){ tb_sc_caseId.Text = string.Empty; tb_sc_caseId.IsReadOnly = false; }           

        }
        private void Tb_sc_searchbox_Lotfocus(object sender, RoutedEventArgs e)
        {
            if (tb_sc_caseId.Text.Equals(string.Empty)) { tb_sc_caseId.Text = TextRegNr; }

        }
        private void Tb_comment_gotfocus(object sender, RoutedEventArgs e)
        {
            if (tb_case_comments.Text.Equals(Textcomment)) { tb_case_comments.Text = string.Empty; }

        }
        private void Tb_comment_Lotfocus(object sender, RoutedEventArgs e)
        {
            if (tb_case_comments.Text.Equals(string.Empty)) { tb_case_comments.Text = Textcomment; }

        }

        private void Bt_remove_Case(object sender, RoutedEventArgs e)
        {

            string msg = $"Vill du ta bort ärandet från systemet ?";
            string result = MessageBox.Show(msg, "Bekräftelse", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();

            if (result.Equals("Yes"))
            {
                _casedb.Remove(tb_sc_caseId.Text);

                IUserDataAccess.Write<string, VehicleCase>(_casedb, Enum.GetName(typeof(IUserDataAccess.File_Type), 8));
                NavigationService.Navigate(new Case());
            }
           
        }

        private void Bt_case_done(object sender, RoutedEventArgs e)
        {
            

            string msg = $"Är du säkert ?";
            string result = MessageBox.Show(msg, "Bekräftelse", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();

            if (result.Equals("Yes") && cb_sc_fordon_status.SelectedIndex == 2)
            {

                Case_done(tb_sc_caseId.Text);
                NavigationService.Navigate(new Case());
            }


            else if (result.Equals("Yes") && cb_sc_fordon_status.SelectedIndex == 1)
            {
                Case_edit(tb_sc_caseId.Text);
                NavigationService.Navigate(new Case());

            }
            else { Error_msg.Content = "** Vänligen ändra status **"; }

        }





        //--------------------------------------------------------------------------------egenskapad method

        public void Case_edit(string _caseid)
        {
            _casedb.TryGetValue(_caseid, out VehicleCase _vObj);

            _casedb.Remove(tb_sc_caseId.Text);

            _casedb.Add(tb_sc_caseId.Text, _vObj);

            IUserDataAccess.Write<string, VehicleCase>(_casedb, Enum.GetName(typeof(IUserDataAccess.File_Type), 8));
            NavigationService.Navigate(new Case());
        }


        public void Case_done(string _caseId)
        {

            

            _casedb.TryGetValue(_caseId, out VehicleCase value);

            var fordoninfo = (AProperties)IUserDataAccess.GetVehicleInfo(value.Vehicle_Reg, value.Vehicle_Type);


            if (value.Vehicle_Type.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 4)))
            { _mcdb.Remove(value.Vehicle_Reg); IUserDataAccess.Write<string, Motorcycle>(_mcdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 4)); }

            else if (value.Vehicle_Type.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 5)))
            { _cardb.Remove(value.Vehicle_Reg); IUserDataAccess.Write<string, Car>(_cardb, Enum.GetName(typeof(IUserDataAccess.File_Type), 5)); }

            else if (value.Vehicle_Type.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 6)))
            { _trucdb.Remove(value.Vehicle_Reg); IUserDataAccess.Write<string, Truck>(_trucdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 6)); }

            else if (value.Vehicle_Type.Equals(Enum.GetName(typeof(IUserDataAccess.File_Type), 7)))
            { _busdb.Remove(value.Vehicle_Reg); IUserDataAccess.Write<string, Bus>(_busdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 7)); }



            _closedC.Add(_caseId, new Closed_Case(fordoninfo.Model, fordoninfo.Brand, value.Vehicle_Reg, value.Vehicle_Type, value.Vehicle_Issue, value.Mechanic_ID, value.Mechanic_namn, Enum.GetName(typeof(IUserDataAccess.VStatus), 3).ToString(), value.Comments));

            IUserDataAccess.Write<string, Closed_Case>(_closedC, Enum.GetName(typeof(IUserDataAccess.File_Type), 10));

            _casedb.Remove(_caseId);
            IUserDataAccess.Write<string, VehicleCase>(_casedb, Enum.GetName(typeof(IUserDataAccess.File_Type), 8));


            _regdb.Remove(value.Vehicle_Reg);


            IUserDataAccess.Write<string, string>(_regdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 9));


            _mechanicdb.TryGetValue(value.Mechanic_ID, out Mechanic _mekcObj);

            if (_mekcObj.Vehicles_case[0].Equals(_caseId)) { _mekcObj.Vehicles_case[0] = Case_message; }
            else if (_mekcObj.Vehicles_case[1].Equals(_caseId)) { _mekcObj.Vehicles_case[1] = Case_message; }

            _mechanicdb.Remove(value.Mechanic_ID);

            _mechanicdb.Add(value.Mechanic_ID, _mekcObj);

            IUserDataAccess.Write<string, Mechanic>(_mechanicdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 2));
        }

    }

}
