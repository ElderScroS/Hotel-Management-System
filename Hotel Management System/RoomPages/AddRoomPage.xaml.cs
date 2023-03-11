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

namespace Project.RoomPage
{
    [Serializable]
    public partial class AddRoomPage : Page
    {
        public AddRoomPage()
        {
            InitializeComponent();

            TypeRoomComboBox.Items.Add("Single");
            TypeRoomComboBox.Items.Add("Double");
            TypeRoomComboBox.Items.Add("Family");
        }

        private void AddRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IdTextBox.Text == "" || !IdTextBox.Text.All(Char.IsDigit))
                MessageBox.Show("ID have symbols / Is empty");
            else if (TypeRoomComboBox.SelectedIndex == -1)
                MessageBox.Show("Type Room Is empty");
            else if (FreeRB.IsChecked == false && BusyRB.IsChecked == false)
                MessageBox.Show("You didn't choose Free or Busy is room");
            else if (PriceTextBox.Text == "" || !PriceTextBox.Text.All(Char.IsDigit))
                MessageBox.Show("Price have symbols / Is empty");
            else
            {
                Room room = new Room()
                {
                    Id = Convert.ToInt32(IdTextBox.Text),
                    Price = Convert.ToInt32(PriceTextBox.Text)
                };

                #region FreeOrBusy

                if (FreeRB.IsChecked == true)
                    room.Active = true;
                else
                    room.Active = false;

                #endregion 

                #region SingleDoubleFamily

                if (TypeRoomComboBox.Text == "Single")
                    room.attribute_TypeRoom = TypeRoom.Single;
                else if (TypeRoomComboBox.Text == "Double")
                    room.attribute_TypeRoom = TypeRoom.Double;
                else if (TypeRoomComboBox.Text == "Family")
                    room.attribute_TypeRoom = TypeRoom.Family;

                #endregion

                bool f = false;
                for (int i = 0; i < Helper.db.rooms.Count; i++)
                {
                    if (Helper.db.rooms[i] == room)
                    {
                        f = true;
                        break;
                    }
                }
                if (f == true)
                {
                    MessageBox.Show("This room is already on the list");
                }
                else
                {
                    Helper.db.rooms.Add(room);

                    MessageBox.Show("Succesfully added");

                    Helper.SaveSerialize(Helper.path, Helper.db);
                }
            }
        }
    }
}
