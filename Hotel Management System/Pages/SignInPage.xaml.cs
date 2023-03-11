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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Pages
{
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Helper.db.admin.Password == PasswordBox.Password)
                MainFrame.Navigate(new MainPage());
            else
                MessageBox.Show("Wrong Password!!!");
        }

        private void ForgetPassword_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SignUpPage());
        }
    }
}
