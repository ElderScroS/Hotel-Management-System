using Project.RoomPage;
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
    [Serializable]
    public partial class RoomPage : Page
    {
        public RoomPage()
        {
            InitializeComponent();

            RoomFrame.Navigate(new AddRoomPage());
        }

        private void AddRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            RoomFrame.Navigate(new AddRoomPage());
        }
        private void SearchRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            RoomFrame.Navigate(new SearchRoomPage());
        }
    }
}
