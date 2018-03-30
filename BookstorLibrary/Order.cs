using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstorLibrary
{
    public class Order
    {
        #region attributes
        private DateTime orderDate;
        private bool orderHandled;
        #endregion

        #region constructor
        public Order()
        {
        }
        #endregion

        #region properties
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public bool OrderHandled { get => orderHandled; set => orderHandled = value; }
        public List<string> OrderList { get; set; } = new List<string>();
        #endregion

        



    }
}
