﻿using BookstorLibrary;
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

        #region propperties
        public List<Product> Stocks { get; set; } = new List<Product>();
        public OrderItems ObjOrderItems { get; set; }
        public string ContactInfo { get => contactInfo; set => contactInfo = value; }
        public string BusinessHours { get => businessHours; set => businessHours = value; }
        #endregion
    }
}
