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

            int option;

            do
            {
                Console.WriteLine("[ 1 ] Print Stock");
                Console.WriteLine("[ 2 ] Check Orders");
                Console.WriteLine("[ 3 ] Sell book");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("voer een getal in!");
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine(BookStore.ListProduct(hengelo.Stocks));
                        break;
                    case 2:
                        Console.WriteLine(BookStore.ListOrders(BookStore.CheckOrders()));
                        break;
                    case 3:
                        int option3;
                        Console.WriteLine("[ 1 ] Sell book by title");
                        Console.WriteLine("[ 2 ] Sell book by ISBN");
                        while (!int.TryParse(Console.ReadLine(), out option3))
                        {
                            Console.WriteLine("voer een getal in!");
                        }
                        switch (option3)
                            {
                            case 1:
                                Console.WriteLine("Voer de titel in");
                                string titel = Console.ReadLine();

                                Console.WriteLine("Voer de auteur in");
                                string author = Console.ReadLine();

                                Console.WriteLine("Voer het aantal verkochte boeken in");
                                int soldBooks;
                                while (!int.TryParse(Console.ReadLine(), out soldBooks))
                                {
                                    Console.WriteLine("voer een getal in!");
                                }
                                hengelo.Stocks = BookStore.SellBookByTitle(titel, author, soldBooks);
                                BookStore.ListProduct(hengelo.Stocks);
                                break;

                            case 2:
                                Console.WriteLine("Voer de ISBN in");
                                string isbn = Console.ReadLine();

                                Console.WriteLine("Voer het aantal verkochte boeken in");
                                int soldBooks2;
                                while (!int.TryParse(Console.ReadLine(), out soldBooks2))
                                {
                                    Console.WriteLine("voer een getal in!");
                                }
                                hengelo.Stocks = BookStore.SellBookByISBN(isbn, soldBooks2);
                                BookStore.ListProduct(hengelo.Stocks);
                                break;

                            default:
                                break;
                            }


                        
                        break;
                    default:
                        Console.WriteLine("The program will now close");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;


                }

            }
            while (option != 0);





            


           


            //try
            //{
            //    hengelo.Stocks = BookStore.SellBookByISBN("9789048840243", 1);
            //    BookStore.ListProduct(hengelo.Stocks);
            //}
            //catch(ArgumentException ex)
            //{
            //    Console.WriteLine(ex.Message);

            //    Console.ReadKey();
            //    Environment.Exit(1);
            //}


            


           
            Console.ReadKey();
        }

        

        
    }
}
