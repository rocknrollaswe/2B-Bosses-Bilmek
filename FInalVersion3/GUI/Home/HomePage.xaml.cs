using GUI.Login;
using GUI.Pages;
using Logic;
using Logic.Entities;
using Logic.Services;
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

namespace GUI.Home
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {



        private string searchboxtxt = "-- SMART SÖK --";
        private static object[] Current_user;
        public static object[] _GCU { get { if (Current_user == null) { Current_user = new object[4]; } return Current_user;} }
        public HomePage()
        {


            InitializeComponent();


            Sing_out_bt.Content = $"Logga ut [{ _GCU[0].ToString() }]";
            
           if(_GCU[0].Equals(Enum.GetName(typeof(IUserDataAccess.TypeOfUser), 1))) 
            { 
                Admin_Panel.Visibility = Visibility.Visible; 
                Sp_case_page.Visibility = Visibility.Collapsed;
                Uri adminprofil = new Uri("/Admin/AdminProfile.xaml", UriKind.Relative);
                Menubar_frame.Source = adminprofil;
            }
            else { Admin_Panel.Visibility = Visibility.Collapsed; Sp_case_page.Visibility = Visibility.Visible;}

           

            
        }



        private void Sing_out_BT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }


        private void Search_box_got_focuse(object sender, RoutedEventArgs e)
        {
            if (Search_box.Text.Equals(searchboxtxt))
            { Search_box.Text = string.Empty; }
        }




        private void Search_box_lost_focuse(object sender, RoutedEventArgs e)
        {
            if (Search_box.Text.Equals(string.Empty))
            { Search_box.Text = searchboxtxt; }
        }

        private void Sing_out_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
   


            private void Search_BT_Click(object sender, RoutedEventArgs e)
        {


            SearchWindow search_obj = new SearchWindow();

            search_obj.Show();
            var mainwin = Application.Current.MainWindow;
            mainwin.Hide();
  
            search_obj.GetSearchInfo(Search_box.Text);           


            Search_box.Text = searchboxtxt;

        }

        private void add_vehicle_Click(object sender, RoutedEventArgs e)
        {

            Profil_bt.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Assignments_bt.BorderBrush = new SolidColorBrush(Colors.Transparent);


            add_vehicle.BorderBrush = new SolidColorBrush(Colors.Green);
            Add_case.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Add_mechanic.BorderBrush = new SolidColorBrush(Colors.Transparent);
            All_Mechanic.BorderBrush = new SolidColorBrush(Colors.Transparent);
            All_vehicle.BorderBrush = new SolidColorBrush(Colors.Transparent);




            Menubar_frame.Navigate(new Add_vehicle());
        }

        private void Add_case_Click(object sender, RoutedEventArgs e)
        {
            Profil_bt.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Assignments_bt.BorderBrush = new SolidColorBrush(Colors.Transparent);

            add_vehicle.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Add_case.BorderBrush = new SolidColorBrush(Colors.Green);
            Add_mechanic.BorderBrush = new SolidColorBrush(Colors.Transparent);
            All_Mechanic.BorderBrush = new SolidColorBrush(Colors.Transparent);
            All_vehicle.BorderBrush = new SolidColorBrush(Colors.Transparent);

            Menubar_frame.Navigate(new Case());
        }


        private void BT_All_Mechanic(object sender, RoutedEventArgs e)
        {
            Profil_bt.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Assignments_bt.BorderBrush = new SolidColorBrush(Colors.Transparent);

            add_vehicle.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Add_case.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Add_mechanic.BorderBrush = new SolidColorBrush(Colors.Transparent);
            All_Mechanic.BorderBrush = new SolidColorBrush(Colors.Green);
            All_vehicle.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Menubar_frame.Navigate(new AllMechanic());

          
        }

        private void Add_mechanic_Click(object sender, RoutedEventArgs e)
        {
            Profil_bt.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Assignments_bt.BorderBrush = new SolidColorBrush(Colors.Transparent);

            add_vehicle.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Add_case.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Add_mechanic.BorderBrush = new SolidColorBrush(Colors.Green);
            All_Mechanic.BorderBrush = new SolidColorBrush(Colors.Transparent);
            All_vehicle.BorderBrush = new SolidColorBrush(Colors.Transparent);

            Menubar_frame.Navigate(new Add_Mechanic());
        }

        private void All_vehicle_Click(object sender, RoutedEventArgs e)
        {
            Profil_bt.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Assignments_bt.BorderBrush = new SolidColorBrush(Colors.Transparent);

            add_vehicle.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Add_case.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Add_mechanic.BorderBrush = new SolidColorBrush(Colors.Transparent);
            All_Mechanic.BorderBrush = new SolidColorBrush(Colors.Transparent);
            All_vehicle.BorderBrush = new SolidColorBrush(Colors.Green);
            Menubar_frame.Navigate(new Alla_vehicle());
        }

        private void Assignments_bt_Click(object sender, RoutedEventArgs e)
        {
            Profil_bt.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Assignments_bt.BorderBrush = new SolidColorBrush(Colors.Green);
  
            add_vehicle.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Add_case.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Add_mechanic.BorderBrush = new SolidColorBrush(Colors.Transparent);
            All_Mechanic.BorderBrush = new SolidColorBrush(Colors.Transparent);
            All_vehicle.BorderBrush = new SolidColorBrush(Colors.Transparent);

            Menubar_frame.Navigate(new Assignment()); ;
        }

        private void Profil_bt_Click(object sender, RoutedEventArgs e)
        {

            Profil_bt.BorderBrush = new SolidColorBrush(Colors.Green);
            Assignments_bt.BorderBrush = new SolidColorBrush(Colors.Transparent);

            add_vehicle.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Add_case.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Add_mechanic.BorderBrush = new SolidColorBrush(Colors.Transparent);
            All_Mechanic.BorderBrush = new SolidColorBrush(Colors.Transparent);
            All_vehicle.BorderBrush = new SolidColorBrush(Colors.Transparent);


            if (_GCU[0].Equals(Enum.GetName(typeof(IUserDataAccess.TypeOfUser), 1)))
            { Menubar_frame.Navigate(new AdminProfile()); }
            else { Menubar_frame.Navigate(new Profile()); }

        }


    }
}
