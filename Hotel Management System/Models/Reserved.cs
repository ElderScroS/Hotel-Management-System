using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    [Serializable]
    internal class Reserved
    {
        public int IdRoom { get; set; }
        public int IdClient { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public int TotalPrice { get; set; }
    }
}
