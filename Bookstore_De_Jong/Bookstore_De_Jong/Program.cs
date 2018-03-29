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
                Console.WriteLine("[ 2 ] Generate Order");
                Console.WriteLine("[ 3 ] Sell book");
                Console.WriteLine("[ 4 ] Add New Book or Magazine");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("voer een getal in!");
                }

                switch (option)
                {
                    #region Print Stock
                    case 1:
                        Console.WriteLine(BookStore.ListProduct(hengelo.Stocks));
                        break; 
                    #endregion
                    #region Generate Order
                    case 2:
                        Console.WriteLine(BookStore.ListOrders(BookStore.GenerateOrders(hengelo.Stocks)));
                        Order todaysOrder = new Order();
                        todaysOrder.OrderDate = DateTime.Today;
                        todaysOrder.OrderHandled = false;
                        todaysOrder.OrderList.Add(BookStore.ListOrders(BookStore.GenerateOrders(hengelo.Stocks)));

                        OrderItems.OrderList.Add(todaysOrder);

                        break; 
                    #endregion
                    #region Sell Book
                    case 3:
                        
                        Console.WriteLine("[ 1 ] Sell book by title");
                        Console.WriteLine("[ 2 ] Sell book by ISBN");
                        while (!int.TryParse(Console.ReadLine(), out option))
                        {
                            Console.WriteLine("voer een getal in!");
                        }
                        switch (option)
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
                                hengelo.Stocks = BookStore.SellBookByTitle(titel, author, soldBooks, hengelo.Stocks);
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
                                hengelo.Stocks = BookStore.SellBookByISBN(isbn, soldBooks2, hengelo.Stocks);
                                BookStore.ListProduct(hengelo.Stocks);
                                break;

                            default:
                                break;
                        }



                        break; 
                    #endregion
                    #region Add new book or magazine
                    case 4:
                        Console.WriteLine("[ 1 ] Add New Book");
                        Console.WriteLine("[ 2 ] Add New Magazine");

                        while (!int.TryParse(Console.ReadLine(), out option))
                        {
                            Console.WriteLine("voer een getal in!");
                        }
                        switch (option)
                        {
                            case 1:
                                string printBook; string isbnBook; int minStockBook; int maxStockBook; int stockBook; string titleBook; string authorBook; int weightBook; decimal priceBook; Language languageBook; Measurement measurementBook;

                                Console.WriteLine("Enter Print: ");
                                printBook = Console.ReadLine();

                                Console.WriteLine("Enter ISBN: ");
                                isbnBook = Console.ReadLine();

                                Console.WriteLine("Enter minimum stock: ");
                                Int32.TryParse(Console.ReadLine(), out minStockBook);

                                Console.WriteLine("Enter maximum stock: ");
                                Int32.TryParse(Console.ReadLine(), out maxStockBook);

                                Console.WriteLine("Enter current stock: ");
                                Int32.TryParse(Console.ReadLine(), out stockBook);

                                Console.WriteLine("Enter Title: ");
                                titleBook = Console.ReadLine();

                                Console.WriteLine("Enter Author: ");
                                authorBook = Console.ReadLine();

                                Console.WriteLine("Pick a language (select number): \n" +
                                    "[ 1 ] Dutch \n" +
                                    "[ 2 ] English \n" +
                                    "[ 3 ] French \n" +
                                    "[ 4 ] German \n" +
                                    "[ 5 ] Spanish \n" +
                                    "[ 6 ] Unknown ");


                                int optionlang;

                                while (!int.TryParse(Console.ReadLine(), out optionlang))
                                {
                                    Console.WriteLine("Enter a number from the selection");
                                }

                                switch (optionlang)
                                {
                                    case 1:
                                        languageBook = Language.Dutch;
                                        break;
                                    case 2:
                                        languageBook = Language.English;
                                        break;
                                    case 3:
                                        languageBook = Language.French;
                                        break;
                                    case 4:
                                        languageBook = Language.German;
                                        break;
                                    case 5:
                                        languageBook = Language.Spanish;
                                        break;
                                    case 6:
                                        languageBook = Language.Unknown;
                                        break;
                                    default:
                                        languageBook = Language.Unknown;
                                        Console.WriteLine("No valid number entered, assigning language as \"Unknown\"");
                                        break;
                                };


                                Console.WriteLine("Enter unit weight (gram): ");
                                Int32.TryParse(Console.ReadLine(), out weightBook);

                                Console.WriteLine("Enter unit price (Euro): ");
                                Decimal.TryParse(Console.ReadLine(), out priceBook);

                                int width4;
                                int length4;
                                int height4;

                                Console.WriteLine("Enter Width (mm): ");
                                Int32.TryParse(Console.ReadLine(), out width4);
                                Console.WriteLine("Enter Length (mm): ");
                                Int32.TryParse(Console.ReadLine(), out length4);
                                Console.WriteLine("Enter Height (mm): ");
                                Int32.TryParse(Console.ReadLine(), out height4);

                                measurementBook = new Measurement(width4, height4, length4);


                                BookStore.AddNewBook(printBook, isbnBook, minStockBook, maxStockBook, stockBook, titleBook, authorBook, weightBook, priceBook, languageBook, measurementBook, hengelo.Stocks);
                                Console.WriteLine(isbnBook + " Added");

                                break;

                            case 2:

                                


                                //Magazine add cod ehier
                                BookstorLibrary.DayOfWeek dayOfRelease; BookstorLibrary.DayOfWeek dayOfOrder; string issnMag; int totalOrderAmountMag; string titleMag; string authorMag; int weightMag; decimal priceMag; Language languageMag; Measurement measurementMag;
                                Console.WriteLine("Enter ISSN");
                                issnMag = Console.ReadLine();

                                Console.WriteLine("Enter amount to order");
                                Int32.TryParse(Console.ReadLine(), out totalOrderAmountMag);

                                Console.WriteLine("Pick a release day");
                                Console.WriteLine("[1 - 5] Days of the week (Monday - Friday)");
                                int optionday;

                                while (!int.TryParse(Console.ReadLine(), out optionday))
                                {
                                    Console.WriteLine("Enter a number from the selection");
                                }

                                switch (optionday)
                                {
                                    case 1:
                                        dayOfRelease = BookstorLibrary.DayOfWeek.Monday;
                                        break;
                                    case 2:
                                        dayOfRelease = BookstorLibrary.DayOfWeek.Tuesday;
                                        break;
                                    case 3:
                                        dayOfRelease = BookstorLibrary.DayOfWeek.Wednesday;
                                        break;
                                    case 4:
                                        dayOfRelease = BookstorLibrary.DayOfWeek.Thursday;
                                        break;
                                    case 5:
                                        dayOfRelease = BookstorLibrary.DayOfWeek.Friday;
                                        break;
                                    default:
                                        dayOfRelease = BookstorLibrary.DayOfWeek.Monday;
                                        Console.WriteLine("No valid number entered, assigning day of release as monday");
                                        break;
                                };

                                Console.WriteLine("Pick the order day");
                                Console.WriteLine("[1 - 5] Days of the week (Monday - Friday)");
                                

                                while (!int.TryParse(Console.ReadLine(), out optionday))
                                {
                                    Console.WriteLine("Enter a number from the selection");
                                }

                                switch (optionday)
                                {
                                    case 1:
                                        dayOfOrder = BookstorLibrary.DayOfWeek.Monday;
                                        break;
                                    case 2:
                                        dayOfOrder = BookstorLibrary.DayOfWeek.Tuesday;
                                        break;
                                    case 3:
                                        dayOfOrder = BookstorLibrary.DayOfWeek.Wednesday;
                                        break;
                                    case 4:
                                        dayOfOrder = BookstorLibrary.DayOfWeek.Thursday;
                                        break;
                                    case 5:
                                        dayOfOrder = BookstorLibrary.DayOfWeek.Friday;
                                        break;
                                    default:
                                        dayOfOrder = BookstorLibrary.DayOfWeek.Monday;
                                        Console.WriteLine("No valid number entered, assigning day of release as monday");
                                        break;
                                };


                                Console.WriteLine("Enter Title: ");
                                titleMag = Console.ReadLine();

                                Console.WriteLine("Enter Author: ");
                                authorMag = Console.ReadLine();


                                Console.WriteLine("Pick a language (select number): \n" +
                                    "[ 1 ] Dutch \n" +
                                    "[ 2 ] English \n" +
                                    "[ 3 ] French \n" +
                                    "[ 4 ] German \n" +
                                    "[ 5 ] Spanish \n" +
                                    "[ 6 ] Unknown ");


                                int optionlang1;

                                while (!int.TryParse(Console.ReadLine(), out optionlang1))
                                {
                                    Console.WriteLine("Enter a number from the selection");
                                }

                                switch (optionlang1)
                                {
                                    case 1:
                                        languageMag = Language.Dutch;
                                        break;
                                    case 2:
                                        languageMag = Language.English;
                                        break;
                                    case 3:
                                        languageMag = Language.French;
                                        break;
                                    case 4:
                                        languageMag = Language.German;
                                        break;
                                    case 5:
                                        languageMag = Language.Spanish;
                                        break;
                                    case 6:
                                        languageMag = Language.Unknown;
                                        break;
                                    default:
                                        languageMag = Language.Unknown;
                                        Console.WriteLine("No valid number entered, assigning language as \"Unknown\"");
                                        break;
                                };


                                Console.WriteLine("Enter unit weight (gram): ");
                                Int32.TryParse(Console.ReadLine(), out weightMag);

                                Console.WriteLine("Enter unit price (Euro): ");
                                Decimal.TryParse(Console.ReadLine(), out priceMag);

                                int widthMag;
                                int lengthMag;
                                int heightMag;

                                Console.WriteLine("Enter Width (mm): ");
                                Int32.TryParse(Console.ReadLine(), out widthMag);
                                Console.WriteLine("Enter Length (mm): ");
                                Int32.TryParse(Console.ReadLine(), out lengthMag);
                                Console.WriteLine("Enter Height (mm): ");
                                Int32.TryParse(Console.ReadLine(), out heightMag);

                                measurementMag = new Measurement(widthMag, heightMag, lengthMag);



                                break;

                            default:
                                break;

                           
                        }

                        break;


                        
                    #endregion
                    #region Default
                    default:
                        Console.WriteLine("The program will now close");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break; 
                        #endregion


                }

            }
            while (option != 0);
           
            Console.ReadKey();
        }

        

        
    }
}
