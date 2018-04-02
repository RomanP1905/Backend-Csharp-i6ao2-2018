using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstorLibrary
{
    public class Measurement
    {
        #region attribute
        private int lenght;
        private int height;
        private int width;
        #endregion

        #region constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="Measurement"/> class.
        /// </summary>
        public Measurement()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Measurement"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="lenght">The lenght.</param>
        public Measurement(int width, int height, int lenght)
        {
            this.lenght = lenght;
            this.height = height;
            this.width = width;
        }
        #endregion

        #region propperties
        public int Lenght { get => lenght; set => lenght = value; }
        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }
        #endregion
    }
}
