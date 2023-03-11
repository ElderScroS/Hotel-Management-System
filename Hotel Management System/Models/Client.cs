using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Project
{
    enum TypeGuest
    {
        None,
        Single,
        Double,
        Family
    }

    [Serializable]
    internal class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TypeGuest attribute_TypeGuest { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
    }
}
