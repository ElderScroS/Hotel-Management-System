using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]
    internal class Helper
    {
        #region Serialize
        public static void SaveSerialize(string path, DataBase db)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, db);
            }
        }
        public static DataBase LoadDeserialize(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (DataBase)formatter.Deserialize(fs);
            }
        }
        #endregion
        
        public static string path = "DB.dat";
        public static DataBase db = new DataBase();
    }
}
