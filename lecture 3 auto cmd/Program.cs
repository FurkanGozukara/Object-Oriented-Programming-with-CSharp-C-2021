using System;
using System.Diagnostics;
using System.IO;

namespace lecture_3_auto_cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            string srCommand = @"cmd /k ""sum\\lecture 3.exe"" ";

            while(true)
            {
                Console.WriteLine("please enter parameters to calculate");
                var vrParams = Console.ReadLine();
                File.WriteAllText("sum.cmd", srCommand + vrParams, System.Text.Encoding.Default);
                var p = new Process();
                p.StartInfo.FileName = "sum.cmd";
                p.Start();
                p.WaitForExit();
            }
         
        }
    }
}
