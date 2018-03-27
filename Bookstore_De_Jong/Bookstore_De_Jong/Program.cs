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
            Console.WriteLine("\n--------------------------------------nieuwe voorraad------------------------------------");

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

            Console.WriteLine("\n--------------------------------------bestel lijst------------------------------------");
            ListOrders(orderList);
           
            Console.ReadKey();
        }

        private static void ListOrders(List<BookStore.OrderList> orderItemsList)
        {
            foreach (var order in orderItemsList)
            {
                if (order.OrderProduct.Length == 13)
                {
                    Console.WriteLine("Titel: " + order.OrderTitle + ", ISBN: " + order.OrderProduct + ", Aantal " + order.OrderAmount);
                }
                else
                {
                    Console.WriteLine("Titel: " + order.OrderTitle + ", ISSN: " + order.OrderProduct + ", Aantal " + order.OrderAmount);
                }                    
            }
        }

        private static void ListProduct(List<Product> productList)
        {
            List<Product> Stocks = Product.GetTestData();
            for (int i = Stocks.Count - 1; i >= 0; i--)
            {
                Type typeCompare = Stocks[i].GetType();
                if (typeCompare == typeof(Book))
                {
                    Console.WriteLine("Titel Boek: " + Stocks[i].Title +
                    "\nISBN: " + ((Book)Stocks[i]).ISBN +
                    "\nAuteur: " + Stocks[i].Author +
                    "\nTaal: " + Stocks[i].Language +
                    "\nPrijs: " + Stocks[i].Price +
                    "\nGewicht: " + ((Book)Stocks[i]).Weight + " gram" +
                    "\nStaand: " + ((Book)Stocks[i]).Measurement.Width + 
                    " x " + ((Book)Stocks[i]).Measurement.Height + 
                    " x "+ ((Book)Stocks[i]).Measurement.Lenght + " mm" +
                    "\nAantal op voorraad: " + Stocks[i].GetStock() +
                    "\nMaximaal aantal Boeken: " + ((Book)Stocks[i]).MaxStock +
                    "\nMinimaal aantal Boeken: " + ((Book)Stocks[i]).MinStock +
                    Environment.NewLine);
                }
                else
                {
                    Console.WriteLine("Titel Tijdschrift: " + Stocks[i].Title +
                    "\nISSN: " + ((Magazine)Stocks[i]).ISSn +
                    "\nAuteur: " + Stocks[i].Author +
                    "\nTaal: " + Stocks[i].Language +
                    "\nPrijs: " + Stocks[i].Price +
                    "\nGewicht: " + ((Magazine)Stocks[i]).Weight + " gram" +
                    "\nTotaal aantal voorrad: " + ((Magazine)Stocks[i]).TotalOrderMagazine +
                    "\nStaand: " + ((Magazine)Stocks[i]).Measurement.Width + 
                    " x " + ((Magazine)Stocks[i]).Measurement.Height + 
                    " x " + ((Magazine)Stocks[i]).Measurement.Lenght + " mm" +
                    "\nBestel dag: " + ((Magazine)Stocks[i]).DayOfOrder +
                    "\nUitgifte dag: " + ((Magazine)Stocks[i]).DayOfRelease +
                    Environment.NewLine);
                }
            }          
        }
    }
}
