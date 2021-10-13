
using System;
using System.Collections.Generic;
using ext1;
using ext2;

namespace lecture_1_console
{
    class Program
    {
        static void Main(string[] args)
        {
         //   Console myConsole = new Console();
            Console.WriteLine("Hello World!",3,""); // string
            Class2 testclass2 = new Class2();

            Console.WriteLine(32);

            Console.WriteLine("a", (int)32.1, null);

            HashSet<int> hsTest = new HashSet<int>();

            Console.WriteLine(ext1.org_random_generator.returnRandomNumber());
            Console.WriteLine(ext2.org_random_generator.returnRandomNumber());

            Random myRand = new Random();

            for (int i = 0; i < 10000; i++)
            {
                hsTest.Add(myRand.Next(1,10));//maximum is exclusive and minimum is inclusive
            }

            System.Console.WriteLine(string.Join(" , ", hsTest));
        }
    }
    
  public static  class Console
    {
        public static  void WriteLine(string srMsg,int irTest, string srMsg2)// signature : string + int + string
        {

        }

        public static void WriteLine(double dbl)// signature : double
        {

        }

        public static void WriteLine(int ir1,int ir2)// signature : double
        {

        }
    }
}
