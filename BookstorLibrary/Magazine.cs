using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstorLibrary
{
    #region enum
    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }
    #endregion

    public class Magazine : Product
    {
        #region attribute
        private string iSSn;
        private int totalOrderMagazine;
        #endregion       

        #region properties
        public DayOfWeek DayOfRelease { get; set; }
        public DayOfWeek DayOfOrder { get; set; }
        public string ISSn { get => iSSn; set => iSSn = value; }
        public int TotalOrderMagazine { get => totalOrderMagazine; set => totalOrderMagazine = value; }
        #endregion

        #region constructor
        public Magazine(DayOfWeek dayOfRelease, DayOfWeek dayOfOrder, string iSSn, int totalOrderMagazine, string title, string author, int weight, decimal price, Language language, Measurement measurement) : base(title, author, weight, price, language, measurement)
        {
            this.DayOfRelease = dayOfRelease;
            this.DayOfOrder = dayOfOrder;
            this.ISSn = iSSn;
            this.TotalOrderMagazine = totalOrderMagazine;
        }
        #endregion

        #region methodes        
        /// <summary>
        /// Prints the attributes.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string PrintAttributes()
        {
            return Title;
        }

        /// <summary>
        /// Prints the order rule.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string PrintOrderRule()
        {
            return Convert.ToString(DayOfOrder);
        }

        /// <summary>
        /// Gets the order date.
        /// </summary>
        /// <returns>DayOfWeek.</returns>
        public DayOfWeek GetOrderDate()
        {
            return DayOfOrder;
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetKey()
        {
            return ISSn;
        }

        /// <summary>
        /// Gets the stock.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public override int GetStock()
        {
            return TotalOrderMagazine;
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
        /// Orders the magazine by issn.
        /// </summary>
        /// <param name="productList">The product list.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> OrderMagazineByISSN(List<Product> productList)
        {

            List<string> OrderListCol = new List<string>();
            string issn;

            Console.WriteLine("Enter the issn of the magazine you would like to order");
            issn = Console.ReadLine();
            bool trigger = true;

            for (int i = productList.Count - 1; i >= 0; i--)
            {
                Type typeCompare = productList[i].GetType();
                if (typeCompare == typeof(Magazine))
                {

                    if (((Magazine)productList[i]).iSSn == issn)
                    {
                        int orderAmount;
                        Console.WriteLine("Enter the amount you would like to order");
                        while (!int.TryParse(Console.ReadLine(), out orderAmount))
                        {
                            Console.WriteLine("Enter a number!");
                        }
                        int oa1 = orderAmount;

                        ((Magazine)productList[i]).TotalOrderMagazine = ((Magazine)productList[i]).TotalOrderMagazine + oa1;
                        string t1 = ((Magazine)productList[i]).Title;

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
                Console.WriteLine("No magazine found with this ISSN");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }


            return OrderListCol;


        }


        #endregion
    }
}
