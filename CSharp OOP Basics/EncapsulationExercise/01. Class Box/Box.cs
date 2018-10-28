using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Class_Box
{
    class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return length; }
            set { length = value; }
        }
        
        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double Area(double lenght, double width, double height)
        {
            // Surface Area = 2lw + 2lh + 2wh 

            var result = 2 * lenght * width + 2 * lenght * height + 2 * width * height;
            return result;
        }

        internal object LateralSurfaceArea(double length, double width, double height)
        {
            // Lateral Surface Area = 2lh + 2wh

            var result = 2 * length * height + 2 * width * height;
            return result;
        }

        internal object Volume(double length, double width, double height)
        {
            //Volume = lwh

            var result = length * width * height;
            return result;
        }

    }
}
