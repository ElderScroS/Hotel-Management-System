using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Project.Pages
{
    [Serializable]
    public partial class SignUpPage : Page
    {
        Admin admin = new Admin();
        
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameBox.Text.All(Char.IsLetter) && PasswordBox.Password.Length >= 5)
            {
                admin.Username = UsernameBox.Text;
                admin.Password = PasswordBox.Password;
                Project.Helper.db.admin = admin;

                Helper.SaveSerialize(Helper.path, Helper.db);

                this.MainFrame.Content = new MainPage();
            }
            else
            {
                MessageBox.Show("Wrong Input!!!");
            }
        }
    }
}
