using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Project.Models;

namespace Project
{
    [Serializable]
    internal class DataBase
    {
        public int cash = 0;
        public List<Client> clients = new List<Client>();
        public List<Reserved> reserved = new List<Reserved>();

        public List<Room> rooms = new List<Room>();

        public Admin admin = new Admin();
    }
}
