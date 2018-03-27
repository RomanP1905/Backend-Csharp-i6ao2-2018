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
            return Print + " " + ISBN + " " + MinStock + " " + MaxStock + " "; 
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

        public override int GetStock()
        {
            return Stock;
        }

        public override void SellItem()
        {
            Stock--;
        }

        public int GetMinStock()
        {
            return minStock;
        }

        public int GetMaxStock()
        {
            return maxStock;
        }




        #endregion
    }
}
