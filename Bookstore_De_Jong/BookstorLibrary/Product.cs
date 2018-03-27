using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstorLibrary
{
    #region enum
    public enum Language
    {
        Dutch,
        Spanish,
        English,
        German,
        French,
        Unknow
    }
    #endregion

    public abstract class Product
    {
        #region attributes
        private string title;
        private string author;
        private int weight;
        private decimal price;
        #endregion

        #region construtor
        protected Product(string title, string author, int weight, decimal price, Language language, Measurement measurement)
        {
            Title = title;
            Author = author;
            Weight = weight;
            Price = price;
            Language = language;
            Measurement = measurement;
        }
        #endregion

        #region properties
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public int Weight { get => weight; set => weight = value; }
        public decimal Price { get => price; set => price = value; }
        public Language Language { get; set; }
        public Measurement Measurement { get; set; }
        #endregion

        #region methodes
        public abstract string PrintAttributes();

        public abstract string GetKey();

        public abstract string GetTitle();

        public abstract int GetStock();

        public abstract void SellItem();

        public abstract string PrintOrderRule();

        public static List<Product> GetTestData()
        {
            List<Product> products = new List<Product>();

            products.Add(new Book("2017", "9789022580196", 5, 12, 2, "De verloren familie",
                "Jenna Blum", 585, 19.99m, Language.Dutch, new Measurement(40, 218, 141)
                ));

            products.Add(new Book("2018", "9789048840243", 10, 50, 3, "Gordon",
                "Marcel Langedijk", 374, 19.99m, Language.Dutch, new Measurement(25, 213, 134)
                ));

            products.Add(new Magazine(DayOfWeek.Wednesday, DayOfWeek.Tuesday, "1057-3534", 100, "LINDA", 
                "Linda", 170, 6.25m, Language.Dutch, new Measurement(230, 275, 190)
            ));
           
            return products;
        }
        #endregion
    }
}
