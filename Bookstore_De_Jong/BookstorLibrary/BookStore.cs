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

        #region properties
        public List<Product> Stocks { get; set; } = new List<Product>();
        public OrderItems ObjOrderItems { get; set; }
        public string ContactInfo { get => contactInfo; set => contactInfo = value; }
        public string BusinessHours { get => businessHours; set => businessHours = value; }
        #endregion


        //Verkopen van boeken methode via ISBN
        public static List<Product> SellBookByISBN(string iSBN, int soldBooks)
        {
            List<Product> Stocks = Product.GetTestData();
            for (int i = Stocks.Count - 1; i >= 0; i--)
            {

                Type typeCompare = Stocks[i].GetType();
                

                if (typeCompare == typeof(Book))
                {
                    int bookStock = Stocks[i].GetStock();

                    if (bookStock >= soldBooks)
                    {
                        string key = Stocks[i].GetKey();
                        if (key == iSBN)
                        {
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
            return Stocks;
        }

        //Verkopen van boeken methode via title
        public static List<Product> SellBookByTitle(string title, string author,int soldBooks)
        {
            List<Product> Stocks = Product.GetTestData();
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

        public class OrderList
        {
            public string OrderProduct;
            public int OrderAmount;
            public string OrderTitle;
            public OrderList(string orderProduct, int orderAmount, string orderTitle)
            {
                OrderAmount = orderAmount;
                OrderProduct = orderProduct;
                OrderTitle = orderTitle;
            }
        }



        public static List<OrderList> CheckOrders()
        {
            List<Product> Stocks = Product.GetTestData();
            List<OrderList> OrderListCol = new List<OrderList>();

            for (int i = Stocks.Count - 1; i >= 0; i--)
            {
                Type typeCompare = Stocks[i].GetType();
                if (typeCompare == typeof(Magazine))
                {
                    DateTime dt = DateTime.Today;
                    if (Convert.ToString(((Magazine)Stocks[i]).GetOrderDate()) == Convert.ToString(dt.DayOfWeek))
                    {
                        int oa1 = ((Magazine)Stocks[i]).GetStock();
                        string t1 = ((Magazine)Stocks[i]).Title;
                        OrderList ol = new OrderList(Stocks[i].GetKey(), oa1, t1);
                        OrderListCol.Add(ol);
                    }
                }
                else
                {
                    if(((Book)Stocks[i]).GetStock() < ((Book)Stocks[i]).GetMinStock())
                    {
                        int oa1 = ((Book)Stocks[i]).GetMaxStock() - Stocks[i].GetStock();
                        string t1 = ((Book)Stocks[i]).Title;
                        OrderList ol = new OrderList(Stocks[i].GetKey(), oa1, t1 );
                        OrderListCol.Add(ol);
                    }
                } 
            }
            return OrderListCol;
        }
    }
}
