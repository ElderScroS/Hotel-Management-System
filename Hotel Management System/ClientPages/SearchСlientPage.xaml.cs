using Project.RoomPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Project.ClientPage
{
    public partial class SearchСlientPage : Page
    {
        public SearchСlientPage()
        {
            InitializeComponent();

            ClientListView.ItemsSource = Helper.db.clients;

            TypeClientComboBox.Items.Add("Single");
            TypeClientComboBox.Items.Add("Double");
            TypeClientComboBox.Items.Add("Family");
        }

        private void ClientListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < Helper.db.clients.Count; i++)
            {
                if (i == ClientListView.SelectedIndex)
                {
                    IdTextBox.Text = Helper.db.clients[i].Id.ToString();

                    FirstNameTextBox.Text = Helper.db.clients[i].FirstName;
                    LastNameTextBox.Text = Helper.db.clients[i].LastName;

                    EmailTextBox.Text = Helper.db.clients[i].Email;
                    PhoneTextBox.Text = Helper.db.clients[i].NumberPhone;

                    #region SingleDoubleFamily

                    if (Helper.db.clients[i].attribute_TypeGuest == TypeGuest.Single)
                        TypeClientComboBox.SelectedIndex = 0;
                    if (Helper.db.clients[i].attribute_TypeGuest == TypeGuest.Double)
                        TypeClientComboBox.SelectedIndex = 1;
                    if (Helper.db.clients[i].attribute_TypeGuest == TypeGuest.Family)
                        TypeClientComboBox.SelectedIndex = 2;

                    #endregion
                }
            }
        }

        private void DeleteClientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClientListView.SelectedIndex == -1)
            {
                MessageBox.Show("Select client");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Client", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Helper.db.clients.RemoveAt(ClientListView.SelectedIndex);

                        MessageBox.Show("Deleted");

                        Helper.SaveSerialize(Helper.path, Helper.db);

                        MainFrame.Navigate(new SearchСlientPage());

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
        private void EditClientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClientListView.SelectedIndex == -1)
                MessageBox.Show("Select Client");
            else if (IdTextBox.Text == "" || !IdTextBox.Text.All(Char.IsDigit))
                MessageBox.Show("ID have symbols/Is empty");
            else if (FirstNameTextBox.Text == "" || LastNameTextBox.Text == "")
                MessageBox.Show("Digits in first / last name or Is empty");
            else if (TypeClientComboBox.SelectedIndex == -1)
                MessageBox.Show("Type Client Is empty");
            else if (PhoneTextBox.Text == "" || !PhoneTextBox.Text.All(Char.IsDigit))
                MessageBox.Show("Phone have symbols / Is empty");
            else if (EmailTextBox.Text == "" || EmailTextBox.Text.IndexOf("@") == -1 || EmailTextBox.Text.IndexOf("gmail.com") == -1)
            {
                MessageBox.Show("Email is empty / Use '@' and 'gmail.com'");
            }
            else
            {
                Client client = new Client()
                {
                    Id = Convert.ToInt32(IdTextBox.Text),

                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,

                    Email = EmailTextBox.Text,
                    NumberPhone = PhoneTextBox.Text
                };

                #region SingleDoubleFamily

                if (TypeClientComboBox.Text == "Single")
                    client.attribute_TypeGuest = TypeGuest.Single;
                else if (TypeClientComboBox.Text == "Double")
                    client.attribute_TypeGuest = TypeGuest.Double;
                else if (TypeClientComboBox.Text == "Family")
                    client.attribute_TypeGuest = TypeGuest.Family;

                #endregion

                bool f = false;
                for (int i = 0; i < Helper.db.clients.Count; i++)
                {
                    if (Helper.db.clients[i] == client)
                    {
                        f = true;
                        break;
                    }
                }

                if (f == true)
                {
                    MessageBox.Show("This client is already on the list");
                }
                else
                {
                    Helper.db.clients[ClientListView.SelectedIndex].Id = Convert.ToInt32(IdTextBox.Text);
                    Helper.db.clients[ClientListView.SelectedIndex].FirstName = FirstNameTextBox.Text;
                    Helper.db.clients[ClientListView.SelectedIndex].LastName = LastNameTextBox.Text;
                    Helper.db.clients[ClientListView.SelectedIndex].Email = EmailTextBox.Text;
                    Helper.db.clients[ClientListView.SelectedIndex].NumberPhone = PhoneTextBox.Text;

                    #region SingleDoubleFamily

                    if (TypeClientComboBox.Text == "Single")
                        Helper.db.clients[ClientListView.SelectedIndex].attribute_TypeGuest = TypeGuest.Single;
                    else if (TypeClientComboBox.Text == "Double")
                        Helper.db.clients[ClientListView.SelectedIndex].attribute_TypeGuest = TypeGuest.Double;
                    else if (TypeClientComboBox.Text == "Family")
                        Helper.db.clients[ClientListView.SelectedIndex].attribute_TypeGuest = TypeGuest.Family;

                    #endregion

                    MessageBox.Show("Succesfully edited");

                    Helper.SaveSerialize(Helper.path, Helper.db);
                }

                MainFrame.Navigate(new SearchСlientPage());
            }
        }
    }
}
