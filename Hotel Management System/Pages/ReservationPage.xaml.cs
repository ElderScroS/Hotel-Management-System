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
    public partial class Reservation : Page
    {
        public Reservation()
        {
            InitializeComponent();
            ReservationFrame.Navigate(new ReservePages.ReservePage());
        }

        private void ReserveBtn_Click(object sender, RoutedEventArgs e)
        {
            ReservationFrame.Navigate(new ReservePages.ReservePage());
        }

        private void SearchReservedBtn_Click(object sender, RoutedEventArgs e)
        {
            ReservationFrame.Navigate(new ReservePages.SearchReservedPage());
        }
    }
}
