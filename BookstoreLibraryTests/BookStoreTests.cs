using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreLibrary.Tests
{
    [TestClass()]
    public class BookStoreTests
    {
        [TestMethod()]
        public void RemoveBookFromStockByISBNTest()
        {
            List<BookstorLibrary.Product> products = new List<BookstorLibrary.Product>();

            products.Add(new BookstorLibrary.Book("2017", "9789022580196", 5, 12, 3, "De verloren familie",
                "Jenna Blum", 585, 19.99m, BookstorLibrary.Language.Dutch, new BookstorLibrary.Measurement(141, 218, 40)
                ));
            products.Add(new BookstorLibrary.Book("2018", "9789048840243", 10, 50, 15, "Gordon",
                "Marcel Langedijk", 374, 19.99m, BookstorLibrary.Language.Dutch, new BookstorLibrary.Measurement(134, 213, 25)
                ));

            products.Add(new BookstorLibrary.Magazine(BookstorLibrary.DayOfWeek.Wednesday, BookstorLibrary.DayOfWeek.Tuesday, "1057-3534", 100, "LINDA",
                "Linda", 170, 6.25m, BookstorLibrary.Language.Dutch, new BookstorLibrary.Measurement(190, 275, 20)
            ));



            BookStore hengelo = new BookStore();
            hengelo.Stocks = products;
            hengelo.BusinessHours = "Mo-Vr 8:00 - 15:00";
            hengelo.ContactInfo = "Find me on my website: www.bookstore-hengelo.nl";
            List<BookstorLibrary.Product> actual = hengelo.Stocks;

            BookStore.RemoveBookFromStockByISBN("9789048840243", hengelo.Stocks);

            List<BookstorLibrary.Product> productsExpected = hengelo.Stocks;

            CollectionAssert.AreEqual(productsExpected, actual);
        }
    }
}