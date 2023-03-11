using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    enum TypeRoom
    {
        None,
        Single,
        Double, 
        Family
    }

    [Serializable]
    internal class Room
    {
        public int Id { get; set; }
        public TypeRoom attribute_TypeRoom { get; set; }
        public bool Active { get; set; }
        public int Price { get; set; }
    }
}
