using Library301;
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
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
       
        CetUserService cetUserService = new CetUserService();
        private readonly User User;

        public ChangePasswordWindow(User User)
        {
            InitializeComponent();
            this.User = User;
        }


        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if(!cetUserService.CheckPassword(User, txtCurrentPassword.Text))
            {
                MessageBox.Show("You entered an incorrect answer.");
                return;
            }
            if (txtNewPassword1.Text.Length < 5)
            {
                MessageBox.Show("The password must contain at least 5 character.");
                return;
            }

            if (txtNewPassword1.Text !=txtNewPassword2.Text)
            {
                MessageBox.Show("Passwords must be the same.");
                return;
            }

            cetUserService.ChangePassword(User, txtNewPassword1.Text);
            MessageBox.Show("Your password has been changed.");
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtNewPassword1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
