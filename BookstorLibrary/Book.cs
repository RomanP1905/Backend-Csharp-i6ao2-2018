using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstorLibrary
{
    public class Book: Product
    {
        #region attribute
        private string print;
        private string iSBN;
        private int minStock;
        private int maxStock;
        private int stock;
        private string orderRule;
        #endregion

        #region properties
        public string Print { get => print; set => print = value; }
        public string ISBN { get => iSBN; set => iSBN = value; }
        public int MinStock { get => minStock; set => minStock = value; }
        public int MaxStock { get => maxStock; set => maxStock = value; }
 
        public int Stock { get => stock; set => stock = value; }



        public string OrderRule { get => orderRule; }
        #endregion

        #region constructor
        public Book(string print, string iSBN, int minStock, int maxStock, int stock, string title, string author, int weight, decimal price, Language language, Measurement measurement) : base(title, author, weight, price, language, measurement)
        {
            Print = print;
            ISBN = iSBN;
            MinStock = minStock;
            MaxStock = maxStock;
            Stock = stock;
            
        }
        #endregion

        

        #region methodes       

        

        public string GetBookInfo()
        {
            return Print + " " + Title + " " + Author + " " + Weight + " " + Price + " " + Language + " " + Measurement + " " + ISBN + " " + MinStock + " " + MaxStock + " " + Stock; 
        }


        public override string ToString()
        {
            return GetBookInfo();
        }

        public override string PrintAttributes()
        {
            return GetBookInfo();
        }

        public override string PrintOrderRule()
        {
            return "orderrulebook";
        }

        public override string GetKey()
        {
            return ISBN;
        }

        public override string GetTitle()
        {
            return Title;
        }
        public override string GetAuthor()
        {
            return Author;
        }
        public override int GetStock()
        {
            return Stock;
        }

        public int GetMinStock()
        {
            return minStock;
        }

        public int GetMaxStock()
        {
            return maxStock;
        }

        public static List<string> OrderBookByISBN(List<Product> productList)
        {

            List<string> OrderListCol = new List<string>();
            string isbn;

            Console.WriteLine("Enter the isbn of the book you would like to order");
            isbn = Console.ReadLine();
            bool trigger = true;

            for (int i = productList.Count - 1; i >= 0; i--)
            {
                Type typeCompare = productList[i].GetType();
                if (typeCompare == typeof(Book))
                {

                    if (((Book)productList[i]).ISBN == isbn)
                    {
                        int orderAmount;
                        Console.WriteLine("Enter the amount you would like to order");
                        while (!int.TryParse(Console.ReadLine(), out orderAmount))
                        {
                            Console.WriteLine("Enter a number!");
                        }
                        int oa1 = orderAmount;

                        ((Book)productList[i]).Stock = ((Book)productList[i]).Stock + oa1;
                        string t1 = ((Book)productList[i]).Title;

                        string orderL = "ISBN : " + productList[i].GetKey() + " | "
                            + " Titel: " + t1 + " | "
                            + " To Order: " + oa1;

                        OrderListCol.Add(orderL);
                        trigger = false;
                    }
                    
                }
                


            }
            if (trigger)
            {
                Console.WriteLine("No book found with this ISBN");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }


            return OrderListCol;


        }



        #endregion
    }
}
