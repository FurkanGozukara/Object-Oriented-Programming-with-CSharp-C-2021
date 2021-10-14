using System;

namespace lecture_2_console
{
    class Program
    {
        public Program()
        {
            irNumber1 = 55;
            accessor = this;
        }

        public static Program accessor;

        static void Main2(string[] args)
        {

            Console.WriteLine("Hello World!");
            //  Console.WriteLine(accessor.irNumber1); this would cause an error because the program class constructor never executed since a static method can be called without instatiating its non static class object

            Console.WriteLine(myTest.returnTest());

            

        }

        int irNumber1;

    }

    public class myTest
    {
       public static int irTest2 = 11;
        public int irNonStaticVar;
        public myTest(int irInput)
        {
            irTest2 = irInput;
            irNonStaticVar = irInput;
        }

        public static int returnTest()
        {
            return irTest2;
        }
    }

    //public static class myTestStatic // static classes can not have instance members fields methods objects properties etc
    //{
    //    int irTest2 = 11;

    //    static int returnTest()
    //    {
    //        return irTest2;
    //    }
    //}
}
