using BookstorLibrary;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreLibrary
{
    public class BookStore
    {
        #region attributes
        private string contactInfo;
        private string businessHours;
        #endregion

        #region constructor
        public BookStore()
        {
        }
        #endregion

        

        //private static List<Product> productList = Product.GetTestData();

        public List<Product> Stocks { get; set; }
        public string ContactInfo { get => contactInfo; set => contactInfo = value; }
        public string BusinessHours { get => businessHours; set => businessHours = value; }
        public OrderItems ObjOrderItems { get; set; }

        //Verkopen van boeken methode via ISBN
        public static List<Product> SellBookByISBN(string iSBN, int soldBooks, List<Product> productList)
        {
            
            List<Product> Stocks = productList;
            for (int i = Stocks.Count - 1; i >= 0; i--)
            {

                Type typeCompare = Stocks[i].GetType();


                if (typeCompare == typeof(Book))
                {
                    string key = Stocks[i].GetKey();
                    if (key == iSBN)
                    {
                        int bookStock = Stocks[i].GetStock();

                        if (bookStock >= soldBooks)
                        {

                            for (int j = 0; j < soldBooks; j++)
                            {
                                ((Book)Stocks[i]).Stock--;
                                bookStock--;

                            }

                            Console.WriteLine("Sold book: \n Title: " + ((Book)Stocks[i]).Title +
                                " \n Author: " + ((Book)Stocks[i]).Author +
                                " \n ISBN: " + ((Book)Stocks[i]).ISBN +
                                " \n Price: " + ((Book)Stocks[i]).Price +
                                " \n Sold amount: " + soldBooks +
                                " \n Total Price: " + soldBooks * ((Book)Stocks[i]).Price

                                );

                        }
                        else
                        {
                            throw new System.ArgumentException("Sold books are higher than stock");
                        }
                    }
                }

            }
            return Stocks;
        }

        //Verkopen van boeken methode via title
        public static List<Product> SellBookByTitle(string title, string author,int soldBooks, List<Product> productList)
        {
            List<Product> Stocks = productList;

            bool haveFound = false;
            for (int i = Stocks.Count - 1; i >= 0; i--)
            {
                Type typeCompare = Stocks[i].GetType();
                if (typeCompare == typeof(Book))
                {
                    int bookStock = Stocks[i].GetStock();

                    if (bookStock > soldBooks)
                    {
                        string titleKey = Stocks[i].GetTitle();
                        if (titleKey == title)
                        {
                            haveFound = true;
                            for (int j = 0; j < soldBooks; j++)
                            {
                                ((Book)Stocks[i]).Stock--;
                                bookStock--;
                            }
                        }



                    }

                    else
                    {
                        throw new System.ArgumentException("Sold books are higher than stock");
                    }
                }
            }
            if (!haveFound)
            {
                Console.WriteLine("Your entry does not match any books in the database");
            }
            
            return Stocks;
        }

        //Verkopen van boeken methode via ISBN
        public static List<Product> SellMagazineByISSN(string issn, int soldmagazine, List<Product> Stocks)
        {
            for (int i = Stocks.Count - 1; i >= 0; i--)
            {

                Type typeCompare = Stocks[i].GetType();


                if (typeCompare == typeof(Magazine))
                {
                    int bookStock = Stocks[i].GetStock();

                    if (bookStock > soldmagazine)
                    {
                        string key = Stocks[i].GetKey();
                        if (key == issn)
                        {
                            for (int j = 0; j < soldmagazine; j++)
                            {

                            }
                        }
                        else
                        {
                            throw new System.ArgumentException("No such book ISBN exists.");
                        }

                    }
                    else
                    {
                        throw new System.ArgumentException("Sold books are higher than stock");
                    }
                }

            }

            return Stocks;

        }



        public static List<string> GenerateOrders(List<Product> productList)
        {
            List<Product> Stocks = productList;
            List<string> OrderListCol = new List<string>();

            for (int i = Stocks.Count - 1; i >= 0; i--)
            {
                Type typeCompare = Stocks[i].GetType();
                if (typeCompare == typeof(Magazine))
                {
                    DateTime dt = DateTime.Today;
                    if (Convert.ToString(((Magazine)Stocks[i]).GetOrderDate()) == Convert.ToString(dt.DayOfWeek))
                    {
                        int oa1 = ((Magazine)Stocks[i]).TotalOrderMagazine;
                        string t1 = ((Magazine)Stocks[i]).Title;
                        
                        string ol = "ISSN : " + Stocks[i].GetKey()
                            + " To Order: " + oa1
                            + " Titel: " + t1;
                        OrderListCol.Add(ol);
                    }
                }
                else
                {
                    if(((Book)Stocks[i]).GetStock() < ((Book)Stocks[i]).GetMinStock())
                    {
                        int oa1 = ((Book)Stocks[i]).GetMaxStock() - Stocks[i].GetStock();
                        string t1 = ((Book)Stocks[i]).Title;
                        string ol = "ISSN : " + Stocks[i].GetKey()
                            + " To Order: " + oa1
                            + " Titel: " + t1;
                        OrderListCol.Add(ol);
                    }
                } 
            }
            return OrderListCol;
        }




        public static string ListOrders(List<string> orderItemsList)
        {
            List<String> r1 = new List<String>();


            foreach (var order in orderItemsList)
            {

                string s1 = order;
                r1.Add(s1);
            }

            string r2 = "";

            foreach (var listitem in r1)
            {

                r2 += listitem + " \n";
            }


            return

                r2;
        }

        public static string ListProduct(List<Product> productList)
        {
            List<Product> Stocks = productList;
            List<String> r1 = new List<String>();

            for (int i = Stocks.Count - 1; i >= 0; i--)
            {
                Type typeCompare = Stocks[i].GetType();
                if (typeCompare == typeof(Book))
                {
                    string s1 = "Titel Boek: " + Stocks[i].Title +
                    "\nISBN: " + ((Book)Stocks[i]).ISBN +
                    "\nAuteur: " + Stocks[i].Author +
                    "\nTaal: " + Stocks[i].Language +
                    "\nPrijs: " + Stocks[i].Price +
                    "\nGewicht: " + ((Book)Stocks[i]).Weight + " gram" +
                    "\nStaand: " + ((Book)Stocks[i]).Measurement.Width +
                    " x " + ((Book)Stocks[i]).Measurement.Height +
                    " x " + ((Book)Stocks[i]).Measurement.Lenght + " mm" +
                    "\nAantal op voorraad: " + Stocks[i].GetStock() +
                    "\nMaximaal aantal Boeken: " + ((Book)Stocks[i]).MaxStock +
                    "\nMinimaal aantal Boeken: " + ((Book)Stocks[i]).MinStock +
                    Environment.NewLine;
                    r1.Add(s1);
                    
                }
                else
                {
                    string s1 = "Titel Tijdschrift: " + Stocks[i].Title +
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
                    Environment.NewLine;
                    r1.Add(s1);

                }           
            }

            string r2 = "";

            foreach (var listitem in r1)
            {

                r2 += listitem + " \n";
            }


            return 
                
                r2;
        }

        public static void AddNewBook(string print, string iSBN, int minStock, int maxStock, int stock, string title, string author, int weight, decimal price, Language language, Measurement measurement, List<Product> productList)
        {

            List<Product> Stocks = productList;

            Stocks.Add(new Book(print, iSBN, minStock, maxStock, stock, title, author, weight, price, language, measurement));


        }

        public static void AddNewMagzine(BookstorLibrary.DayOfWeek dayOfRelease, BookstorLibrary.DayOfWeek dayOfOrder, string iSSn, int totalOrderMagazine, string title, string author, int weight, decimal price, Language language, Measurement measurement, List<Product> productList)
        {

            List<Product> Stocks = productList;

            Stocks.Add(new Magazine(dayOfRelease, dayOfOrder, iSSn, totalOrderMagazine, title, author, weight, price, language, measurement));


        }



    }
}
