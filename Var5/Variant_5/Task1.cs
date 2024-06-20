using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Variant_5
{
    public class Task1
    {
        public struct Rectangle
        {
            private readonly int a;
            private readonly int b;

            public Rectangle() : this(0, 0)
            {
            }

        
            public Rectangle(int a, int b)
            {
                this.a = a >= 0 ? a : 0; 
                this.b = b >= 0 ? b : 0; 
            }

            public int A
            {
                get { return a; }
            }

            public int B
            {
                get { return b; }
            }

            public int Length()
            {
                return 2 * (a + b);
            }

            public int Area()
            {
                return a * b;
            }


            public int Compare(Rectangle other)
            {
                int thisArea = this.Area();
                int otherArea = other.Area();

                if (thisArea > otherArea)
                {
                    return 1;
                }
                else if (thisArea < otherArea)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            public override string ToString()
            {
                return $"a = {a}, b = {b}, p = {Length()}, s = {Area()}";
            }
        }


        private Rectangle[] rectangles;

        public Rectangle[] Rectangles
        {
            get { return rectangles; }
        }

        public Task1(Rectangle[] rectangles)
        {
            this.rectangles = rectangles;
        }

        public override string ToString()
        {
            string result = "";
            foreach (Rectangle rectangle in rectangles)
            {
                result += rectangle.ToString() + "n";
            }
            return result; 
        }

        public void Sorting()
        {
            for (int i = 0; i < rectangles.Length - 1; i++)
            {
                for (int j = 0; j < rectangles.Length - i - 1; j++)
                {
                    if (rectangles[j].Length() > rectangles[j + 1].Length())
                    {
                        Rectangle temp = rectangles[j];
                        rectangles[j] = rectangles[j + 1];
                        rectangles[j + 1] = temp;
                    }
                }
            }
        }
    }
}
