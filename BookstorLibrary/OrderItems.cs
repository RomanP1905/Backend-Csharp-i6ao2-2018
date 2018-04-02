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
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItems"/> class.
        /// </summary>
        public OrderItems()
        {
        }
        #endregion

        #region properties
        public string PrintLastCode { get => printLastCode; set => printLastCode = value; }
        public static List<Order> OrderList { get; set; } = new List<Order>();
        #endregion

        /// <summary>
        /// Removes the index of the order by.
        /// </summary>
        /// <param name="index">The index.</param>
        public static void RemoveOrderByIndex(int index)
        {


            OrderList.RemoveAt(index);

            Console.WriteLine("Item removed at index: " + index + " Press any key to continue...");
            Console.ReadKey();

        }

        /// <summary>
        /// Changes the index of the date by.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="date">The date.</param>
        public static void ChangeDateByIndex(int index, DateTime date)
        {
            OrderList[index].OrderDate = date;

            Console.WriteLine("Date changed to: " + date.ToString("dd/MM/yyyy") + " Press any key to continue...");
            Console.ReadKey();
        }

    }
}
