using Project.ClientPage;
using System;
using System.Windows.Controls;

namespace Project.Pages
{
    [Serializable]
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            ClientFrame.Navigate(new AddClientPage());
        }

        private void AddClientBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ClientFrame.Navigate(new AddClientPage());
        }
        private void SearchClientBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ClientFrame.Navigate(new SearchСlientPage());

        }
    }
}
