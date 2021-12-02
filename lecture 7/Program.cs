using System;
using System.Collections.Generic;

namespace lecture_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //init();
            GC.Collect();//forces garbage collector to remove unreferenced objects
            useRam();
            Console.WriteLine("press a key to garbage collect");
            Console.ReadLine();
            GC.Collect();
            Console.ReadLine();

            Console.WriteLine(" garbage collected");
            Console.ReadLine();

            Console.WriteLine("click to regenerate dictionary");
            dicTest = new Dictionary<string, string>();
            Console.WriteLine("press a key to garbage collect");
            Console.ReadLine();
            GC.Collect();
            Console.ReadLine();

            Console.WriteLine(" garbage collected2");
            List<object> dicList = new List<object>();  
            while(true)
            {
               // dicList.Add(dicTest);
                useRam();
            }
        }
        static Dictionary<string, string> dicTest;
        private static void useRam()
        {
            dicTest = new Dictionary<string, string>();
            for (int i = 0; i <500000; i++)
            {
                dicTest.Add(i.ToString(), "lkmasdlmaslkfmalkmflkasmflamfklasmlkfmaslfmlaksmflasmfas"+i.ToString());
            }
        }

        static void init()
        {
            statictest.dicTest.ContainsKey("x");
        }
    }
}
