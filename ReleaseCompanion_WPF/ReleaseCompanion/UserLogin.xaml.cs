using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Security.Principal;

namespace ReleaseCompanion
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
            var user = WindowsIdentity.GetCurrent();
            domainTxt.Text = user.Name.Split('\\').First();
            userNameTxt.Text = user.Name.Split('\\').Last();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            domainLbl.Foreground = Brushes.Black;
            userLbl.Foreground = Brushes.Black;
            passwordLbl.Foreground = Brushes.Black;
            passwordTxt.BorderBrush = SystemColors.ControlDarkBrush;
            userNameTxt.BorderBrush = SystemColors.ControlDarkBrush;
            domainTxt.BorderBrush = SystemColors.ControlDarkBrush;
            domainLbl.Refresh();
            userLbl.Refresh();
            passwordLbl.Refresh();
            passwordTxt.Refresh();
            userNameTxt.Refresh();
            domainTxt.Refresh();

            bool isAllFieldsEntered = true;
            if (string.IsNullOrEmpty(passwordTxt.Password))
            {
                isAllFieldsEntered = false;
                passwordLbl.Foreground = Brushes.Red;
                passwordTxt.BorderBrush = Brushes.Red;
                passwordTxt.Focus();
            }
            if (string.IsNullOrEmpty(userNameTxt.Text))
            {
                isAllFieldsEntered = false;
                userLbl.Foreground = Brushes.Red;
                userNameTxt.BorderBrush = Brushes.Red;
                userNameTxt.Focus();
            }
            if (string.IsNullOrEmpty(domainTxt.Text))
            {
                isAllFieldsEntered = false;
                domainLbl.Foreground = Brushes.Red;
                domainTxt.BorderBrush = Brushes.Red;
                domainTxt.Focus();
            }
            if(isAllFieldsEntered)
            try
            {
                Impersonator impersonator = new Impersonator(userNameTxt.Text, domainTxt.Text, passwordTxt.Password);
                Application.Current.MainWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Error");
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
            Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Show();
        }
    }
}
