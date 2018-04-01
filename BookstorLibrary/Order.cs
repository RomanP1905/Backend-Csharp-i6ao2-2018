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
        public Order()
        {
        }
        #endregion

        #region properties
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public bool OrderHandled { get => orderHandled; set => orderHandled = value; }
        public List<string> OrderList { get; set; } = new List<string>();
        #endregion





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
        



        public static void RemoveFromOrder(int index, List<string> stringOrderList)
            {
            
                stringOrderList.RemoveAt(index);

                Console.WriteLine("Order removed at id: " + index + " Press any key to continue...");
                Console.ReadKey();

            }

        public static void EditOrderDate(int index)
            {



            }

    }
}
