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

        #region constructor
        public Book(string print, string iSBN, int minStock, int maxStock, string title, string author, int weight, decimal price, Language language, Measurement measurement) : base(title, author, weight, price, language, measurement)
        {

        }
        #endregion

        #region propperties
        public string Print { get => print; set => print = value; }
        public string ISBN { get => iSBN; set => iSBN = value; }
        public int MinStock { get => minStock; set => minStock = value; }
        public int MaxStock { get => maxStock; set => maxStock = value; }
        public int Stock { get => stock; set => stock = value; }
        public string OrderRule { get => orderRule;}
        #endregion

        #region methodes
        public override string PrintAttributes()
        {
            return Attributes();
        }
        
        public string Attributes()
        {
            return "druk : " + Print + "\n" +
            "ISBN : " + ISBN + "\n" +
            "Minimale voorraad : " + MinStock + "\n" +
            "Maximum voorraad : " + MaxStock + "\n" +
            "Titel : " + Title + "\n";
        }

        public override string PrintOrderRule()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
