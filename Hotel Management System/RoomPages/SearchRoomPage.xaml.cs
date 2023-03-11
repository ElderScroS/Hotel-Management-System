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
    public partial class SearchRoomPage : Page
    {
        public SearchRoomPage()
        {
            InitializeComponent();

            RoomListView.ItemsSource = Helper.db.rooms;

            TypeRoomComboBox.Items.Add("Single");
            TypeRoomComboBox.Items.Add("Double");
            TypeRoomComboBox.Items.Add("Family");
        }

        private void RoomListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < Helper.db.rooms.Count; i++)
            {
                if (i == RoomListView.SelectedIndex)
                {
                    IdTextBox.Text = Helper.db.rooms[i].Id.ToString();
                    PriceTextBox.Text = Helper.db.rooms[i].Price.ToString();

                    #region FreeOrBusy

                    if (Helper.db.rooms[i].Active == true)
                        FreeRB.IsChecked = true;
                    else
                        BusyRB.IsChecked = true;

                    #endregion

                    #region SingleDoubleFamily

                    if (Helper.db.rooms[i].attribute_TypeRoom == TypeRoom.Single)
                        TypeRoomComboBox.SelectedIndex = 0; 
                    if (Helper.db.rooms[i].attribute_TypeRoom == TypeRoom.Double)
                        TypeRoomComboBox.SelectedIndex = 1;   
                    if (Helper.db.rooms[i].attribute_TypeRoom == TypeRoom.Family)
                        TypeRoomComboBox.SelectedIndex = 2;

                    #endregion
                }
            }
        }

        private void DeleteRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RoomListView.SelectedIndex == -1)
            {
                MessageBox.Show("Select room");
            }
            else 
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Room", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Helper.db.rooms.RemoveAt(RoomListView.SelectedIndex);

                        MessageBox.Show("Deleted");

                        Helper.SaveSerialize(Helper.path, Helper.db);

                        MainFrame.Navigate(new SearchRoomPage());

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
        private void EditRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RoomListView.SelectedIndex == -1)
                MessageBox.Show("Select Room");
            else if (IdTextBox.Text == "" || !IdTextBox.Text.All(Char.IsDigit))
                MessageBox.Show("ID have symbols / Is empty");
            else if (TypeRoomComboBox.SelectedIndex == -1)
                MessageBox.Show("Type Room Is empty");
            else if (FreeRB.IsChecked == false && BusyRB.IsChecked == false)
                MessageBox.Show("You didn't choose Free or Busy is room");
            else if (PriceTextBox.Text == "" || !PriceTextBox.Text.All(Char.IsDigit))
            {
                MessageBox.Show("Price have symbols / Is empty");
            }
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
                    Helper.db.rooms[RoomListView.SelectedIndex].Id = Convert.ToInt32(IdTextBox.Text);
                    Helper.db.rooms[RoomListView.SelectedIndex].Price = Convert.ToInt32(PriceTextBox.Text);

                    #region FreeOrBusy

                    if (FreeRB.IsChecked == true)
                        Helper.db.rooms[RoomListView.SelectedIndex].Active = true;
                    else
                        Helper.db.rooms[RoomListView.SelectedIndex].Active = false;

                    #endregion

                    #region SingleDoubleFamily

                    if (TypeRoomComboBox.Text == "Single")
                        Helper.db.rooms[RoomListView.SelectedIndex].attribute_TypeRoom = TypeRoom.Single;
                    else if (TypeRoomComboBox.Text == "Double")
                        Helper.db.rooms[RoomListView.SelectedIndex].attribute_TypeRoom = TypeRoom.Double;
                    else if (TypeRoomComboBox.Text == "Family")
                        Helper.db.rooms[RoomListView.SelectedIndex].attribute_TypeRoom = TypeRoom.Family;

                    #endregion

                    MessageBox.Show("Succesfully edited");

                    RoomListView.ItemsSource = Helper.db.rooms;

                    Helper.SaveSerialize(Helper.path, Helper.db);
                }

                MainFrame.Navigate(new SearchRoomPage());
            }
        }
    }
}