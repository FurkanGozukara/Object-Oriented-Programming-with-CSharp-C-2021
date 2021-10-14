using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lecture_2_console.try_catch_test;

namespace lecture_2_console
{
    class Start2 
    {
        static void Main2(string[] args)
        {

            Console.WriteLine("Hello World!");
            //  Console.WriteLine(accessor.irNumber1); this would cause an error because the program class constructor never executed since a static method can be called without instatiating its non static class object

            //since myTest is under same namespace lecture_2_console and it is public we can access it here
            Console.WriteLine(myTest.returnTest());

            List<myTest> testList = new List<myTest>();

            for (int i = 0; i < 100; i++)
            {
                myTest testobj = new myTest(new Random().Next());
                Console.WriteLine(myTest.irTest2);
                testList.Add(testobj);
            }

            student st1 = new student();
            st1.irStudentNumber = 32;
            st1.srStudentName = "student 1";
            Console.WriteLine(st1.returnStudentProperties());

            student st2 = new student { irStudentNumber = 90, srStudentName = "student 2" };
            Console.WriteLine(st2.returnStudentProperties());

            student2 st3 = new student2 { irStudentNumber = 110, srStudentName = "student 3" };
            Console.WriteLine(student2.returnStudentProperties(st3));

            Console.Clear();

            propFieldExample propEx = new propFieldExample(100);//new = initizalizing an instance of class
            Console.WriteLine(propEx.irField_1);// prints 100 
            Console.WriteLine(propEx.irProp_1);// prints 100
            Console.WriteLine(propEx.irProp_2);// prints 100
            Console.WriteLine(propEx.irProp_3);// prints 10000 // private value = 100
            Console.WriteLine(propEx.irProp_4);// prints 50 // private value = 50 
            Console.WriteLine(propEx.returnSumofPrivateValues());// prints 250
           // Console.WriteLine(propEx.returnSumofPrivateValues_protected());// cant access since it is like private 
            Console.WriteLine(propEx.returnSumofPrivateValues_internal());// prints 250

            Console.Clear();

            car car1 = new car { irDoorCount = 10, irWeight_KG = 2000, irWheelCount = 8 };
            //truck truck1 = new truck(car1);//this wont work
            truck truck2 = new truck { irDoorCount = 10, irWeight_KG = 2000, irWheelCount = 8 , carryWeight_KG = 50000 };
            car car2 = truck2;
            //truck truck3 = car1;//this wont work

            Console.WriteLine("printing car1 properties");
            car1.printProperties();
            Console.WriteLine("");
            Console.WriteLine("printing truck2 properties");
            truck2.printProperties();
            Console.WriteLine("");
            Console.WriteLine("printing car2 properties");
            car2.printProperties();
            car2.irWheelCount = 2;
            Console.WriteLine("");
            Console.WriteLine("printing truck2 properties");
            truck2.printProperties();
            car2.irWheelCount = 120;
            Console.WriteLine("");
            Console.WriteLine("printing truck2 properties");
            truck2.printProperties();

            Console.Clear();
            try_catch_test.tryCatchTest();
            tryCatchTest();
        }

        public class inherited_propEx : propFieldExample
        {
            public inherited_propEx(int irSecond) : base (irSecond)
            {
                this.returnSumofPrivateValues_protected();//protected means that only inherited classes can access and the class itself
                //it is similar to private but only difference is inherited classes can also access
                //this._irProp2//cant access because it is private and inherited class can not access it
            }
        }

        public class car
        {
         
            public int irDoorCount = 2;
            public int irWeight_KG = 1000;

            private int _irWheelCount; //private field

            public int irWheelCount   //public property
            {
                get { return _irWheelCount; }   // get method
                set {
                    if (value < 3)
                        value = 3;
                    if (value > 20)
                        value = 20;
                    
                    _irWheelCount = value; }  // set method
            }

            public void printProperties()
            {
                Console.WriteLine(returnBaseFeatures());
            }

            protected  string returnBaseFeatures()
            {
                return $"wheel count: {this.irWheelCount} - door count: {irDoorCount} - weight: {irWeight_KG}";
            }
        }

        public class truck : car
        {
            public int carryWeight_KG = 10000;
            new public void printProperties()
            {
                Console.WriteLine(returnBaseFeatures() + $" - carry weight: {carryWeight_KG}");
            }
        }
    }
}
