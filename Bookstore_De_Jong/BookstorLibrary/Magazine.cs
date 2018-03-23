using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstorLibrary
{
    public enum DayOfWeak
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }
    public class Magazine : Product
    {
        private string iSSn;
        private int totalOrderMagazine;

        public Magazine(DayOfWeak dayOfRelease, DayOfWeak dayOfOrder, string iSSn, int totalOrderMagazine, string title, string author, int weight, decimal price, Language language, Measurement measurement): base(title, author, weight, price, language, measurement)
        {
        }

        public DayOfWeak DayOfRelease { get; set; }
        public DayOfWeak DayOfOrder { get; set; }
        public string ISSn { get => iSSn; set => iSSn = value; }
        public int TotalOrderMagazine { get => totalOrderMagazine; set => totalOrderMagazine = value; }

        public override string PrintAttributes()
        {
            throw new NotImplementedException();
        }

        public override string PrintOrderRule()
        {
            throw new NotImplementedException();
        }
    }
}
