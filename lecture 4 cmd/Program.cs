using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;

namespace lecture_4_cmd
{
    class Program
    {
        static void Main(string[] args)
        {


            Stopwatch swTimer = new();
            swTimer.Start();
            using (StreamWriter swWriter = new StreamWriter("test1.txt"))
            {
                for (int i = 0; i < 10000000; i++)
                {
                    swWriter.WriteLine(i + " test");
                    if (i % 1000000 == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            swTimer.Stop();
            Console.Clear();
            Console.WriteLine("first operation took: " + swTimer.ElapsedMilliseconds + "ms");


            swTimer.Reset();
            swTimer.Start();
            using (StreamWriter swWriter = new StreamWriter("test1.txt"))
            {
                swWriter.AutoFlush = true;
                for (int i = 0; i < 10000000; i++)
                {
                    break;
                    swWriter.WriteLine(i + " test");
                    if (i % 1000000 == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            swTimer.Stop();
            Console.WriteLine("second operation took: " + swTimer.ElapsedMilliseconds + "ms");


            swTimer.Reset();
            swTimer.Start();
            using (StreamWriter swWriter = new StreamWriter("test1.txt"))
            {
                for (int i = 0; i < 10000000; i++)
                {
                    if (i % 1000 == 0)
                    {
                        swWriter.Flush();
                    }

                    swWriter.WriteLine(i + " test");
                    if (i % 1000000 == 0)
                    {
                        swWriter.Flush();
                        Console.WriteLine(i);
                    }
                }
            }
            swTimer.Stop();
            Console.WriteLine("third operation took: " + swTimer.ElapsedMilliseconds + "ms");

            swTimer.Reset();
            swTimer.Start();
            StringBuilder swBuild = new StringBuilder();

            for (int i = 0; i < 10000000; i++)
            {
                swBuild.AppendLine(i + " test");
                if (i % 1000000 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            File.WriteAllText("test2.txt", swBuild.ToString());

            swTimer.Stop();
            Console.WriteLine("fourth operation took: " + swTimer.ElapsedMilliseconds + "ms");


            swTimer.Reset();
            swTimer.Start();
            string srConcat = "";

            for (int i = 0; i < 10000000; i++)
            {
                break;
                srConcat += i + " test" + Environment.NewLine;//why this method is so slow
                if (i % 1000000 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            File.WriteAllText("test3.txt", srConcat);

            swTimer.Stop();
            Console.WriteLine("fifth operation took: " + swTimer.ElapsedMilliseconds + "ms");


            swTimer.Reset();
            swTimer.Start();

            for (int i = 0; i < 10000000; i++)
            {
                break;
                File.AppendAllText("test4.txt", i + " test" + Environment.NewLine);
                if (i % 1000000 == 0)
                {
                    Console.WriteLine(i);
                }
            }
            swTimer.Stop();
            Console.WriteLine("sixth operation took: " + swTimer.ElapsedMilliseconds + "ms");


            List<string> lststrings = new List<string>();

            swTimer.Reset();
            swTimer.Start();

            for (int i = 0; i < 10000000; i++)
            {
                lststrings.Add(i + " test");
                if (i % 1000000 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            lststrings.First(); //lststrings[0];
            lststrings.Sort();
            var vrNewList = lststrings.Where(pr => pr.Contains("000 test")).ToList();

            File.WriteAllLines("test7.txt", lststrings);

            swTimer.Stop();
            Console.WriteLine("seventh operation took: " + swTimer.ElapsedMilliseconds + "ms");


            lststrings = new List<string>(20000000);

            swTimer.Reset();
            swTimer.Start();

            for (int i = 0; i < 10000000; i++)
            {
                lststrings.Add(i + " test");
                if (i % 1000000 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            File.WriteAllLines("test8.txt", lststrings);

            swTimer.Stop();
            Console.WriteLine("eith operation took: " + swTimer.ElapsedMilliseconds + "ms");

            lststrings = new List<string>();

            string[] test = new string[10000001];
            swTimer.Reset();
            swTimer.Start();

            for (int i = 0; i < 10000000; i++)
            {
                test[i] = i + " test";
                if (i % 1000000 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            File.WriteAllLines("test9.txt", lststrings);

            swTimer.Stop();
            Console.WriteLine("test 9 operation took: " + swTimer.ElapsedMilliseconds + "ms");

            GC.Collect();
        }


    }
}
