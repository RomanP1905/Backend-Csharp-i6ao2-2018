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


        /// <summary>
        /// Gets the book information.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetBookInfo()
        {
            return Print + " " + Title + " " + Author + " " + Weight + " " + Price + " " + Language + " " + Measurement + " " + ISBN + " " + MinStock + " " + MaxStock + " " + Stock; 
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return GetBookInfo();
        }

        /// <summary>
        /// Prints the attributes.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string PrintAttributes()
        {
            return GetBookInfo();
        }

        /// <summary>
        /// Prints the order rule.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string PrintOrderRule()
        {
            return "orderrulebook";
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetKey()
        {
            return ISBN;
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetTitle()
        {
            return Title;
        }

        /// <summary>
        /// Gets the author.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetAuthor()
        {
            return Author;
        }

        /// <summary>
        /// Gets the stock.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public override int GetStock()
        {
            return Stock;
        }

        /// <summary>
        /// Gets the minimum stock.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetMinStock()
        {
            return minStock;
        }

        /// <summary>
        /// Gets the maximum stock.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetMaxStock()
        {
            return maxStock;
        }

        /// <summary>
        /// Orders the book by isbn.
        /// </summary>
        /// <param name="productList">The product list.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
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
