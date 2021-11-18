using System;
using System.Collections;
using System.Collections.Generic;
using static lecture_6_console.mathOps;

namespace lecture_6_console
{
    public static class csExtensions
    {
        //write an extension to test class that does print (test name + test name + square of test size)

        public static void printSpecial(this Program.test _myTest)
        {
            Console.WriteLine($"{_myTest.srTestName} + {_myTest.srTestName} + {Math.Pow(_myTest.irTestSize, 2)}");
        }
    }


    public class Program
    {
        private static int _MyProperty;//field
        public static int MyProperty
        {
            get { return _MyProperty + 100; }

            set { _MyProperty = value / 10; }

        }//property

        private static int _irUserAge;//field

        public static int irUserAge
        {
            get { return _irUserAge; }

            set
            {

                if (value > 150)
                    _irUserAge = 150;

                if (value < 0)
                    _irUserAge = 0;
            }

        }//property

        public class test
        {
            public int irTestSize { get; set; }
            public string srTestName;

            public test()//singature empty
            {
                srTestName = "default test";
                irTestSize = 100;
            }

            public test(int irAdd5, int irAdd = 55, int irAdd2 = 100, int irAdd3 = 150)//signature
            {
                srTestName = "default test 2";
                irTestSize = 100 + irAdd + irAdd2 + irAdd3;
            }

            public test(int irAdd)//signature
            {
                srTestName = "default test 2";
                irTestSize = 100 + irAdd;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! this is my property value= " + MyProperty);
            MyProperty = 50;
            Console.WriteLine("Hello World! this is my property value= " + MyProperty);
            irUserAge = 200;
            Console.WriteLine("age " + irUserAge);
            irUserAge = -6;
            Console.WriteLine("age " + irUserAge);

            test _test1 = new test();
            Console.WriteLine($"test name: {_test1.srTestName} , test size: {_test1.irTestSize}");
            _test1 = new test(20);
            Console.WriteLine($"test name: {_test1.srTestName} , test size: {_test1.irTestSize}");

            _test1 = new test { srTestName = "test 55", irTestSize = 55 };
            Console.WriteLine($"test name: {_test1.srTestName} , test size: {_test1.irTestSize}");
            _test1 = new test(100, irAdd: 200, irAdd3: 300);
            Console.WriteLine($"test name: {_test1.srTestName} , test size: {_test1.irTestSize}");
            _test1.irTestSize = 300;
            _test1.printSpecial();

            Console.WriteLine(new mathOps().sumNumbers(3,2,1,14,15,15,16));

            Console.WriteLine(sumNumbers2(3, 2, 1, 14, 15, 15, 16));
        }
    }
}
