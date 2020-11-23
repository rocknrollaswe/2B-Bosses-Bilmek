using GUI.Home;
using Logic;
using Logic.DAL;
using Logic.Entities;
using Logic.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.Login
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private dynamic _loginService;


        public LoginPage()
        {
 
            InitializeComponent();
            this.tbUsernam.Focus();



        }




        private void Shoutdown_BT_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {

            string username = this.tbUsernam.Text;
            string password = this.pbPassword.Password;



            bool successful = IUserDataAccess.LoginCheck(username, password).Item1;


            if (successful)
            {
                _loginService = IUserDataAccess.LoginCheck(username, password).Item2;
                HomePage._GCU[0] = _loginService.GetCurrentUser(username).Item1;  // username
                HomePage._GCU[1] = _loginService.GetCurrentUser(username).Item2; // userid
                HomePage._GCU[2] = _loginService.GetCurrentUser(username).Item3; // userObj
                HomePage._GCU[3] = _loginService.GetCurrentUser(username).Item4; // mekanic Obj

               

                NavigationService.Navigate(new HomePage());

            }
            else
            {
                Eror_msg.Content = "Inloggning misslyckades";
                this.tbUsernam.Clear();
                this.pbPassword.Clear();

            }
        }
    }
}
