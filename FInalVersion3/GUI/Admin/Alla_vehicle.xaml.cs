using Logic;
using Logic.Entities;
using Logic.Vehicle;
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
using System.Linq;

namespace GUI.Pages
{
    /// <summary>
    /// Interaction logic for Alla_vehicle.xaml
    /// </summary>
    public partial class Alla_vehicle : Page
    {


        private Dictionary<string, Car> _cardb;
        private Dictionary<string, Motorcycle> _mcdb;
        private Dictionary<string, Truck> _truckdb;
        private Dictionary<string, Bus> _busdb;
        private Dictionary<string, VehicleCase> _casedb;

        private Dictionary<string, Mechanic> _mekanikdb;


        private string nocasemsg= "** Inge äranden skapat ännu **";
        private string noinfomsg = "** Inget information **";

        public Alla_vehicle()
        { 
            InitializeComponent();
            _cardb = IUserDataAccess.Read<string, Car>(Enum.GetName(typeof(IUserDataAccess.File_Type), 5));
            _mcdb = IUserDataAccess.Read<string, Motorcycle>(Enum.GetName(typeof(IUserDataAccess.File_Type), 4));
            _truckdb = IUserDataAccess.Read<string, Truck>(Enum.GetName(typeof(IUserDataAccess.File_Type), 6));
            _busdb = IUserDataAccess.Read<string, Bus>(Enum.GetName(typeof(IUserDataAccess.File_Type), 7));

            _casedb = IUserDataAccess.Read<string, VehicleCase>(Enum.GetName(typeof(IUserDataAccess.File_Type), 8));

            _mekanikdb = IUserDataAccess.Read<string, Mechanic>(Enum.GetName(typeof(IUserDataAccess.File_Type), 2));

            LB_Car.ItemsSource = _cardb.Keys;
            LB_MC.ItemsSource = _mcdb.Keys;
            LB_Truck.ItemsSource = _truckdb.Keys;
            LB_Bus.ItemsSource = _busdb.Keys;
        }

        private void LB_Car_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _cardb.TryGetValue(LB_Car.SelectedItem.ToString(), out Car _carObj);
                tb_brand_car.Text = _carObj.Brand;
                tb_model_car.Text = _carObj.Model;




                if (!_carObj.Caseid.Equals(string.Empty))
                {


                    _casedb.TryGetValue(_carObj.Caseid, out VehicleCase caseObj);


                    _mekanikdb.TryGetValue(caseObj.Mechanic_ID, out Mechanic _mekanikObj);
                    tb_caseID_car.Text = _carObj.Caseid;
                    tb_mekaniknamn_car.Text = _mekanikObj.Namn;
                    Tb_mekanikid_car.Text = caseObj.Mechanic_ID;
                    tb_workstatus_car.Text = caseObj.Vehicle_Status;

                }
                else
                {
                    tb_caseID_car.Text = nocasemsg;
                    tb_mekaniknamn_car.Text = noinfomsg;
                    Tb_mekanikid_car.Text = noinfomsg;
                    tb_workstatus_car.Text = noinfomsg;
                }

            }
            catch (Exception)
            {
                string msg = $"Opps!! Något har gått fel vid filhantering.\nVill du se detaljer om detta undantag";
                var svar = MessageBox.Show(msg, "Undantag", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();
                if (svar.Equals("Yes")) { throw new Exception("Kanske jason filen för mekanik,Registreringsskylt eller något av fordon file saknas."); }
                

            }




        }

        
        private void LB_MC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                _mcdb.TryGetValue(LB_MC.SelectedItem.ToString(), out Motorcycle _mcObj);

                TB_brand_mc.Text = _mcObj.Brand;
                TB_model_mc.Text = _mcObj.Model;



