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
                MessageBox.Show("Mevcut Şifreniz Hatalı!");
                return;
            }
            if (txtNewPassword1.Text.Length < 5)
            {
                MessageBox.Show("Şifre en az 5 karakter olmalı");
                return;
            }

            if (txtNewPassword1.Text !=txtNewPassword2.Text)
            {
                MessageBox.Show("Yeni Şifreler uyumlu değil");
                return;
            }

            cetUserService.ChangePassword(User, txtNewPassword1.Text);
            MessageBox.Show("Şifreniz değiştirilmiştir.");
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
