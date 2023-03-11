using System;
using System.Windows.Controls;

namespace Project.Pages
{
    [Serializable]
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();

            RoomsLbl.Content = Helper.db.rooms.Count.ToString();
            ReservedLbl.Content = Helper.db.reserved.Count.ToString();
            UsersLbl.Content = Helper.db.clients.Count.ToString();
            CashLbl.Content = Helper.db.cash.ToString();
        }

    }
}
