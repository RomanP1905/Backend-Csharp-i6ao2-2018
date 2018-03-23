using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstorLibrary
{
    public class OrderItems
    {
        private string printLastCode;

        public OrderItems()
        {
        }

        public string PrintLastCode { get => printLastCode; set => printLastCode = value; }
        public List<Order> OrderList { get; set; } = new List<Order>();
    }
}
