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
        public static List<Product> SellBookByISBN(string iSBN, int soldBooks, List<Product> Stocks)
        {

            for (int i = Stocks.Count - 1; i >= 0; i--)
            {

                Type typeCompare = Stocks[i].GetType();
                

                if (typeCompare == typeof(Book))
                {
                    int bookStock = Stocks[i].GetStock();

                    if (bookStock > soldBooks)
                    {
                        string key = Stocks[i].GetKey();
                        if (key == iSBN)
                        {
                            for (int j = 0; j < soldBooks; j++)
                            {
                                

                                
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





        }
            
 

        
    }
