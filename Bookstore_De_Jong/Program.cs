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
            hengelo.BusinessHours = "Mo-Vr 8:00 - 15:00";
            hengelo.ContactInfo = "Find me on my website: www.bookstore-hengelo.nl";

            int option;

            do
            {
                Console.Clear();
                Console.WriteLine("[ 1 ] Print stock");
                Console.WriteLine("[ 2 ] Generate order");
                Console.WriteLine("[ 3 ] Sell book");
                Console.WriteLine("[ 4 ] Sell magazine");
                Console.WriteLine("[ 5 ] Add new book or magazine");
                Console.WriteLine("[ 6 ] Delete a book or magazine");
                Console.WriteLine("[ 7 ] Mark last order as completed");
                Console.WriteLine("[ 8 ] Show unhandled orders");
                Console.WriteLine("[ 9 ] Find order by date");
                Console.WriteLine("[ 10 ] Change stock constraints");
                Console.WriteLine("[ 11 ] Manually order a product");


                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Enter a number!");
                }

                switch (option)
                {
                    #region Print Stock
                    case 1:
                        Console.Clear();
                        Console.WriteLine(BookStore.ListProduct(hengelo.Stocks));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break; 
                    #endregion
                    #region Generate Order
                    case 2:
                        Console.Clear();
                        Order.AddGeneratedOrder(hengelo.Stocks);                            
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();


                        break; 
                    #endregion
                    #region Sell Book
                    case 3:
                        
                        Console.WriteLine("[ 1 ] Sell book by title");
                        Console.WriteLine("[ 2 ] Sell book by ISBN");
                        while (!int.TryParse(Console.ReadLine(), out option))
                        {
                            Console.WriteLine("Enter a number!");
                        }
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Enter the title");
                                string titel = Console.ReadLine();

                                Console.WriteLine("Enter the author");
                                string author = Console.ReadLine();

                                Console.WriteLine("Enter the amount of sold books");
                                int soldBooks;
                                while (!int.TryParse(Console.ReadLine(), out soldBooks))
                                {
                                    Console.WriteLine("Enter a number!");
                                }
                                hengelo.Stocks = BookStore.SellBookByTitle(titel, author, soldBooks, hengelo.Stocks);
                                BookStore.ListProduct(hengelo.Stocks);
                                break;

                            case 2:
                                Console.WriteLine("Enter the ISBN");
                                string isbn = Console.ReadLine();

                                Console.WriteLine("Enter the amount of sold books");
                                int soldBooks2;
                                while (!int.TryParse(Console.ReadLine(), out soldBooks2))
                                {
                                    Console.WriteLine("Enter a number!");
                                }
                                hengelo.Stocks = BookStore.SellBookByISBN(isbn, soldBooks2, hengelo.Stocks);
                                BookStore.ListProduct(hengelo.Stocks);
                                break;

                            default:
                                break;
                        }



                        break;
                    case 4:
                        Console.WriteLine("Enter the ISSN");
                        string issn = Console.ReadLine();

                        Console.WriteLine("Enter the amount of sold magazines");
                        int soldMagazines;
                        while (!int.TryParse(Console.ReadLine(), out soldMagazines))
                        {
                            Console.WriteLine("Enter a number");
                        }
                        hengelo.Stocks = BookStore.SellMagazineByISSN(issn, soldMagazines, hengelo.Stocks);
                        BookStore.ListProduct(hengelo.Stocks);

                        break;
                        #endregion
                        #region Add new book or magazine
                    case 5:
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
                                while (!int.TryParse(Console.ReadLine(), out minStockBook))
                                {
                                    Console.WriteLine("Enter a number");
                                }

                                Console.WriteLine("Enter maximum stock: ");
                                while (!int.TryParse(Console.ReadLine(), out maxStockBook))
                                {
                                    Console.WriteLine("Enter a number");
                                }

                                Console.WriteLine("Enter current stock: ");
                                while (!int.TryParse(Console.ReadLine(), out stockBook))
                                {
                                    Console.WriteLine("Enter a number");
                                }

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
                                while (!int.TryParse(Console.ReadLine(), out weightBook))
                                {
                                    Console.WriteLine("Enter a valid number");
                                }


                                Console.WriteLine("Enter unit price (Euro): ");
                                Console.WriteLine("Enter unit weight (gram): ");
                                while (!Decimal.TryParse(Console.ReadLine(), out priceBook))
                                {
                                    Console.WriteLine("Enter a valid decimal number (0,00)");
                                }

                                int width4;
                                int length4;
                                int height4;

                                Console.WriteLine("Enter Width (mm): ");
                                while (!int.TryParse(Console.ReadLine(), out width4))
                                {
                                    Console.WriteLine("Enter a valid width number");
                                }

                                Console.WriteLine("Enter Length (mm): ");
                                while (!int.TryParse(Console.ReadLine(), out length4))
                                {
                                    Console.WriteLine("Enter a valid length number");
                                }

                                Console.WriteLine("Enter Height (mm): ");
                                while (!int.TryParse(Console.ReadLine(), out height4))
                                {
                                    Console.WriteLine("Enter a valid height number");
                                }

                                measurementBook = new Measurement(width4, height4, length4);


                                BookStore.AddNewBook(printBook, isbnBook, minStockBook, maxStockBook, stockBook, titleBook, authorBook, weightBook, priceBook, languageBook, measurementBook, hengelo.Stocks);
                                Console.WriteLine(isbnBook + " Added");

                                break;

                            case 2:
                                BookstorLibrary.DayOfWeek dayOfRelease; BookstorLibrary.DayOfWeek dayOfOrder; string issnMag; int totalOrderAmountMag; string titleMag; string authorMag; int weightMag; decimal priceMag; Language languageMag; Measurement measurementMag;
                                Console.WriteLine("Enter ISSN");
                                issnMag = Console.ReadLine();

                                Console.WriteLine("Enter amount to order");
                                while (!int.TryParse(Console.ReadLine(), out totalOrderAmountMag))
                                {
                                    Console.WriteLine("Enter a valid width number");
                                }

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
                                while (!int.TryParse(Console.ReadLine(), out weightMag))
                                {
                                    Console.WriteLine("Enter a valid width number");
                                }

                                Console.WriteLine("Enter unit price (Euro): ");
                                while (!Decimal.TryParse(Console.ReadLine(), out priceMag))
                                {
                                    Console.WriteLine("Enter a valid width number");
                                }

                                int widthMag;
                                int lengthMag;
                                int heightMag;

                                Console.WriteLine("Enter Width (mm): ");
                                while (!int.TryParse(Console.ReadLine(), out widthMag))
                                {
                                    Console.WriteLine("Enter a valid width number");
                                }
                                Console.WriteLine("Enter Length (mm): ");
                                while (!int.TryParse(Console.ReadLine(), out lengthMag))
                                {
                                    Console.WriteLine("Enter a valid width number");
                                }
                                Console.WriteLine("Enter Height (mm): ");
                                while (!int.TryParse(Console.ReadLine(), out heightMag))
                                {
                                    Console.WriteLine("Enter a valid width number");
                                }

                                measurementMag = new Measurement(widthMag, heightMag, lengthMag);

                                BookStore.AddNewMagazine(dayOfRelease, dayOfOrder, issnMag, totalOrderAmountMag, titleMag, authorMag, weightMag, priceMag, languageMag, measurementMag, hengelo.Stocks);

                                break;

                            default:
                                break;

                        }

                        break;

                        case 6:
                        Console.Clear();
                        Console.WriteLine("[ 1 ] Remove Book");
                        Console.WriteLine("[ 2 ] Remove Magazine");
                        
                        while (!int.TryParse(Console.ReadLine(), out option))
                        {
                            Console.WriteLine("Enter a valid number!");
                        }
                        switch (option)
                        {
                            case 1:
                                string removeBookIsbn;

                                Console.WriteLine("Enter the ISBN of the book you wish to remove");
                                removeBookIsbn = Console.ReadLine();

                                BookStore.RemoveBookFromStockByISBN(removeBookIsbn, hengelo.Stocks);

                                break;

                            case 2:
                                string removeMagIssn;

                                Console.WriteLine("Enter the ISSN of the magazine you wish to remove");
                                removeMagIssn = Console.ReadLine();

                                BookStore.RemoveMagazineFromStockByISSN(removeMagIssn, hengelo.Stocks);

                                break;

                            default:
                                break;
                        }
                        break;
                    case 7:

                        Console.WriteLine("------------------------------ Last Order ------------------------------");
                        BookStore.ListLastOrder(OrderItems.OrderList);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        break;
                    case 8:
                        Console.Clear();
                        BookStore.ListUnhandledOrders(OrderItems.OrderList);

                        break;
                    case 9:
                        Console.Clear();
                        string enteredDate;
                        Console.WriteLine("Enter a date (day-month-year) example: 25-06-2017");
                        enteredDate = Console.ReadLine();
                        BookStore.SeeOrderByDate(enteredDate, OrderItems.OrderList);
                        
                        break;
                    case 10:
                        Console.Clear();
                        Console.WriteLine("[ 1 ] Change book constraints");
                        Console.WriteLine("[ 2 ] Change magazine constraints");

                        while (!int.TryParse(Console.ReadLine(), out option))
                        {
                            Console.WriteLine("Enter a valid number!");
                        }
                        switch (option)
                        {
                            case 1:
                                BookStore.ChangeBookStockConstraints(hengelo.Stocks);
                                break;

                            case 2:
                                BookStore.ChangeMagazineStockConstraints(hengelo.Stocks);
                                break;
                        }

                        break;
                    case 11:
                        Console.Clear();
                        Console.WriteLine("[ 1 ] Order book");
                        Console.WriteLine("[ 2 ] Order magazine");
                        
                        while (!int.TryParse(Console.ReadLine(), out option))
                        {
                            Console.WriteLine("Enter a valid number!");
                        }
                        switch (option)
                        {
                            case 1:
                                Order.AddBookToOrder(hengelo.Stocks);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            case 2:
                                Order.AddMagazineToOrder(hengelo.Stocks);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
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
