using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lecture_2_console
{
    public class memory_leak_example
    {
        private static string srBigData = File.ReadAllText("TextFile1.txt");

        public void noLeak()
        {
            //would be any memory leak here?
            for (int i = 0; i < int.MaxValue; i++)
            {
                bigData myData = new bigData();
            }
        }

        public void memoryLeak()
        {
            List<bigData> myList = new List<bigData>();
            //would be any memory leak here?
            for (int i = 0; i < int.MaxValue; i++)
            {
                bigData myData = new bigData();
                myList.Add(myData);
                long memory = GC.GetTotalMemory(true);
                Console.WriteLine(memory);
                System.Threading.Thread.Sleep(100);
            }
        }

        public class bigData
        {
            public string srData = srBigData + new Random().Next();
        }
    }
}
