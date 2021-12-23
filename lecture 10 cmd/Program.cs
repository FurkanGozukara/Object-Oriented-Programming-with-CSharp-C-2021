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
            //intObj.Add(1);
            //intObj.Add(2);
            //intObj.Add(3);     //No boxing
            //intObj.Add(4);
            //intObj.Add(5);
            //intObj.Add(6);

            intObj.addMultiParams(1, 2, 3, 4, 5, 6);

            intObj.printToScreen();

            TestClass<double> dblObj = new TestClass<double>();

            //dblObj.Add(1.32);
            //dblObj.Add(2.24);
            //dblObj.Add(3.44);     //No boxing
            //dblObj.Add(4.45);
            //dblObj.Add(5.567);
            //dblObj.Add(632.12);

            dblObj.addMultiParams(32.123, 4435.123, 4323.34, 43511.334, 3243.324, 12345.43, 234532.3234);

            dblObj.printToScreen();

            DataStore<Employee> myDataStore = new DataStore<Employee>();

            //DataStore<int> myintStore = new DataStore<int>();

            TestClass<int> intObj2 = new TestClass<int>();

            intObj2.addMultiParams(3, 4, 5, 6, 12, 14);

            if (intObj.CompareTo(intObj2))
            {
                Console.WriteLine("obj1 and obj2 are equal");
            }
            else
                Console.WriteLine("obj1 and obj2 are not equal");

            TestClass<int> intObj3 = new TestClass<int>();
            intObj3.addMultiParams(1, 2, 3, 4, 5, 6);

            if (intObj.CompareTo(intObj3))
            {
                Console.WriteLine("obj1 and obj3 are equal");
            }
            else
                Console.WriteLine("obj1 and obj3 are not equal");
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


        public class TestClass<T> where T : System.IComparable<T>
        {
            public bool CompareTo(TestClass<T> other)
            {
                bool blEqual = true;
                if (this.obj.Length == other.lenght)
                {
                    for (int i = 0; i < this.obj.Length; i++)
                    {
                        if (!this.obj[i].Equals(other[i]))
                        {
                            blEqual = false;
                        }
                    }
                    return blEqual;
                }
                return false;
            }

            public T MyProperty { get; set; }

            public T fieldT;

            public T returnValues()
            {
                return MyProperty;
            }

            public void addMultiParams(params T[] parameters)
            {
                foreach (var vrItem in parameters)
                {
                    Add(vrItem);
                }
            }

            public void printToScreen()
            {
                int irIndex = 0;
                while (true)
                {
                    if (irIndex >= obj.Length)
                        break;
                    Console.WriteLine(obj[irIndex]);
                    irIndex++;
                }
            }

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

        public class Employee
        {
            public Employee(string name, int id) => (Name, ID) = (name, id);
            public string Name { get; set; }
            public int ID { get; set; }
        }

        class DataStore<T> where T : class
        {
            public T Data { get; set; }
        }
    }
}
