using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture_9_cmd
{
    class multi_level_inheritance
    {
        class Shape
        {

            double a_width;
            double a_length;

            // Default constructor
            public Shape()
            {
                Width = Length = 0.0;
            }

            // Constructor for Shape
            public Shape(double w, double l)
            {
                Width = w;
                Length = l;
            }

            // Construct an object with 
            // equal length and width
            public Shape(double y)
            {
                Width = Length = y;
            }

            // Properties for Length and Width
            public double Width
            {
                get
                {
                    return a_width;
                }

                set
                {
                    a_width = value < 0 ? -value : value;
                }
            }

            public double Length
            {
                get
                {
                    return a_length;
                }

                set
                {
                    a_length = value < 0 ? -value : value;
                }
            }
            public void DisplayDim()
            {
                Console.WriteLine("Width and Length are "
                             + Width + " and " + Length);
            }
        }

        // A derived class of Shape 
        // for the rectangle.
        class Rectangle : Shape
        {

            string Style;

            // A default constructor. 
            // This invokes the default
            // constructor of Shape.
            public Rectangle()
            {
                Style = "null";
            }

            // Constructor
            public Rectangle(string s, double w, double l)
                : base(w, l)
            {
                Style = s;
            }

            // Construct an square.
            public Rectangle(double y)
                : base(y)
            {
                Style = "square";
            }

            // Return area of rectangle.
            public double Area()
            {
                return Width * Length;
            }

            // Display a rectangle's style.
            public void DisplayStyle()
            {
                Console.WriteLine("Rectangle is  " + Style);
            }
        }

        // Inheriting Rectangle class
        class ColorRectangle : Rectangle
        {

            string rcolor;

            // Constructor
            public ColorRectangle(string c, string s,
                                  double w, double l)
                : base(s, w, l)
            {
                rcolor = c;
            }

            // Display the color.
            public void DisplayColor()
            {
                Console.WriteLine("Color is " + rcolor);
            }
        }

        // Driver Class
        public class GFG
        {

            // Main Method
            public void execute()
            {
                ColorRectangle r1 = new ColorRectangle("pink",
                           "Fibonacci rectangle", 2.0, 3.236);

                ColorRectangle r2 = new ColorRectangle("black",
                                           "Square", 4.0, 4.0);

                Console.WriteLine("Details of r1: ");
                r1.DisplayStyle();
                r1.DisplayDim();
                r1.DisplayColor();

                Console.WriteLine("Area is " + r1.Area());
                Console.WriteLine();

                Console.WriteLine("Details of r2: ");
                r2.DisplayStyle();
                r2.DisplayDim();
                r2.DisplayColor();

                Console.WriteLine("Area is " + r2.Area());
            }
        }
    }
}
