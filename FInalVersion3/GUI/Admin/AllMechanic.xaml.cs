using GUI.Home;
using Logic;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AllMechanic.xaml
    /// </summary>
    public partial class AllMechanic : Page
    {
        private delegate void SetDefaultvalue();
        private static Dictionary<string, Components> _Componentdb;
        private Dictionary<string, Mechanic> _mekanikdb;
        private Components _cObj;
        private static readonly string ComponentDictKey = "Components";
        private static readonly string noskills = "** Angav ingen Kompetens **";


        public AllMechanic()
        {
            _Componentdb = IUserDataAccess.Read<string, Components>(Enum.GetName(typeof(IUserDataAccess.File_Type), 11));
            _mekanikdb = IUserDataAccess.Read<string, Mechanic>(Enum.GetName(typeof(IUserDataAccess.File_Type), 2));




            SetDefaultvalue deligate_obj = new SetDefaultvalue(InitializeComponent);

            deligate_obj += SetDefaultValuetoStock;
            deligate_obj += GetInfofromStock;


            deligate_obj();

            if (!_mekanikdb.Count.Equals(0))
            { cb_choose_mekanik.IsEnabled = true; cb_choose_mekanik.ItemsSource = _mekanikdb.Keys; }

        }




        public static void SetDefaultValuetoStock()
        {
            if (_Componentdb.Count.Equals(0))
            {
                _Componentdb.Add(ComponentDictKey, new Components(6, 1, 1, 1, 6));
                IUserDataAccess.Write<string, Components>(_Componentdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 11));

            }
        }



        private void GetInfofromStock()
        {
            _Componentdb.TryGetValue(ComponentDictKey, out _cObj);

            antal_broms.Text = _cObj.Breaks.ToString();
            antal_kaross.Text = _cObj.VehicleBody.ToString();
            antal_motor.Text = _cObj.Engine.ToString();
            antal_vindruta.Text = _cObj.Windshield.ToString();
            antal_wheel.Text = _cObj.Wheel.ToString();



        }


        public void ModifyAndWriteToComponentDict()
        {
            _Componentdb.Remove(ComponentDictKey);
            _Componentdb.Add(ComponentDictKey, _cObj);
            IUserDataAccess.Write<string, Components>(_Componentdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 11));
            GetInfofromStock();
        }



        private void IncreaseDecreaseStockGoods(object sender, RoutedEventArgs e)
        {

            if (sender.Equals(bt_Plus_Broms)) { _cObj.Breaks += 2; }
            else if (sender.Equals(Bt_minus_Broms)) { if (_cObj.Breaks > 0) _cObj.Breaks -= 2; }

            else if (sender.Equals(BT_Plus_motor)) { _cObj.Engine += 1; }
            else if (sender.Equals(Bt_minus_motor)) { if (_cObj.Engine > 0) _cObj.Engine -= 1; }

            else if (sender.Equals(Bt_Plus_Kaross)) { _cObj.VehicleBody += 1; }
            else if (sender.Equals(Bt_minus_kaross)) { if (_cObj.VehicleBody > 0) _cObj.VehicleBody -= 1; }

            else if (sender.Equals(Bt_Plus_Vindruta)) { _cObj.Windshield += 1; }
            else if (sender.Equals(Bt_minus_vindruta)) { if (_cObj.Windshield > 0) _cObj.Windshield -= 1; }

            else if (sender.Equals(Bt_Plus_wheel)) { _cObj.Wheel += 2; }
            else if (sender.Equals(Bt_minus_wheel)) { if (_cObj.Wheel > 0) _cObj.Wheel -= 2; }

            ModifyAndWriteToComponentDict();

        }



        private void cb_choose_vehicle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mekanikdb.TryGetValue(cb_choose_mekanik.SelectedItem.ToString(), out Mechanic _mekObj);

            tb_mekaniknamn.Text = _mekObj.Namn;
            tb_mekanik_birth.Text = _mekObj.Birthdate;
            tb_mekanik_lastdate.Text = _mekObj.LastDate;
            tb_mekanik_Case1.Text = _mekObj.Vehicles_case[0];
            tb_mekanik_Case2.Text = _mekObj.Vehicles_case[1];
            tb_mekanik_regiterdate.Text = _mekObj.RegisteradeDatum;

            if (_mekObj.Skills.Count > 0 )
            {
                string combindedString = string.Join(",", _mekObj.Skills);
                tb_mekanik_skils.Text = combindedString;
            }
            else
            {
                tb_mekanik_skils.Text = "Inget Kompetense valt ännu";

            }

        }




    }
}
