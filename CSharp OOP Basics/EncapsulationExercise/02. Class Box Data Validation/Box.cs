using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Class_Box_Data_Validation
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

        private double Length
        {

            get { return length; }
            set
            {
                if (value <= 0)
                {
                    ThrowExeption("Length");
                }

                this.length = value;
            }
        }

        private double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    ThrowExeption("Width");
                }

                this.width = value;
            }
        }

        private double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    ThrowExeption("Height");
                }

                this.height = value;
            }
        }

        public string Area()
        {
            // Surface Area = 2lw + 2lh + 2wh 

            var result = 2 * length * width + 2 * length * height + 2 * width * height;
            return $"Surface Area - {result:F2}";
        }

        public string LateralSurfaceArea()
        {
            // Lateral Surface Area = 2lh + 2wh

            var result = 2 * length * height + 2 * width * height;
            return $"Lateral Surface Area - {result:F2}";
        }

        public string Volume()
        {
            //Volume = lwh

            var result = length * width * height;
            return $"Volume - {result:F2}";
        }

        private void ThrowExeption(string name)
        {
            throw new ArgumentException($"{name} cannot be zero or negative.");
        }
    }
}
