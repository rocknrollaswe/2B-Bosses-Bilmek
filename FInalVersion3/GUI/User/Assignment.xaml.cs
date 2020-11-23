using System;
using System.Collections.Generic;
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
using GUI.Home;
using Logic;
using Logic.Vehicle;
using Logic.Entities;
using System.Linq;

namespace GUI.Pages
{
    /// <summary>
    /// Interaction logic for Assignment.xaml
    /// </summary>
    public partial class Assignment : Page
    {
        private Dictionary<string, Closed_Case> _closedC;
        private Dictionary<string, string> _regdb;
        private Dictionary<string, Mechanic> _mechanicdb;
        private Dictionary<string, VehicleCase> _casedb;
        private readonly string Case_message = "**Finns inget ärande**";
        private dynamic _vehicleInfo;
        Case _donecase = new Case();



        private readonly Dictionary<string, Motorcycle> _mcdb;
        private readonly Dictionary<string, Car> _cardb;
        private readonly Dictionary<string, Truck> _trucdb;
        private readonly Dictionary<string, Bus> _busdb;

        public Assignment()
        {
            InitializeComponent();

            _mcdb = IUserDataAccess.Read<string, Motorcycle>(Enum.GetName(typeof(IUserDataAccess.File_Type), 4));

            _cardb = IUserDataAccess.Read<string, Car>(Enum.GetName(typeof(IUserDataAccess.File_Type), 5));

            _trucdb = IUserDataAccess.Read<string, Truck>(Enum.GetName(typeof(IUserDataAccess.File_Type), 6));

            _busdb = IUserDataAccess.Read<string, Bus>(Enum.GetName(typeof(IUserDataAccess.File_Type), 7));


            _casedb = IUserDataAccess.Read<string, VehicleCase>(Enum.GetName(typeof(IUserDataAccess.File_Type), 8));
            _mechanicdb = IUserDataAccess.Read<string, Mechanic>(Enum.GetName(typeof(IUserDataAccess.File_Type), 2));
            _closedC = IUserDataAccess.Read<string, Closed_Case>(Enum.GetName(typeof(IUserDataAccess.File_Type), 10));
            _regdb = IUserDataAccess.Read<string, string>(Enum.GetName(typeof(IUserDataAccess.File_Type), 9));
            DisplayFirstAssignment();
            DisplaySecoundAssignment();
            if (tb_workstatus_case1.Text.Equals(Enum.GetName(typeof(IUserDataAccess.VStatus), 1))) Sp_case1_start.Visibility = Visibility.Visible;
            if (tb_workstatus_case2.Text.Equals(Enum.GetName(typeof(IUserDataAccess.VStatus), 1))) Sp_case2_start.Visibility = Visibility.Visible;
        }

        private void DisplayFirstAssignment()
        {


            _mechanicdb.TryGetValue(HomePage._GCU[1].ToString(), out var _current_mechanic);
            bool _findcase = _casedb.TryGetValue(_current_mechanic.Vehicles_case[0], out var _case1);


            if (_findcase)
            {
                Gb_case1.Visibility = Visibility.Visible;
                tb_ifnocase_case1.Visibility = Visibility.Collapsed;
                _vehicleInfo = (AProperties) IUserDataAccess.GetVehicleInfo(_case1.Vehicle_Reg, _case1.Vehicle_Type);

                tb_fordon_reg_case1.Text = _case1.Vehicle_Reg;
                tb_fordontyp_case1.Text = _case1.Vehicle_Type;
                tb_fordonbrand_case1.Text = _vehicleInfo.Brand;
                tb_fordonmodel_case1.Text = _vehicleInfo.Model;
                tb_caseid_case1.Text = _current_mechanic.Vehicles_case[0];
                tb_issu_case1.Text = _case1.Vehicle_Issue;
                tb_workstatus_case1.Text = _case1.Vehicle_Status;
                tb_fordon_comment_case1.Text = _case1.Comments;
            }
            else { tb_ifnocase_case1.Visibility = Visibility.Visible; Gb_case1.Visibility = Visibility.Collapsed; }

        }


        private void DisplaySecoundAssignment()
        {
            //var _current_mechanic = _mechanicdb.Where(x=> x.Key.Equals(HomePage._GCU[1].ToString())).Select( x=> x.Value).ToList();


            _mechanicdb.TryGetValue(HomePage._GCU[1].ToString(), out var _current_mechanic);
            bool _findcase = _casedb.TryGetValue(_current_mechanic.Vehicles_case[1], out var _case2);


            if (_findcase)
            {
                Gb_case2.Visibility = Visibility.Visible;
                
                tb_ifnocase_case2.Visibility = Visibility.Collapsed;

                _vehicleInfo = (AProperties)IUserDataAccess.GetVehicleInfo(_case2.Vehicle_Reg, _case2.Vehicle_Type);

                tb_fordon_reg_case2.Text = _case2.Vehicle_Reg;
                tb_fordontyp_case2.Text = _case2.Vehicle_Type;
                tb_fordonbrand_case2.Text = _vehicleInfo.Brand;
                tb_fordonmodel_case2.Text = _vehicleInfo.Model;
                tb_caseid_case2.Text = _current_mechanic.Vehicles_case[1];
                tb_issu_case2.Text = _case2.Vehicle_Issue;
                tb_workstatus_case2.Text = _case2.Vehicle_Status;
                tb_fordon_comment_case2.Text = _case2.Comments;
            }
            else {  tb_ifnocase_case2.Visibility = Visibility.Visible; Gb_case2.Visibility = Visibility.Collapsed; }

        }


        private void Bt_case1_start_Click(object sender, RoutedEventArgs e)
        {
            _casedb.TryGetValue(tb_caseid_case1.Text, out VehicleCase _vehicleCaseObj);

            _vehicleCaseObj.Vehicle_Status = Enum.GetName(typeof(IUserDataAccess.VStatus), 2);

            IUserDataAccess.Write<string, VehicleCase>(_casedb, Enum.GetName(typeof(IUserDataAccess.File_Type), 8));

            NavigationService.Navigate(new Assignment());
        }


        private void Bt_case2_start_Click(object sender, RoutedEventArgs e)
        {
            _casedb.TryGetValue(tb_caseid_case2.Text, out VehicleCase _vehicleCaseObj);

            _vehicleCaseObj.Vehicle_Status = Enum.GetName(typeof(IUserDataAccess.VStatus), 2);

            IUserDataAccess.Write<string, VehicleCase>(_casedb, Enum.GetName(typeof(IUserDataAccess.File_Type), 8));

            NavigationService.Navigate(new Assignment());





        }

        private void Bt_case1_done_click(object sender, RoutedEventArgs e)
        {


            _donecase.Case_done(tb_caseid_case1.Text);

            NavigationService.Navigate(new Assignment());

        }






        private void Bt_case2_done_click(object sender, RoutedEventArgs e)
        {


            _donecase.Case_done(tb_caseid_case2.Text);

            NavigationService.Navigate(new Assignment());
        }





    }

}
