using System;
using static lecture_9_cmd.multi_level_inheritance;

namespace lecture_9_cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var sq = new Square(12);
            Console.WriteLine($"Area of the square = {sq.GetArea()}");
            Console.WriteLine($"Area of the square2 = {sq.testarea()}");
            Console.WriteLine($"Instance ir test = {sq.irTest}");

            var o = new DerivedClass();
            Console.WriteLine($"x = {o.X}, y = {o.Y}");
            o.AbstractMethod();
            Console.WriteLine($"x = {o.X}, y = {o.Y}");

            Dog dogex = new Dog();
            dogex.animalSound();
            dogex.sound2();
            dogex.MyProperty = 32;
            Console.WriteLine($"property {  dogex.MyProperty}");

            Console.Clear();

            Drawing circle = new Circle();
            Console.WriteLine("base is drawing, class is circle Area :" + circle.Area());//this runs the area method of circle class since it is overriden
            Console.WriteLine("base is drawing, class is circle Area2 :" + circle.Area2());//this runs the area2 method of base drawing class
            //what these prints

            Circle circle2 = new Circle();
            Console.WriteLine("base is circle, class is circle Area :" + circle2.Area());//this runs area of circle
            Console.WriteLine("base is Circle, class is circle Area2 :" + circle2.Area2());//this runs area2 of circle
                                                                                           //what these prints

            Circle circle3 = new Circle2();
            Console.WriteLine("base is circle, class is Circle2 Area :" + circle3.Area());//this runs area of circle
            Console.WriteLine("base is Circle, class is Circle2 Area2 :" + circle3.Area2());//this runs area2 of circle
            //what these prints

            GFG exgfg = new GFG();
            exgfg.execute();
        }

        abstract class Shape
        {
            public Shape()
            {
                irTest = irTest * irTest;
            }

            public abstract int GetArea();
            public int testarea()
            {
                return 1;
            }

            public abstract int GetArea2();

            public int irTest = 32;
        }

        class Square : Shape
        {
            private int _side;

            public Square(int n) => _side = n;


            // GetArea method is required to avoid a compile-time error.
            public override int GetArea() => _side * _side;

            public override int GetArea2() => _side * _side * _side;



        }
        // Output: Area of the square = 144


        abstract class BaseClass
        {
            protected int _x = 100;
            protected int _y = 150;

            // Abstract method
            public abstract void AbstractMethod();

            // Abstract properties
            public abstract int X { get; }
            public abstract int Y { get; }
        }

        class DerivedClass : BaseClass
        {
            public override void AbstractMethod()
            {
                _x++;
                _y++;
            }

            public override int X   // overriding property
            {
                get
                {
                    return _x + 10;
                }
            }

            public override int Y   // overriding property
            {
                get
                {
                    return _y + 10;
                }
            }
        }

        // Interface
        interface IAnimal
        {
            void animalSound(); // interface method (does not have a body)

            public void sound2()
            {
                Console.WriteLine("The cat says: meow");
            }

            void sound3();

            public int MyProperty { get; }
        }

        // Dog "implements" the IAnimal interface
        class Dog : IAnimal
        {
            public void animalSound()
            {
                // The body of animalSound() is provided here
                Console.WriteLine("The dog says: bark bark");
            }

            public void sound3()
            {
                // The body of animalSound() is provided here
                Console.WriteLine("The cat says: meow meow");
            }

            public void sound2()
            {
                // The body of animalSound() is provided here
                Console.WriteLine("The bird says: gak gak");
            }
            public int MyProperty { get; set; }

        }

        interface IFirstInterface
        {
            void myMethod(); // interface method
        }

        interface ISecondInterface : IFirstInterface
        {
            void myOtherMethod(); // interface method
        }

        // Implement multiple interfaces
        class DemoClass : Dog, IFirstInterface, ISecondInterface
        {
            public void myMethod()
            {
                Console.WriteLine("Some text..");
            }
            public void myOtherMethod()
            {
                Console.WriteLine("Some other text...");
            }
        }

        public class TestData
        {
            //Static or Compile Time Polymorphism 
            public int Add(int a, int b, int c)
            {
                return a + b + c;
            }
            public int Add(int a, int b)
            {
                return a + b;
            }
        }


        //Dynamic / Runtime Polymorphism
        public class Drawing //concrete class
        {
            public virtual double Area()//this method can be overrriden by derived class
            {
                return 0;
            }
            public double Area2()//this method can be overrriden by derived class
            {
                return 2;
            }
        }

        public class Circle : Drawing //circle is derived class of drawing - inherating drawing class
        {
            public double Radius { get; set; }//property
            public Circle()//constructor
            {
                Radius = 5;
            }
            public override double Area()//overriding the parent class virtual method
            {
                return (3.14) * Math.Pow(Radius, 2);
            }

            public new double Area2()//method hiding
            {
                return (3.14) * Math.Pow(Radius, 2) * 2;
            }

            public void printCircle()
            {
                Console.WriteLine("circle");
            }
        }

        public class Circle2 : Circle //circle is derived class of drawing - inherating drawing class
        {
            public double Radius { get; set; }//property
            public Circle2()//constructor
            {
                Radius = 50;
            }
            public override double Area()//overriding the parent class virtual method
            {
                return (3.14) * Math.Pow(Radius, 2);
            }

            public new double Area2()//method hiding
            {
                return (3.14) * Math.Pow(Radius, 2) * 2;
            }

            public void printCircle()
            {
                Console.WriteLine("circle2");
            }
        }

        public class Square2 : Drawing
        {
            public double Length { get; set; }
            public Square2()
            {
                Length = 6;
            }
            public override double Area()
            {
                return Math.Pow(Length, 2);
            }

            public new double Area2()
            {
                return Math.Pow(Length, 2) * 2;
            }

            public void printSquare2()
            {
                Console.WriteLine("Square2");
            }
        }

        public class Rectangle : Drawing
        {
            public double Height { get; set; }
            public double Width { get; set; }
            public Rectangle()
            {
                Height = 5.3;
                Width = 3.4;
            }
            public override double Area()
            {
                return Height * Width;
            }

            public new double Area2()
            {
                return Height * Width * 2;
            }

            public void printRectangle()
            {
                Console.WriteLine("Rectangle");
            }
        }
    }
}
