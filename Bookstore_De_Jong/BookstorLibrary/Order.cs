using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstorLibrary
{
    public class Order
    {
        private DateTime orderDate;
        private bool orderHandled;

        public Order()
        {
        }

        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public bool OrderHandled { get => orderHandled; set => orderHandled = value; }
        public List<string> OrderList { get; set; } = new List<string>();
    }
}
