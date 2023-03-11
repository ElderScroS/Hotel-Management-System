using Project.Pages;
using Project.RoomPage;
using System;
using System.Windows;

namespace Project
{
    [Serializable]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Helper.db.rooms.Clear();
            //Helper.SaveSerialize(Helper.path, Helper.db);

            Helper.db = Helper.LoadDeserialize(Helper.path);

            if (Helper.db.admin.Username == null) 
                MainFrame.Content = new Pages.SignUpPage(); 
            else 
                MainFrame.Content = new Pages.MainPage(); 
        }
    }
}
