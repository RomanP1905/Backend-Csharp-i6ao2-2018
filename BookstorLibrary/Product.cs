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
        Unknown
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

        public abstract string PrintOrderRule();

        public static List<Product> GetTestData()
        {
            List<Product> products = new List<Product>();

            products.Add(new Book("2017", "9789022580196", 5, 12, 3, "De verloren familie",
                "Jenna Blum", 585, 19.99m, Language.Dutch, new Measurement(141, 218, 40)
                ));

            products.Add(new Book("2018", "9789048840243", 10, 50, 15, "Gordon",
                "Marcel Langedijk", 374, 19.99m, Language.Dutch, new Measurement(134, 213, 25)
                ));

            products.Add(new Magazine(DayOfWeek.Wednesday, DayOfWeek.Tuesday, "1057-3534", 100, "LINDA", 
                "Linda", 170, 6.25m, Language.Dutch, new Measurement(190, 275, 20 )
            ));
           
            return products;
        }
        #endregion
    }
}
