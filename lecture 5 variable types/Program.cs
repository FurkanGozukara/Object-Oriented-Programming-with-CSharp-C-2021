using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine($" _ex1.irEx1: { _ex1.irEx1},  _ex1.irEx2: { _ex1.irEx2}, _ex2.irEx1: {_ex2.irEx1}, _ex2.irEx2: {_ex2.irEx2}");//expected // 500 450 500 450 

            changeVal2(ref _ex1, ref _ex2);
            Console.WriteLine($" _ex1.irEx1: { _ex1.irEx1},  _ex1.irEx2: { _ex1.irEx2}, _ex2.irEx1: {_ex2.irEx1}, _ex2.irEx2: {_ex2.irEx2}");//expected // 900 450  0 700 

            List<string> lst1 = new List<string>();
            lst1.Add("gg");
            Console.WriteLine($" lst1 = {string.Join(", ", lst1)}"); //gg
            changeList(lst1);
            Console.WriteLine($" lst1 = {string.Join(", ", lst1)}");// cc aa

            List<string> lst2 = lst1;//this will not clone your list
            Console.WriteLine($" lst2 = {string.Join(", ", lst2)}");// cc aa
            lst1.Add("hh");
            Console.WriteLine($" lst2 = {string.Join(", ", lst2)}");//  cc aa hh
            List<string> lst3 = lst1.ToList();//this will clone your list
            lst1.Add("kk"); // cc aa hh kk
            Console.WriteLine($" lst2 = {string.Join(", ", lst2)}");// cc aa hh kk
            Console.WriteLine($" lst3 = {string.Join(", ", lst3)}");// cc aa hh

            _ex1.irEx1 = 200;
            _ex1.irEx2 = 400;
            csEx1 ex3 = _ex1;//how to clone _ex1 into new instance of csEx1 - deep clone??
            _ex1.irEx2 = 300;
            Console.WriteLine($" ex3.irEx1: { ex3.irEx1},  ex3.irEx2: { ex3.irEx2}, _ex1.irEx1: {_ex1.irEx1}, _ex1.irEx2: {_ex1.irEx2}");//expected //  200 300 200 300


            _ex1.lstValues = new List<string> { "gg1", "aa1" };
            _ex1.lstValues2 = new List<string> { "gg1", "aa1" };

            csEx1 ex4 = new csEx1(_ex1);//??? 200 300

            _ex1.irEx2 = 500; // 200 500
            _ex1.lstValues[0] = "mm";
            _ex1.lstValues2[0] = "mm";

            ex4.irEx2 = 1000; // 200 1000
            ex4.lstValues.Add("cc");
            ex4.lstValues2.Add("cc");
            Console.WriteLine($" _ex1.irEx1: { _ex1.irEx1},  _ex1.irEx2: { _ex1.irEx2}, ex4.irEx1: {ex4.irEx1}, ex4.irEx2: {ex4.irEx2}");//expected // 200 500 200 1000
            Console.WriteLine($" _ex1.lstValues = {string.Join(", ", _ex1.lstValues)} \t ex4.lstValues {string.Join(", ", ex4.lstValues)}");// ?? mm aa1 cc , mm aa1 cc

            Console.WriteLine($" _ex1.lstValues2 = {string.Join(", ", _ex1.lstValues2)} \t ex4.lstValues2 {string.Join(", ", ex4.lstValues2)}");// mm aa1  , gg1 aa1 cc
        }



        private static void changeList(List<string> lst)
        {
            lst.Add("aa");// gg aa
            lst[0] = "cc";// cc aa
            lst = new List<string>();// empty
            lst.Add("bb");// bb
        }

        private static void changeVal2(ref csEx1 _ex1, ref csEx1 _ex2)
        {
            _ex1.irEx1 = 900;// 900 450
            _ex2 = new csEx1();//0 0
            _ex2.irEx2 = 700;// 0 700
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
            public List<string> lstValues = new List<string>();
            public List<string> lstValues2 = new List<string>();

            public csEx1() { }

            public csEx1(csEx1 _ex1)
            {
                this.irEx1 = _ex1.irEx1;
                this.irEx2 = _ex1.irEx2;
                this.lstValues = _ex1.lstValues;
                this.lstValues2 = _ex1.lstValues2.ToList();
            }

            public int irEx1;
            public int irEx2 { get; set; }
        }



    }
}
