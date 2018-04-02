using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreLibrary;
using BookstorLibrary;

namespace BookstorLibrary
{
    public class Order
    {
        #region attributes
        private DateTime orderDate;
        private bool orderHandled;
        #endregion

        #region constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order()
        {
        }
        #endregion

        #region properties
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public bool OrderHandled { get => orderHandled; set => orderHandled = value; }
        public List<string> OrderList { get; set; } = new List<string>();
        #endregion




        /// <summary>
        /// Adds the generated order.
        /// </summary>
        /// <param name="Stocks">The stocks.</param>
        public static void AddGeneratedOrder(List<Product> Stocks)
        {

            List<string> orderString = BookStore.GenerateOrders(Stocks);

            if (orderString.Any() != false)
            {

                Order todaysOrder = new Order();
                todaysOrder.OrderDate = DateTime.Today;
                todaysOrder.OrderHandled = false;

                todaysOrder.OrderList = orderString;

                OrderItems.OrderList.Add(todaysOrder);

            }


            foreach (string listItem in orderString)
            {
                Console.WriteLine(listItem);

            }
        }

        /// <summary>
        /// Adds the book to order.
        /// </summary>
        /// <param name="Stocks">The stocks.</param>
        public static void AddBookToOrder(List<Product> Stocks)
        {
            List<string> orderStringManual;
            orderStringManual = Book.OrderBookByISBN(Stocks);

            foreach(string orderString in orderStringManual)
            {
                Console.WriteLine(orderString);
            }
            

            if (orderStringManual.Any() != false)
            {

                Order manOrderBook = new Order();
                manOrderBook.OrderDate = DateTime.Today;
                manOrderBook.OrderHandled = false;
                manOrderBook.OrderList = orderStringManual;
                OrderItems.OrderList.Add(manOrderBook);

            }
        }

        /// <summary>
        /// Adds the magazine to order.
        /// </summary>
        /// <param name="Stocks">The stocks.</param>
        public static void AddMagazineToOrder(List<Product> Stocks)
        {
            List<string> orderStringManual;
            orderStringManual = Magazine.OrderMagazineByISSN(Stocks);

            foreach (string orderString in orderStringManual)
            {
                Console.WriteLine(orderString);
            }

            if (orderStringManual.Any() != false)
            {
                Order manOrderMagazine = new Order();
                manOrderMagazine.OrderDate = DateTime.Today;
                manOrderMagazine.OrderHandled = false;
                manOrderMagazine.OrderList = orderStringManual;
                OrderItems.OrderList.Add(manOrderMagazine);
            }
        }

        /// <summary>
        /// Removes from order.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="stringOrderList">The string order list.</param>
        public static void RemoveFromOrder(int index, List<string> stringOrderList)
            {         
                stringOrderList.RemoveAt(index);

                Console.WriteLine("Order removed at id: " + index + " Press any key to continue...");
                Console.ReadKey();
            }

        /// <summary>
        /// Edits the order date.
        /// </summary>
        /// <param name="index">The index.</param>
        public static void EditOrderDate(int index)
        {

        }
    }
}
