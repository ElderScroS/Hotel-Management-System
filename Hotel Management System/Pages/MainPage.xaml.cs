using System;
using System.Windows;
using System.Windows.Controls;

namespace Project.Pages
{
    [Serializable]
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            UsernameLbl.Content = Helper.db.admin.Username;

            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, t) => { TimeLbl.Content = DateTime.Now.ToString() + "pm"; };
            timer.Start();

            NavigationFrame.Navigate(new DashboardPage());
        }

        private void SideBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = SideBar.SelectedItem as NavigationButton;

            NavigationFrame.Navigate(selected.Navigationlink);
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want log out?", "Log out", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.MainFrame.Content = new SignUpPage();

                    break;
                case MessageBoxResult.No:
                    break;
            }

        }
    }
}