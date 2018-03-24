using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstorLibrary
{
    public class OrderItems
    {
        #region attributes
        private string printLastCode;
        #endregion

        #region constructor
        public OrderItems()
        {
        }
        #endregion

        #region properties
        public string PrintLastCode { get => printLastCode; set => printLastCode = value; }
        public List<Order> OrderList { get; set; } = new List<Order>();
        #endregion
    }
}
