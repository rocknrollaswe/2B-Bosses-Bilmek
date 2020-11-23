using Logic;
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
using Logic.Vehicle;
using Logic.Services;
using System.Buffers;
using System.Linq;
using System.IO;
using GUI;
using GUI.Home;

namespace GUI.Pages
{
    /// <summary>
    /// Interaction logic for Add_vehicle.xaml
    /// </summary>
    public partial class Add_vehicle : Page
    {

        private CheckPost _check;

        private  bool found;
        private string vehicle_typ;




        public Add_vehicle()
        {


            InitializeComponent();
            _check = new CheckPost();

            



        }
        //---------------------------------------------------
        private readonly string Brand = "-- Fordonets Märke --";
        private readonly string Model  = "-- Fordonets Modell --";
        private readonly string Odometer = "-- Fordonets Mätare --";
        private readonly string RegNr = "-- Ange Registreringsnummer --";
        private readonly string Maxwweight = "-- Maxvikt last --";
        private readonly string Max_passanger = "-- Max antal passagerare --";
        private readonly string Wrong_msg = "** Fel inmatning **";
        //---------------------------------------------------








        private void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }


        private void cb_choose_vehicle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cb_choose_vehicle.SelectedIndex)
            {
                case 0:

                    add_sp_hook.Visibility = (Visibility)2;
                    add_sp_typcar.Visibility = (Visibility)2;
                    add_sp_maxlast.Visibility = (Visibility)2;
                    add_sp_passanger.Visibility = (Visibility)2;
                    bt_add_vehicle.Visibility = 0;
                    break;

                case 1:

                    add_sp_hook.Visibility = (Visibility)0;
                    add_sp_typcar.Visibility = (Visibility)0;
                    add_sp_maxlast.Visibility = (Visibility)2;
                    add_sp_passanger.Visibility = (Visibility)2;
                    bt_add_vehicle.Visibility = 0;
                    break;

                case 2:

                    add_sp_hook.Visibility = (Visibility)2;
                    add_sp_typcar.Visibility = (Visibility)2;
                    add_sp_maxlast.Visibility = (Visibility)0;
                    add_sp_passanger.Visibility = (Visibility)2;
                    bt_add_vehicle.Visibility = 0;
                    break;

                case 3:

                    add_sp_hook.Visibility = (Visibility)2;
                    add_sp_typcar.Visibility = (Visibility)2;
                    add_sp_maxlast.Visibility = (Visibility)2;
                    add_sp_passanger.Visibility = (Visibility)0;
                    bt_add_vehicle.Visibility = 0;
                    break;


                default:
                    cb_car_hook.Visibility = (Visibility)2;
                    cb_car_option.Visibility = (Visibility)2;
                    tb_weight.Visibility = (Visibility)2;
                    tb_passanger.Visibility = (Visibility)2;
                    bt_add_vehicle.Visibility = (Visibility)2;
                    break;
            }
        }


        private void Got_focuse(object sender, RoutedEventArgs e)
        {
            var _sender = (TextBox)sender;
           
            if (_sender.Text.Equals(Brand)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Model)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Odometer)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(RegNr)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Maxwweight)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Max_passanger)) { _sender.Text = string.Empty; }

            else if (_sender.Text.Equals(RegNr) && _sender.Name.Equals("tb_sc_vehicle_rg")) { _sender.Text = string.Empty; }

        }

        private void Lost_focuse(object sender, RoutedEventArgs e)
        {
        
            var _sender = (TextBox)sender;

            
            if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_vehicle_brand")) { _sender.Text = Brand; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_fordon_modell")) { _sender.Text = Model; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_fordon_odometer")) { _sender.Text = Odometer; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_regnr")) { _sender.Text = RegNr; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_weight")) { _sender.Text = Maxwweight; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_passanger")) { _sender.Text = Max_passanger; }

            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_sc_vehicle_rg")) { _sender.Text = RegNr; }

        }





        private void Add_vehicle_Dict(object sender, RoutedEventArgs e)
        {

            int maxweight = 0, passanger = 0;

            if (tb_vehicle_brand.Text.Equals(Brand) || tb_fordon_modell.Text.Equals(Model) ||
                tb_fordon_odometer.Text.Equals(Odometer) || tb_regnr.Text.Equals(RegNr) || cb_fuel.SelectedIndex == -1 ||
                    (cb_car_option.SelectedIndex == -1 || cb_car_hook.SelectedIndex == -1) && add_sp_typcar.Visibility == Visibility.Visible ||
                    (tb_weight.Text.Equals(MaxWidth) || !Int32.TryParse(tb_weight.Text, out maxweight)) && add_sp_maxlast.Visibility == Visibility.Visible ||
                    (tb_passanger.Text.Equals(Max_passanger) || !Int32.TryParse(tb_passanger.Text, out passanger)) && add_sp_passanger.Visibility == Visibility.Visible ||
                    !Int32.TryParse(tb_fordon_odometer.Text, out int odometer) || !IUserDataAccess.LicenseVerification(tb_regnr.Text))
            {
                Error_msg.Content = Wrong_msg;
            }

            
            else if (!_check.Reg_check(tb_regnr.Text).Item1)
            {
                if (cb_choose_vehicle.SelectedIndex == 0)
                {
                    var Creat_Vehicle = IUserDataAccess.Read<string, Motorcycle>(cb_choose_vehicle.Text);

                    var obj = new Motorcycle(cb_choose_vehicle.Text, tb_vehicle_brand.Text, tb_fordon_modell.Text, odometer, cb_fuel.Text, tb_regnr.Text);
                    Creat_Vehicle.Add(tb_regnr.Text, obj);
                    IUserDataAccess.Write<string, Motorcycle>(Creat_Vehicle, cb_choose_vehicle.Text);
                    NavigationService.Navigate(new Add_vehicle());
                }
                else if (cb_choose_vehicle.SelectedIndex == 1)
                {

                    bool hook = cb_car_hook.Text.Equals("Ja") ? true : false;

                    var Creat_Vehicle = IUserDataAccess.Read<string, Car>(cb_choose_vehicle.Text);

                    var obj = new Car(cb_choose_vehicle.Text, tb_vehicle_brand.Text, tb_fordon_modell.Text, odometer, hook, cb_car_option.Text, cb_fuel.Text, tb_regnr.Text);
                    Creat_Vehicle.Add(tb_regnr.Text, obj);

                    IUserDataAccess.Write<string, Car>(Creat_Vehicle, cb_choose_vehicle.Text);
                    NavigationService.Navigate(new Add_vehicle());
                }
                else if (cb_choose_vehicle.SelectedIndex == 2)
                {
                    var Creat_Vehicle = IUserDataAccess.Read<string, Truck>(cb_choose_vehicle.Text);

                    var obj = new Truck(cb_choose_vehicle.Text, tb_vehicle_brand.Text, tb_fordon_modell.Text, odometer, cb_fuel.Text, maxweight, tb_regnr.Text);
                    Creat_Vehicle.Add(tb_regnr.Text, obj);

                    IUserDataAccess.Write<string, Truck>(Creat_Vehicle, cb_choose_vehicle.Text);
                    NavigationService.Navigate(new Add_vehicle());
                }
                else if (cb_choose_vehicle.SelectedIndex == 3)
                {
                    var Creat_Vehicle = IUserDataAccess.Read<string, Bus>(cb_choose_vehicle.Text);

                    var obj = new Bus(cb_choose_vehicle.Text, tb_vehicle_brand.Text, tb_fordon_modell.Text, odometer, passanger, cb_fuel.Text, tb_regnr.Text);
                    Creat_Vehicle.Add(tb_regnr.Text, obj);

                    IUserDataAccess.Write<string, Bus>(Creat_Vehicle, cb_choose_vehicle.Text);
                    NavigationService.Navigate(new Add_vehicle());
                }
                var licensePlatelist = IUserDataAccess.Read<string, string>(Enum.GetName(typeof(IUserDataAccess.File_Type),9));
                licensePlatelist.Add(tb_regnr.Text, cb_choose_vehicle.Text);
  
                IUserDataAccess.Write<string, string>(licensePlatelist, Enum.GetName(typeof(IUserDataAccess.File_Type), 9));


            }
            else
            {
                Error_msg.Content = "** Registering nr redan finns i vårt system **";
            }
        }




        private void Find_vehicle(object sender, RoutedEventArgs e)
        {
            Error_msg.Content = string.Empty;
            found = _check.Reg_check(tb_sc_vehicle_rg.Text).Item1;
           vehicle_typ = _check.Reg_check(tb_sc_vehicle_rg.Text).Item2;
          

            if (found) 
            {
                var dict_value = IUserDataAccess.GetVehicleInfo(tb_sc_vehicle_rg.Text, vehicle_typ);
                tb_sc_vehicle_rg.IsReadOnly = true;
                AProperties vehicleProperties = (AProperties)dict_value;


                edit_sp_fordontyp.Visibility = 0;
                edit_sp_regdate.Visibility = 0;
                edit_sp_brand.Visibility = 0;
                edit_sp_model.Visibility = 0;
                edit_sp_Odometer.Visibility = 0;
                edit_sp_fuel.Visibility = 0;

                grid_edit_add.Visibility = 0;


                tb_sc_fordontyp.Text = vehicleProperties.Vehicle_Type;
                tb_sc_vehicle_brand.Text = vehicleProperties.Brand;
                tb_sc_vehicle_modell.Text = vehicleProperties.Model;
                tb_sc_vehicle_odometer.Text = vehicleProperties.Odometer.ToString();
                cb_sc_fuel.Text = vehicleProperties.Fuel_Type;
                tb_sc_regdate.Text = vehicleProperties.Registration_Date.ToString();

                if (vehicleProperties.Vehicle_Type == Enum.GetName(typeof(IUserDataAccess.File_Type), 5))
                {
                    edit_sp_typcar.Visibility = 0;
                    edit_sp_hook.Visibility = 0;
                    var bil = (Car)vehicleProperties;
                    cb_sc_car_option.Text = bil.Type_Of_Car.ToString();
                    cb_sc_car_hook.Text = bil.Dragkrok.ToString();

                }
                else if (vehicleProperties.Vehicle_Type == Enum.GetName(typeof(IUserDataAccess.File_Type), 6))
                {
                    edit_sp_maxlast.Visibility = 0;
                    var lastbil = (Truck)vehicleProperties;
                    tb_sc_weight.Text = lastbil.Max_Load.ToString();
                }
                else if (vehicleProperties.Vehicle_Type == Enum.GetName(typeof(IUserDataAccess.File_Type), 7))
                {
                    edit_sp_passanger.Visibility = 0;
                    var buss = (Bus)vehicleProperties;
                    tb_sc_passanger.Text = buss.Max_Passengers.ToString();
                }
            }
            else
            {
                Error_msg.Content = Wrong_msg;
                tb_sc_vehicle_rg.Text = string.Empty;
            }
        }

        private void Delete_vehicle(object sender, RoutedEventArgs e)        
        {



            var dict = IUserDataAccess.Read<string, object>(vehicle_typ);
            var lisence = IUserDataAccess.Read<string, string>(Enum.GetName(typeof(IUserDataAccess.File_Type), 9));

            string msg = $"Vill du ta bort {vehicle_typ} från systemet ?";
            string result = MessageBox.Show(msg, "Bekräftelse", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();

            if (result.Equals("Yes"))
            {
                lisence.Remove(tb_sc_vehicle_rg.Text);
                dict.Remove(tb_sc_vehicle_rg.Text);
                IUserDataAccess.Write(lisence, Enum.GetName(typeof(IUserDataAccess.File_Type), 9));
                IUserDataAccess.Write(dict, vehicle_typ);
                NavigationService.Navigate(new Add_vehicle());
            }


        }

        private void Change_vehicle_info(object sender, RoutedEventArgs e)
        {
            



            var lisence = IUserDataAccess.Read<string, string>(Enum.GetName(typeof(IUserDataAccess.File_Type), 9));

            var dict = IUserDataAccess.GetVehicleInfo(tb_sc_vehicle_rg.Text, vehicle_typ);

            AProperties currentVehicleinfo = (AProperties)dict;

            string msg = $"Vill du ändra {vehicle_typ} info ?";
            string result = MessageBox.Show(msg, "Bekräftelse", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();


            bool odometer_bool = Int32.TryParse(tb_sc_vehicle_odometer.Text, out int odometer);
            bool passanger_bool = Int32.TryParse(tb_sc_passanger.Text, out int passanger);
            bool weight_bool = Int32.TryParse(tb_sc_weight.Text, out int weight);
         


            if (result.Equals("Yes") && odometer_bool && odometer >= currentVehicleinfo.Odometer )
            { 
                currentVehicleinfo.Fuel_Type = cb_sc_fuel.Text;
                currentVehicleinfo.Odometer = odometer;


                if (vehicle_typ == Enum.GetName(typeof(IUserDataAccess.File_Type), 4))
                {

                    Motorcycle castedMc = (Motorcycle)currentVehicleinfo;

                    Dictionary<string, Motorcycle> mc = IUserDataAccess.Read<string, Motorcycle>(Enum.GetName(typeof(IUserDataAccess.File_Type), 4));
                    
                    mc.Remove(tb_sc_vehicle_rg.Text);
                    lisence.Remove(tb_sc_vehicle_rg.Text);                    


                    mc.Add(castedMc.Registration_Nr, castedMc);
                    lisence.Add(castedMc.Registration_Nr, castedMc.Vehicle_Type);
                    IUserDataAccess.Write(mc, vehicle_typ);
                }
                else if (vehicle_typ == Enum.GetName(typeof(IUserDataAccess.File_Type), 5))
                {
                    Dictionary<string, Car> car = IUserDataAccess.Read<string, Car>(Enum.GetName(typeof(IUserDataAccess.File_Type), 5));
                    car.Remove(tb_sc_vehicle_rg.Text);
                    lisence.Remove(tb_sc_vehicle_rg.Text);


                    Car castedCar = (Car)currentVehicleinfo;
                    castedCar.Dragkrok = cb_sc_car_hook.Text.Equals("Ja");
                    castedCar.Type_Of_Car = cb_sc_car_option.Text;


                    car.Add(castedCar.Registration_Nr, castedCar);
                    lisence.Add(castedCar.Registration_Nr, castedCar.Vehicle_Type);
                    IUserDataAccess.Write(car, vehicle_typ);
                }
                else if (vehicle_typ == Enum.GetName(typeof(IUserDataAccess.File_Type), 6))
                {
                    if ( weight_bool )
                    { 
                        Dictionary<string, Truck> truck = IUserDataAccess.Read<string, Truck>(Enum.GetName(typeof(IUserDataAccess.File_Type), 6));
                        truck.Remove(tb_sc_vehicle_rg.Text);
                        lisence.Remove(tb_sc_vehicle_rg.Text);


                        Truck castedTruck = (Truck)currentVehicleinfo;
                        castedTruck.Max_Load = weight;

                        truck.Add(castedTruck.Registration_Nr, castedTruck);
                        lisence.Add(castedTruck.Registration_Nr, castedTruck.Vehicle_Type);
                        IUserDataAccess.Write(truck, vehicle_typ);
                    }else
                    {
                        
                        Error_msg.Content = Wrong_msg;
                        return;
                    }

                }
                else if (vehicle_typ == Enum.GetName(typeof(IUserDataAccess.File_Type), 7))
                {
                    if (passanger_bool)
                    {
                        Dictionary<string, Bus> bus = IUserDataAccess.Read<string, Bus>(Enum.GetName(typeof(IUserDataAccess.File_Type), 7));
                        bus.Remove(tb_sc_vehicle_rg.Text);
                        lisence.Remove(tb_sc_vehicle_rg.Text);


                        Bus castedBus = (Bus)currentVehicleinfo;
                        castedBus.Max_Passengers = passanger;

                        bus.Add(castedBus.Registration_Nr, castedBus);
                        lisence.Add(castedBus.Registration_Nr, castedBus.Vehicle_Type);
                        IUserDataAccess.Write(bus, vehicle_typ);
                    }
                    else
                    {
                        Error_msg.Content = Wrong_msg;
                        return;
                    }
                }
                NavigationService.Navigate(new Add_vehicle());
            }
            else if (result.Equals("No"))
            { return; }
            else
            {
                Error_msg.Content = Wrong_msg;
            }
        }
       


    }
}
