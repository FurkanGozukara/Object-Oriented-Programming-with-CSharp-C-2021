using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture_2_console
{
    class Start2
    {
        static void Main(string[] args)
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
        }
    }
}
