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

        public abstract int GetStock();

        public abstract void SellItem();

        public abstract string PrintOrderRule();

        public static List<Product> GetTestData()
        {

            List<Product> products = new List<Product>();

            products.Add(new Book("1986",
                "1234567891147",
                6,
                12,
                12,
                "Papi",
                "Bizzy",
                120,
                12.40m,
                Language.Dutch,
                new Measurement(20, 5, 5)
                ));

            products.Add(new Magazine(DayOfWeek.Tuesday, DayOfWeek.Monday, "1234-5678", 100, "Programming Magazine", 
                "Author", 50, 5.00m, Language.English, new Measurement(20, 10, 1)
            
                ));


            
            return products;
        }
        #endregion
    }
}
