using Library301.Service;
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
using System.Windows.Shapes;

namespace Library301
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            CetUserService cetUserService = new CetUserService();
            //txtPassword.Text=cetUserService.hashPassword("admin");


            if (txtSchoolNumber.Text == "" && txtPassword.Password == "")
            {
                MessageBox.Show("School number and Password cannot be empty.");
            }
            else if(txtSchoolNumber.Text == "")
            {
                MessageBox.Show("School number cannot be empty.");
            }

            else if (txtPassword.Password == "")
            {
                MessageBox.Show("Password cannot be empty.");
            }
            else

            {
                var loginUser = cetUserService.Login(txtSchoolNumber.Text, txtPassword.Password);
                if (loginUser == null)
                {
                    MessageBox.Show("Incorrect School Number/Password ");
                }
                else
                {
                    /// Doğru giriş yapıldı.
                    MainWindow mainWindow = new MainWindow(loginUser);
                    mainWindow.Show();
                    this.Close();
                }
            }
        }











    }
}
