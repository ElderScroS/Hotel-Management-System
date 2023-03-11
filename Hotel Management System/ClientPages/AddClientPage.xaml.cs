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

namespace Project.ClientPage
{
    public partial class AddClientPage : Page
    {
        public AddClientPage()
        {
            InitializeComponent();

            TypeClientComboBox.Items.Add("Single");
            TypeClientComboBox.Items.Add("Double");
            TypeClientComboBox.Items.Add("Family");
        }

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IdTextBox.Text == "" || !IdTextBox.Text.All(Char.IsDigit))
                MessageBox.Show("ID have symbols/Is empty");
            else if (FirstNameTextBox.Text == "" || LastNameTextBox.Text == "")
                MessageBox.Show("Digits in first / last name or Is empty");
            else if (TypeClientComboBox.SelectedIndex == -1)
                MessageBox.Show("Type Client Is empty");
            else if (PhoneTextBox.Text == "" || !PhoneTextBox.Text.All(Char.IsDigit))
                MessageBox.Show("Phone have symbols / Is empty");
            else if (EmailTextBox.Text == "" || EmailTextBox.Text.IndexOf("@") == -1 || EmailTextBox.Text.IndexOf("gmail.com") == -1)
                MessageBox.Show("Email is empty / Use '@' and 'gmail.com'");
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
                    Helper.db.clients.Add(client);

                    MessageBox.Show("Succesfully added");

                    Helper.SaveSerialize(Helper.path, Helper.db);
                }
            }
        }
    }
}
