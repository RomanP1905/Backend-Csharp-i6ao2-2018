using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstorLibrary
{
    public class Measurement
    {
        private int lenght;
        private int height;
        private int width;

        public Measurement()
        {
        }

        public Measurement(int lenght, int height, int width)
        {
            this.lenght = lenght;
            this.height = height;
            this.width = width;
        }

        public int Lenght { get => lenght; set => lenght = value; }
        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }
    }
}
