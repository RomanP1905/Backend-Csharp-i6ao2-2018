using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore_De_Jong;
using BookstoreLibrary;
using BookstorLibrary;

namespace Bookstore_De_Jong
{

    
    class Program
    {
        private static List<Product> productList = Product.GetTestData();
        static void Main(string[] args)
        {



            
            BookStore hengelo = new BookStore();




            hengelo.Stocks = Product.GetTestData();
            hengelo.BusinessHours = "Ma-Vr 8:00 - 15:00";
            hengelo.ContactInfo = "Vind me op mijn website: www.bookstore-hengelo.nl";

            Console.WriteLine("--------------------------------------oude voorraad------------------------------------");
            ListProduct(hengelo.Stocks);
            Console.WriteLine("\n");
            Console.WriteLine("--------------------------------------nieuwe voorraad------------------------------------");
            Console.WriteLine("\n");
            try
            {
                hengelo.Stocks = BookStore.SellBookByISBN("9789048840243", 1);
                ListProduct(hengelo.Stocks);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

                Console.ReadKey();
                Environment.Exit(1);
            }

            List<BookStore.OrderList> orderList = BookStore.CheckOrders();

            Console.WriteLine("--------------------------------------bestel lijst------------------------------------");
            ListOrders(orderList);

            
            Console.ReadKey();


        }

        private static void ListOrders(List<BookStore.OrderList> orderItemsList)
        {
            foreach (var order in orderItemsList)
            {
                Console.WriteLine(order.OrderAmount + " " + order.OrderProduct);

            }
        }

        private static void ListProduct(List<Product> productList)
        {
            foreach (var product in productList)
            {
                Console.WriteLine(product.PrintAttributes() + " " + product.Title + " " + product.Author + " " + product.Language + " " + product.Price + " " + product.GetStock());

            }
            
        }

    }
}
