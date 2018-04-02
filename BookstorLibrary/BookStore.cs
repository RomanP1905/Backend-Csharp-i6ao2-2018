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
        /// <summary>
        /// Sells the book by isbn.
        /// </summary>
        /// <param name="iSBN">The i SBN.</param>
        /// <param name="soldBooks">The sold books.</param>
        /// <param name="productList">The product list.</param>
        /// <returns>List&lt;Product&gt;.</returns>
        public static List<Product> SellBookByISBN(string iSBN, int soldBooks, List<Product> productList)
        {
            
            List<Product> Stocks = productList;
            //Een trigger om te zien of er een product is gevonden met het ingevoerde ISBN
            bool haveFound = false;
            for (int i = Stocks.Count - 1; i >= 0; i--)
            {

                Type typeCompare = Stocks[i].GetType();

                //Type product wordt hier gecheckt
                if (typeCompare == typeof(Book))
                {
                    //de key is de ISBN van de boek
                    string key = Stocks[i].GetKey();
                    //Check of de key gelijk is aan de ISBN die is ingevoerd 
                    if (key == iSBN)
                    {
                        //GetStock van de iteratie 
                        int bookStock = Stocks[i].GetStock();
                        //Check zodat je niet meer verkoopt dan dat er in voorraad zijn
                        if (bookStock >= soldBooks)
                        {
                            //Trigger aangeven dat er iets is gevonden
                            haveFound = true;
                            for (int j = 0; j < soldBooks; j++)
                            {
                                //Stock omlaag op de iteratie
                                ((Book)Stocks[i]).Stock--;
                                bookStock--;

                            }
                            //Schrijf de verkochte boek naar console
                            Console.WriteLine("Sold book: \n Title: " + ((Book)Stocks[i]).Title +
                                " \n Author: " + ((Book)Stocks[i]).Author +
                                " \n ISBN: " + ((Book)Stocks[i]).ISBN +
                                " \n Price: " + ((Book)Stocks[i]).Price +
                                " \n Sold amount: " + soldBooks +
                                " \n Total Price: " + soldBooks * ((Book)Stocks[i]).Price

                                );
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();

                        }
                        else
                        {
                            Console.WriteLine("Sold books are higher than stock!");
                            Console.ReadKey();
                        }
                    }
                }

            }
            //Als er niks is gevonden schrijf je  dat in de console
            if (!haveFound)
            {
                Console.WriteLine("Your entry does not match any books in the database");
                Console.ReadKey();

            }

            return Stocks;
        }

        //Verkopen van boeken methode via title        
        /// <summary>
        /// Sells the book by title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="author">The author.</param>
        /// <param name="soldBooks">The sold books.</param>
        /// <param name="productList">The product list.</param>
        /// <returns>List&lt;Product&gt;.</returns>
        public static List<Product> SellBookByTitle(string title, string author,int soldBooks, List<Product> productList)
        {
            List<Product> Stocks = productList;

            bool haveFound = false;
            for (int i = Stocks.Count - 1; i >= 0; i--)
            {
                Type typeCompare = Stocks[i].GetType();
                if (typeCompare == typeof(Book))
                {
                    string titleKey = Stocks[i].GetTitle();
                    string authorKey = Stocks[i].GetAuthor();
                    if (titleKey == title && authorKey == author)
                    {
                        int bookStock = Stocks[i].GetStock();

                    if (bookStock > soldBooks)
                    {
                        
                        
                            haveFound = true;
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

                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                     }

                        else
                        {
                            Console.WriteLine("Sold books are higher than stock!");
                            Console.ReadKey();
                        }

                    }

                    
                }
            }
            if (!haveFound)
            {
                Console.WriteLine("Your entry does not match any books in the database");
                Console.ReadKey();
            }
            
            return Stocks;
        }

        //Verkopen van boeken methode via ISBN        
        /// <summary>
        /// Sells the magazine by issn.
        /// </summary>
        /// <param name="issn">The issn.</param>
        /// <param name="soldmagazine">The soldmagazine.</param>
        /// <param name="Stocks">The stocks.</param>
        /// <returns>List&lt;Product&gt;.</returns>
        public static List<Product> SellMagazineByISSN(string issn, int soldmagazine, List<Product> Stocks)
        {



            for (int i = Stocks.Count - 1; i >= 0; i--)
            {

                Type typeCompare = Stocks[i].GetType();


                if (typeCompare == typeof(Magazine))
                {
                    string key = Stocks[i].GetKey();
                    if (key == issn)
                    {
                        int magazineStock = Stocks[i].GetStock();

                    if (magazineStock > soldmagazine)
                    {
                        
                            for (int j = 0; j < soldmagazine; j++)
                            {
                                ((Magazine)Stocks[i]).TotalOrderMagazine--;
                                magazineStock--;
                            }

                            Console.WriteLine("Sold magazine: \n Title: " + ((Magazine)Stocks[i]).Title +
                            " \n Author: " + ((Magazine)Stocks[i]).Author +
                            " \n ISBN: " + ((Magazine)Stocks[i]).ISSn +
                            " \n Price: " + ((Magazine)Stocks[i]).Price +
                            " \n Sold amount: " + soldmagazine +
                            " \n Total Price: " + soldmagazine * ((Magazine)Stocks[i]).Price

                            );
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        
                        else
                        {
                            Console.WriteLine("Sold magazines are higher than stock");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No such magazine ISSN exists.");
                        Console.ReadKey();
                    }

                }

            }

            return Stocks;

        }


        /// <summary>
        /// Generates the orders.
        /// </summary>
        /// <param name="productList">The product list.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> GenerateOrders(List<Product> productList)
        {
            List<Product> Stocks = productList;
            List<string> OrderListCol = new List<string>();
            bool noOrders = true;

            for (int i = Stocks.Count - 1; i >= 0; i--)
            {
                Type typeCompare = Stocks[i].GetType();
                if (typeCompare == typeof(Magazine))
                {
                    //datum van vandaag
                    DateTime dt = DateTime.Today;
                    //als de orderdatum overeenkomt met de dag van vandaag wordt er een order aangemaakt
                    if (Convert.ToString(((Magazine)Stocks[i]).GetOrderDate()) == Convert.ToString(dt.DayOfWeek))
                    {
                        noOrders = false;
                        int oa1 = ((Magazine)Stocks[i]).TotalOrderMagazine;
                        //Voorraad wordt bijgevult
                        ((Magazine)Stocks[i]).TotalOrderMagazine = ((Magazine)Stocks[i]).TotalOrderMagazine + oa1;
                        string t1 = ((Magazine)Stocks[i]).Title;
                        
                        string ol = "ISSN : " + Stocks[i].GetKey() + " | "
                            + " Titel: " + t1 + " | "
                            + " To Order: " + oa1;
                        OrderListCol.Add(ol);
                    }
                }
                else
                {
                    if(((Book)Stocks[i]).GetStock() < ((Book)Stocks[i]).GetMinStock())
                    {
                        noOrders = false;
                        int oa1 = ((Book)Stocks[i]).GetMaxStock() - Stocks[i].GetStock();
                        ((Book)Stocks[i]).Stock = ((Book)Stocks[i]).Stock + oa1;
                        string t1 = ((Book)Stocks[i]).Title;
                        string ol = "ISBN : " + Stocks[i].GetKey() + " | "
                            + " Titel: " + t1 + " | "
                            + " To Order: " + oa1;
                        OrderListCol.Add(ol);
                    }
                } 
            }

            if (noOrders)
            {
                Console.WriteLine("There are no products that need to be ordered at the moment.");
            }
            
            return OrderListCol;

        }




        //public static string ListOrders(List<string> orderItemsList)
        //{
        //    List<String> r1 = new List<String>();
        //    foreach (var order in orderItemsList)
        //    {

        //        string s1 = order;
        //        r1.Add(s1);
        //    }

        //    string r2 = "";

        //        foreach (var listitem in r1)
        //      {
        //        if(r1.Count != 0)
        //        {
        //        r2 = r1[r1.Count - 1] + " \n";
        //        }

        //      }


        //    return


        //        r2;
        //}

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

        /// <summary>
        /// Adds the new book.
        /// </summary>
        /// <param name="print">The print.</param>
        /// <param name="iSBN">The i SBN.</param>
        /// <param name="minStock">The minimum stock.</param>
        /// <param name="maxStock">The maximum stock.</param>
        /// <param name="stock">The stock.</param>
        /// <param name="title">The title.</param>
        /// <param name="author">The author.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="price">The price.</param>
        /// <param name="language">The language.</param>
        /// <param name="measurement">The measurement.</param>
        /// <param name="productList">The product list.</param>
        public static void AddNewBook(string print, string iSBN, int minStock, int maxStock, int stock, string title, string author, int weight, decimal price, Language language, Measurement measurement, List<Product> productList)
        {

            List<Product> Stocks = productList;

            Stocks.Add(new Book(print, iSBN, minStock, maxStock, stock, title, author, weight, price, language, measurement));


        }

        /// <summary>
        /// Adds the new magazine.
        /// </summary>
        /// <param name="dayOfRelease">The day of release.</param>
        /// <param name="dayOfOrder">The day of order.</param>
        /// <param name="iSSn">The i s sn.</param>
        /// <param name="totalOrderMagazine">The total order magazine.</param>
        /// <param name="title">The title.</param>
        /// <param name="author">The author.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="price">The price.</param>
        /// <param name="language">The language.</param>
        /// <param name="measurement">The measurement.</param>
        /// <param name="productList">The product list.</param>
        public static void AddNewMagazine(BookstorLibrary.DayOfWeek dayOfRelease, BookstorLibrary.DayOfWeek dayOfOrder, string iSSn, int totalOrderMagazine, string title, string author, int weight, decimal price, Language language, Measurement measurement, List<Product> productList)
        {

            List<Product> Stocks = productList;

            Stocks.Add(new Magazine(dayOfRelease, dayOfOrder, iSSn, totalOrderMagazine, title, author, weight, price, language, measurement));


        }

        /// <summary>
        /// Removes the book from stock by isbn.
        /// </summary>
        /// <param name="isbn">The isbn.</param>
        /// <param name="productList">The product list.</param>
        public static void RemoveBookFromStockByISBN(string isbn , List<Product> productList)
        {
            List<Product> Stocks = productList;


            for (int i = Stocks.Count - 1; i >= 0; i--)
            {
                Type typeCompare = Stocks[i].GetType();
                if (typeCompare == typeof(Book))
                {
                    if (((Book)Stocks[i]).ISBN == isbn)
                    {
                        Console.WriteLine("Removed Book: \"" + ((Book)Stocks[i]).Title + "\" ISBN: " + ((Book)Stocks[i]).ISBN);
                        Stocks.Remove((Book)Stocks[i]);
                    }
                }
            }
            

        }

        /// <summary>
        /// Removes the magazine from stock by issn.
        /// </summary>
        /// <param name="issn">The issn.</param>
        /// <param name="productList">The product list.</param>
        public static void RemoveMagazineFromStockByISSN(string issn, List<Product> productList)
        {
            List<Product> Stocks = productList;


            for (int i = Stocks.Count - 1; i >= 0; i--)
            {
                Type typeCompare = Stocks[i].GetType();
                if (typeCompare == typeof(Magazine))
                {
                    if (((Magazine)Stocks[i]).ISSn == issn)
                    {
                        Console.WriteLine("Removed magazine: \"" + ((Magazine)Stocks[i]).Title + "\" ISSN: " + ((Magazine)Stocks[i]).ISSn);
                        Stocks.Remove((Magazine)Stocks[i]);
                        
                    }
                }
            }


        }

        /// <summary>
        /// Lists the last order.
        /// </summary>
        /// <param name="orderList">The order list.</param>
        public static void ListLastOrder(List<Order> orderList)
        {
            int option;
            bool trigger = true;

            List<Order> orderListHolder = orderList;
            //Ga achterwaards door de lijst heen op zoek naar records waar "orderhandled" false is.
            for (int i = orderListHolder.Count - 1; i >= 0; i--)
            {
                //Is de order op OrderHandled : false
                if(orderListHolder[i].OrderHandled == false)
                {
                    //Zet die order in een variabel
                    Order lastOrder = orderListHolder[i];
                    string orderItemsString = "";
                    //Zet alle producten in de order in een string
                    foreach (string orderitem in lastOrder.OrderList)
                    {
                        orderItemsString += orderitem;
                    }

                    Console.WriteLine("Order created on: " + lastOrder.OrderDate +
                        "\n Order items: \n " + orderItemsString);

                    Console.WriteLine("Enter Y to finish this order or enter any other character to return to the main menu.");
                    //Read voor input
                    string optionString = Console.ReadLine();

                    if (optionString == "Y" || optionString == "y")
                    {
                        option = 1;
                    }
                    else
                    {
                        trigger = false;
                        break;
                    }

                    if (option == 1)
                    {
                        //zet de orderhandled naar true
                        orderListHolder[i].OrderHandled = true;
                        Console.WriteLine("Order has been marked as handled");
                        
                    }




                    trigger = false;

                }

            }
            if (trigger)
            {
                Console.WriteLine("No unhandled orders found. Press any key to continue...");
                Console.ReadKey();
            }


        }

        /// <summary>
        /// Lists the unhandled orders.
        /// </summary>
        /// <param name="orderList">The order list.</param>
        public static void ListUnhandledOrders(List<Order> orderList)
        {
            int option;
            bool trigger = false;
            string ordersString = "";
            int index = 0;
            int selectedIndex = -1;
            int selectedItemIndex = -1;

            foreach (Order order in orderList)
               {


                //Laat alleen unhandled orders zien
                if (!order.OrderHandled)
                {
                    trigger = true;
                    string orderListString = "";
                    int stringIndex = 0;
                    //zet de order producten in een string
                    foreach (string orderitem in order.OrderList)
                    {
                        
                        orderListString += "[ id: " + stringIndex + " ]" + orderitem + "\n";
                        stringIndex++;
                    }


                    ordersString = "[ " + index + " ] Order Date: " + order.OrderDate.ToString("dd/MM/yyyy") + " \n" + orderListString + " \n-----------------------------------------------------------------------------";
                    index++; 
                }

                
                }
                if (trigger)
                {
                    Console.WriteLine(ordersString);

                }
                else
                {
                    Console.WriteLine("No unhandled orders were found. Press any key to continue...");
                    Console.ReadKey();
                }


                //als er geen orders zijn niet de opties laten zien.
            if (ordersString != "")
            {


                Console.WriteLine("Select a record to edit.");
                //Check voor validiteit van de input, het verwacht een int
                while (!int.TryParse(Console.ReadLine(), out selectedIndex))
                {
                    Console.WriteLine("Enter a number!");
                }
                Console.WriteLine("What do you wish to do?");
                Console.WriteLine("[ 1 ] Delete the order");
                Console.WriteLine("[ 2 ] Edit order contents");
                Console.WriteLine("[ 3 ] Change order date");
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Enter a number!");
                }
                

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter the number of the order again to confirm deletion.");
                        while (!int.TryParse(Console.ReadLine(), out selectedIndex))
                        {
                            Console.WriteLine("Enter a number!");
                        }
                        if (selectedIndex != -1)
                        {
                            OrderItems.RemoveOrderByIndex(selectedIndex);
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter the index of the item you wish to remove.");
                        while (!int.TryParse(Console.ReadLine(), out selectedItemIndex))
                        {
                            Console.WriteLine("Enter a number!");
                        }
                        if (selectedItemIndex != -1)
                        {
                            Order.RemoveFromOrder(selectedItemIndex, orderList[selectedIndex].OrderList);
                        }
                        if (OrderItems.OrderList[selectedIndex].OrderList.Count() == 0)
                        {
                            OrderItems.RemoveOrderByIndex(selectedIndex);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the new date. Format: (31-12-2000)");
                        string line = Console.ReadLine();
                        DateTime dt;
                        while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                        {
                            Console.WriteLine("Invalid date, please retry");
                            line = Console.ReadLine();
                        }
                        OrderItems.ChangeDateByIndex(selectedIndex, dt);
                        break;
                    default:
                        break;
                }

                
            }
            





        }

        /// <summary>
        /// Sees the order by date.
        /// </summary>
        /// <param name="enteredDate">The entered date.</param>
        /// <param name="orderList">The order list.</param>
        public static void SeeOrderByDate(string enteredDate, List<Order> orderList)
        {
            string listString = "Found Orders: \n";
            bool trigger = false;
            foreach(Order order in orderList)
            {
                string dateCompare = order.OrderDate.ToString("dd/MM/yyyy");
                //Datum vergelijke met ingevoerde datum
                if (dateCompare == enteredDate)
                {
                    trigger = true;
                    string orderListString = "";

                    foreach (string orderitem in order.OrderList)
                    {
                        orderListString += orderitem + "\n";
                    }

                    listString += "Order Date: " + order.OrderDate.ToString("dd/MM/yyyy") + " | " + orderListString;
                }
                if (trigger)
                {
                    Console.WriteLine(listString);
                    Console.WriteLine("Press any key to return back to the main menu...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("No orders were found on the entered date. Press any key to continue...");
                    Console.ReadKey();
                }
            }
                
        }

        /// <summary>
        /// Changes the book stock constraints.
        /// </summary>
        /// <param name="productList">The product list.</param>
        public static void ChangeBookStockConstraints(List<Product> productList)
        {
            List<Product> Stocks = productList;
            string isbn;
            int minStock;
            int maxStock;

            Console.WriteLine("Enter the ISBN of the book you wish to change the constraints of");
            isbn = Console.ReadLine();

            for (int i = Stocks.Count - 1; i >= 0; i--)
            {
                //Check op type van product
                Type typeCompare = Stocks[i].GetType();
                if (typeCompare == typeof(Book))
                {


                    if (((Book)Stocks[i]).ISBN == isbn)
                    {
                        Console.WriteLine("Enter the new minimum stock (enter 0 to make no changes)");
                        while (!int.TryParse(Console.ReadLine(), out minStock))
                        {
                            Console.WriteLine("Enter a valid width number");
                        }

                        Console.WriteLine("Enter the new maximum stock (enter 0 to make no changes)");
                        while (!int.TryParse(Console.ReadLine(), out maxStock))
                        {
                            Console.WriteLine("Enter a valid width number");
                        }

                        if(minStock != 0)
                        {
                            ((Book)Stocks[i]).MinStock = minStock;
                        }

                        if (maxStock != 0)
                        {
                            ((Book)Stocks[i]).MaxStock = maxStock;
                        }

                        Console.WriteLine("{0} new minimum stock: {1} - new maximum stock: {2}", ((Book)Stocks[i]).Title, minStock, maxStock);

                    }
                }
            }


        }

        /// <summary>
        /// Changes the magazine stock constraints.
        /// </summary>
        /// <param name="productList">The product list.</param>
        public static void ChangeMagazineStockConstraints(List<Product> productList)
        {
            List<Product> Stocks = productList;
            string issn;
            int orderChange;

            Console.WriteLine("Enter the ISNN of the magazine you wish to change the constraints of");
            issn = Console.ReadLine();


            for (int i = Stocks.Count - 1; i >= 0; i--)
            {

                Type typeCompare = Stocks[i].GetType();
                if (typeCompare == typeof(Magazine))
                {

                    


                    if (((Magazine)Stocks[i]).ISSn == issn)
                    {
                        Console.WriteLine("Enter the new order amount (enter 0 to make no changes)");
                        while (!int.TryParse(Console.ReadLine(), out orderChange))
                        {
                            Console.WriteLine("Enter a valid width number");
                        }

                        

                        if (orderChange != 0)
                        {
                            ((Magazine)Stocks[i]).TotalOrderMagazine = orderChange;
                        }

                        Console.WriteLine("{0} new order amount: {1}", ((Magazine)Stocks[i]).Title, orderChange);
                        Console.WriteLine("Press any key to return to the menu...");

                        Console.ReadKey();

                    }
                }
            }


        }

        }
    }