                if (!_mcObj.Caseid.Equals(string.Empty))
                {
                    _casedb.TryGetValue(_mcObj.Caseid, out VehicleCase caseObj);
                    _mekanikdb.TryGetValue(caseObj.Mechanic_ID, out Mechanic _mekanikObj);
                    TB_caseid_mc.Text = _mcObj.Caseid;
                    TB_mekaniknamn_mc.Text = _mekanikObj.Namn;
                    TB_mekanikid_mc.Text = caseObj.Mechanic_ID;
                    TB_workstatus_mc.Text = caseObj.Vehicle_Status;

                }
                else
                {
                    TB_caseid_mc.Text = nocasemsg;
                    TB_mekaniknamn_mc.Text = noinfomsg;
                    TB_mekanikid_mc.Text = noinfomsg;
                    TB_workstatus_mc.Text = noinfomsg;
                }
            }
            catch (Exception)
            {
                string msg = $"Hoppsan!! Något har gått fel vid filhantering.\nVill du se detaljer om detta undantag ?";
                var svar = MessageBox.Show(msg, "Undantag", MessageBoxButton.YesNo, MessageBoxImage.Error).ToString();
                if (svar.Equals("Yes")) { throw new Exception("Kanske json filen för mekaniker, registreringsskylt eller något av fordons filerna saknas! "); }


            }














        }

        private void LB_Truck_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {

                _truckdb.TryGetValue(LB_Truck.SelectedItem.ToString(), out Truck _truckObj);


                Tb_brand_truck.Text = _truckObj.Brand;
                Tb_model_truck.Text = _truckObj.Model;



                if (!_truckObj.Caseid.Equals(string.Empty))
                {

                    _casedb.TryGetValue(_truckObj.Caseid, out VehicleCase caseObj);
                    _mekanikdb.TryGetValue(caseObj.Mechanic_ID, out Mechanic _mekanikObj);

                    Tb_caseid_truck.Text = _truckObj.Caseid;
                    TB_mekaniknamn_truck.Text = _mekanikObj.Namn;
                    TB_mekanikid_truck.Text = caseObj.Mechanic_ID;
                    TB_workstatus_truck.Text = caseObj.Vehicle_Status;
                }


                else
                {
                    Tb_caseid_truck.Text = nocasemsg;
                    TB_mekaniknamn_truck.Text = noinfomsg;
                    TB_mekanikid_truck.Text = noinfomsg;
                    TB_workstatus_truck.Text = noinfomsg;

                }
            }
            catch (Exception)
            {
                string msg = $"Opps!! Något har gått fel vid filhantering.\nVill du se detaljer om detta undantag";
                var svar = MessageBox.Show(msg, "Undantag", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();
                if (svar.Equals("Yes")) { throw new Exception("Kanske jason filen för mekanik,Registreringsskylt eller något av fordon file saknas."); }


            }

        }

        private void LB_Bus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _busdb.TryGetValue(LB_Bus.SelectedItem.ToString(), out Bus _busObj);

                Tb_brand_bus.Text = _busObj.Brand;
                TB_model_bus.Text = _busObj.Model;



                if (!_busObj.Caseid.Equals(string.Empty))
                {


                    _casedb.TryGetValue(_busObj.Caseid, out VehicleCase caseObj);
                    _mekanikdb.TryGetValue(caseObj.Mechanic_ID, out Mechanic _mekanikObj);


                    Tb_caseid_bus.Text = _busObj.Caseid;
                    Tb_mekaniknamn_bus.Text = _mekanikObj.Namn;
                    Tb_mekanikId_bus.Text = caseObj.Mechanic_ID;
                    Tb_workstatus_bus.Text = caseObj.Vehicle_Status;

                }
                else
                {
                    Tb_caseid_bus.Text = nocasemsg;
                    Tb_mekaniknamn_bus.Text = noinfomsg;
                    Tb_mekanikId_bus.Text = noinfomsg;
                    Tb_workstatus_bus.Text = noinfomsg;

                }
            }
            catch (Exception)
            {
                string msg = $"Opps!! Något har gått fel vid filhantering.\nVill du se detaljer om detta undantag";
                var svar = MessageBox.Show(msg, "Undantag", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();
                if (svar.Equals("Yes")) { throw new Exception("Kanske jason filen för mekanik,Registreringsskylt eller något av fordon file saknas."); }


            }



        }




    }
}
