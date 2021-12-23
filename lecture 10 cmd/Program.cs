using System;
using System.Collections;

namespace lecture_10_cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            object b = a; //boxing
            a = 25;
            Console.WriteLine("b : " + b);
            Console.WriteLine("a : " + a);
            b = 15;
            Console.WriteLine("b : " + b);
            Console.WriteLine("a : " + a);
            if (b.GetType() == typeof(int))
            {
                Console.WriteLine("b is int type");
            }
            if (b.GetType() == typeof(double))
            {
                Console.WriteLine("b is double type");
            }
            if (b.GetType() == typeof(Int64))
            {
                Console.WriteLine("b is int 64 type");
            }
            int c = (int)b; // unboxing

            Console.Clear();

            //instantiate generic with Integer
            TestClass<int> intObj = new TestClass<int>();

            //adding integer values into collection
            intObj.Add(1);
            intObj.Add(2);
            intObj.Add(3);     //No boxing
            intObj.Add(4);
            intObj.Add(5);
            intObj.Add(6);

            int irIndex = 0;
            while (true)
            {
                if (irIndex >= intObj.lenght)
                    break;
                    Console.WriteLine(intObj[irIndex]);
                irIndex++;
            }

            TestClass<double> dblObj = new TestClass<double>();

            dblObj.Add(1.32);
            dblObj.Add(2.24);
            dblObj.Add(3.44);     //No boxing
            dblObj.Add(4.45);
            dblObj.Add(5.567);
            dblObj.Add(632.12);

            irIndex = 0;
            while (true)
            {
                if (irIndex >= dblObj.lenght)
                    break;
                Console.WriteLine(dblObj[irIndex]);
                irIndex++;
            }


        }

        public sealed class cars
        {
            public int carWeight { get; set; }
        }

        public class trucks
        {
            public virtual void printTruckFeatures()
            {

            }
        }

        public class specialTrucks : trucks
        {
            public sealed override void printTruckFeatures()
            {

            }
        }



        //public class carBrands : cars - you cant derive from sealed class
        //{

        //}

        class X
        {
            protected virtual void F() { Console.WriteLine("X.F"); }
            protected virtual void F2() { Console.WriteLine("X.F2"); }
        }

        class Y : X
        {
            sealed protected override void F() { Console.WriteLine("Y.F"); }
            protected override void F2() { Console.WriteLine("Y.F2"); }
        }

        class Z : Y
        {
            // Attempting to override F causes compiler error CS0239.
            // protected override void F() { Console.WriteLine("Z.F"); }

            // Overriding F2 is allowed.
            protected override void F2() { Console.WriteLine("Z.F2"); }
        }


        public class TestClass<T>
        {
            // define an Array of Generic type with length 5
            T[] obj = new T[5];
            int count = 0;

            // adding items mechanism into generic type
            public void Add(T item)
            {
                //checking length
                if (count + 1 < 6)
                {
                    obj[count] = item;

                }
                count++;
            }
            //indexer for foreach statement iteration
            public T this[int index]
            {
                get { return obj[index]; }
                set { obj[index] = value; }
            }

            public int lenght { get { return obj.Length; } }
        }
    }
}
