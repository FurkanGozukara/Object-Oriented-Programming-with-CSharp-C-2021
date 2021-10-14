using System;
using lecture_2_console;

namespace lecture_2_console_dll_ex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            propFieldExample propEx = new propFieldExample(100);//new = initizalizing an instance of class
            Console.WriteLine(propEx.irField_1);// prints 100 
            Console.WriteLine(propEx.irProp_1);// prints 100
            Console.WriteLine(propEx.irProp_2);// prints 100
            Console.WriteLine(propEx.irProp_3);// prints 10000 // private value = 100
            Console.WriteLine(propEx.irProp_4);// prints 50 // private value = 50 
            Console.WriteLine(propEx.returnSumofPrivateValues());// prints 250
            //Console.WriteLine(propEx.returnSumofPrivateValues_protected());//cant access since it is similar to private
            //Console.WriteLine(propEx.returnSumofPrivateValues_internal());// cant access since  Internal types or members are accessible only within files in the same assembly.
        }
    }
}
