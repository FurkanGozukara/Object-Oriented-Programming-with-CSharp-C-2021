using System;

namespace lecture_5_variable_types
{
    class Program
    {
        //value types : https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types#value-types
        static void Main(string[] args)
        {
            int ir1 = 2;
            int ir2 = ir1;//whenever you make an assigment of value types it makes a new instance / deep clone
            Console.WriteLine($"ir1: {ir1}, ir2: {ir2}");//expected  2 2
            ir1 = 4;
            Console.WriteLine($"ir1: {ir1}, ir2: {ir2}");//expected  4 2
            ir2 = 5;
            Console.WriteLine($"ir1: {ir1}, ir2: {ir2}");//expected  4 5

            csEx1 _ex1 = new csEx1();
            _ex1.irEx1 = 100;
            _ex1.irEx2 = 250;
            Console.WriteLine($" _ex1.irEx1: { _ex1.irEx1},  _ex1.irEx2: { _ex1.irEx2}");//expected 100 250
                                                                                         //
            csEx1 _ex2 = _ex1;

            Console.WriteLine($" _ex1.irEx1: { _ex1.irEx1},  _ex1.irEx2: { _ex1.irEx2}, _ex2.irEx1: {_ex2.irEx1}, _ex2.irEx2: {_ex2.irEx2}");//expected 100 250 100 250  

            _ex2.irEx1 = 300;
            _ex2.irEx2 = 450;

            Console.WriteLine($" _ex1.irEx1: { _ex1.irEx1},  _ex1.irEx2: { _ex1.irEx2}, _ex2.irEx1: {_ex2.irEx1}, _ex2.irEx2: {_ex2.irEx2}");//expected  300 450 300 450

            changeVal(ir1);
            Console.WriteLine($"ir1: {ir1}, ir2: {ir2}");//expected 4 5 

            changeVal(ref ir1);
            Console.WriteLine($"ir1: {ir1}, ir2: {ir2}");//expected  8 5

            changeVal2(_ex1, _ex2);
            Console.WriteLine($" _ex1.irEx1: { _ex1.irEx1},  _ex1.irEx2: { _ex1.irEx2}, _ex2.irEx1: {_ex2.irEx1}, _ex2.irEx2: {_ex2.irEx2}");//expected //???
        }

        private static void changeVal2(csEx1 _ex1, csEx1 _ex2)
        {
            _ex1.irEx1 = 500;
            _ex2 = new csEx1();
            _ex2.irEx2 = 500;
        }

        private static void changeVal(int _irVal)
        {
            _irVal = _irVal * 2;             
        }

        private static void changeVal(ref int _irVal)
        {
            _irVal = _irVal * 2;
        }

        public class csEx1
        {
            public int irEx1;
            public int irEx2 { get; set; }
        }


    }
}
