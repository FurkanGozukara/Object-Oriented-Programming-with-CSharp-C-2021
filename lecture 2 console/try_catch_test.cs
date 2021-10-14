using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture_2_console
{
    public static class try_catch_test
    {
        static Dictionary<int, int> dicNumbers = new Dictionary<int, int>();
        public static void tryCatchTest()
        {
            Stopwatch sw1 = new Stopwatch();

            sw1.Start();
            for (int i = 0; i < 10000; i++)
            {
                try
                {
                    int irNum = new Random().Next(1, 100);
                    dicNumbers.Add(irNum, irNum);
                }
                catch
                {


                }
            }
            sw1.Stop();

            Console.WriteLine("try catch duration: " + sw1.ElapsedMilliseconds + " ms");

            dicNumbers = new Dictionary<int, int>();
            sw1.Restart();
            for (int i = 0; i < 10000; i++)
            {
                int irNum = new Random().Next(1, 100);
                if (dicNumbers.ContainsKey(irNum) == false)
                {
                    dicNumbers.Add(irNum, irNum);
                }
            }
            sw1.Stop();
            Console.WriteLine("try catch duration: " + sw1.ElapsedMilliseconds + " ms");

            string testString = "lkdmflkasdmflkamdslfmdlsmfladsmfldsmflmdslkagjdslkjfldskfmkldsmflkdsamfldsmflkadsmfkldsjflmdslkfkmdsklagjadlkgldskmglkkasdmglkdsmflkdmslkajglskglkdsms";

            sw1.Restart();
            string srBigString = "";
            for (int i = 0; i < 10000; i++)
            {
                srBigString = srBigString + testString;// since string class immutable it generates a new string object each time, it does not append to the previous string therefore it is too slow
            }
            sw1.Stop();
            Console.WriteLine("string concatenation duration : " + sw1.ElapsedMilliseconds + " ms");

            StringBuilder srBuilder = new StringBuilder();
            sw1.Restart();
            for (int i = 0; i < 10000; i++)
            {
                srBuilder.Append(testString);
            }
            srBigString = srBuilder.ToString();
            sw1.Stop();
            Console.WriteLine("stringbuilder concatenation duration : " + sw1.ElapsedMilliseconds + " ms");

        }
    }
}
