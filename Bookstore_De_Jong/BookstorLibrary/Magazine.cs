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
            this.TotalOrderMagazine = TotalOrderMagazine;
        }
        #endregion

        #region methodes
        public override string PrintAttributes()
        {
            return Title;
        }

        public override string PrintOrderRule()
        {
            return Convert.ToString(DayOfRelease);
        }

        public override string GetKey()
        {
            return ISSn;
        }

        public override int GetStock()
        {
            return TotalOrderMagazine;
        }

        public override void SellItem()
        {
            TotalOrderMagazine--;
        }
        #endregion
    }
}
