using System;
using System.Linq;
using static lecture_3.extensions;

namespace lecture_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(extensions.sumNumbers(32, 10));
            Console.WriteLine(32.sumNumbers(10));

            Console.WriteLine(sumNumbers(12, 13, 13, 14, 15, 16));
            Console.WriteLine(sumNumbers_v3(12, 13, 13, 14, 15, 16));//params vs array

            Console.WriteLine(sumNumbers_v2(new int[] { 44, 50, 100 }));
            Console.WriteLine(sumNumbers_v3(new int[] { 44, 50, 100 }));

            Console.WriteLine("the sum of numbers you have provided is : "+ args?.sumParams());
        }

        //static int sumNumbers(int irNumber1, int irNumber2)
        //{
        //    return irNumber1 + irNumber2;
        //}
    }

    public static class extensions
    {
        public static double sumParams(this string [] srValues)
        {
            return srValues.Select(pr => pr.toDouble()).Sum();
        }

        public static double toDouble(this string srNumber)
        {
            double dblOut;
            if(double.TryParse(srNumber, out dblOut))
            {
                return dblOut;
            }

            return double.NaN;
        }

        public static int sumNumbers(this int irNumber1, int irNumber2)
        {
            return irNumber1 + irNumber2;
        }

        public static int sumNumbers(params int[] parameters)
        {
            return parameters.Sum();
        }

        public static int sumNumbers_v2(int[] parameters)
        {
            return parameters.Sum();
        }

        public static int sumNumbers_v3(params int[] parameters)
        {
            int irTest2 = 0;
            parameters.ToList().ForEach(pr => irTest2 += pr);
            //foreach (var item in parameters) same as above
            //{
            //    irTest2 += item;
            //}
            return irTest2;
        }
    }
}
