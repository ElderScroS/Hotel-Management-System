using Project.Models;
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

namespace Project.ReservePages
{
    [Serializable]
    public partial class ReservePage : Page
    {
        public ReservePage()
        {
            InitializeComponent();

            for (int i = 0; i < Helper.db.rooms.Count; i++)
            {
                RoomIdComboBox.Items.Add(Helper.db.rooms[i].Id);
            }
            for (int i = 0; i < Helper.db.clients.Count; i++)
            {
                ClientIdComboBox.Items.Add(Helper.db.clients[i].Id);
            }
        }

        private void ReserveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RoomIdComboBox.SelectedIndex == -1 || ClientIdComboBox.SelectedIndex == -1)
                MessageBox.Show("Please select client / room");
            else if (CheckInDateTime.Text == "" || CheckOutDateTime.Text == "")
                MessageBox.Show("Empty Check in / Check out");
            else if (CheckInDateTime.SelectedDate.GetValueOrDefault() > CheckOutDateTime.SelectedDate.GetValueOrDefault())
                MessageBox.Show("Can't choose less than a day.");
            else
            {
                int days = System.Math.Abs(CheckOutDateTime.SelectedDate.GetValueOrDefault().Day - CheckInDateTime.SelectedDate.GetValueOrDefault().Day);
                int total_price = 1;

                Reserved reserved = new Reserved()
                {
                    CheckIn = CheckInDateTime.SelectedDate.GetValueOrDefault(),
                    CheckOut = CheckOutDateTime.SelectedDate.GetValueOrDefault(),
                };

                for (int i = 0; i < Helper.db.clients.Count; i++)
                {
                    if (Helper.db.clients[i].Id == Convert.ToInt32(ClientIdComboBox.Text))
                    {
                        reserved.IdClient = Helper.db.clients[i].Id;
                        break;
                    }
                }
                for (int i = 0; i < Helper.db.rooms.Count; i++)
                {
                    if (Helper.db.rooms[i].Id == Convert.ToInt32(RoomIdComboBox.Text))
                    {
                        reserved.IdRoom = Helper.db.rooms[i].Id;
                        total_price = days * Helper.db.rooms[i].Price;
                        reserved.TotalPrice = total_price;
                        break;
                    }
                }

                Helper.db.cash += total_price;
                Helper.db.reserved.Add(reserved);

                MessageBox.Show($"Succesfully Reserved");

                Helper.SaveSerialize(Helper.path, Helper.db);
            }
        }
    }
}
