using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace lecture_5_inheritance
{
    class Program
    {

        //https://www.c-sharpcorner.com/blogs/difference-between-abstract-class-interfaces
        static void Main(string[] args)
        {
            ListCustom myList = new Program.ListCustom { "32.12", "11.23" };
            myList.printList();
            myList.convertToInteger();
            myList.printList();
        }

        public interface nestedFeatures1
        {
            public void nestedPrint();

        }

        public interface nestedFeatures2
        {
            public void nestedPrint2();

        }

        public abstract class commonFeaturesCars2
        {

            public int irFeatureId;
            public abstract class altFeatures
            {
                public abstract void printAlt();

            }
            public abstract void print2();

            public void print3()
            {
                Console.WriteLine("test");
            }
        }

        public abstract class commonFeaturesCars
        {

            public int irFeatureId;
            public abstract class altFeatures
            {
                public abstract void printAlt();
                
            }
            public abstract void print2();

            public void print3()
            {
                Console.WriteLine("test");
            }
        }

        public class cars : commonFeaturesCars, nestedFeatures1, nestedFeatures2
        {
            public void nestedPrint2()
            {
                this.lCarId = 32;
                this.irFeatureId = 12;
            }

            public void nestedPrint()
            {

            }


            public int irCarWeight_KG { get; set; }
            public enum CarColor
            {
                Blue = 1,
                Red = 2,
                Black = 3
            }

            public CarColor enCarColor;
            public string srCarBrand { get; set; }
            private long lCarId;

            public virtual void print()
            {
                Console.WriteLine($"Car Weight: {this.irCarWeight_KG.ToString()} , Car Color: {enCarColor.ToString()} , Car Brand: {srCarBrand}");
                print3();
                irFeatureId = 12;
            }

            public override void print2()
            {

            }
        }

        public class trucks : cars
        {
            public void initTruck()
            {
                print();
            }

            public override void print()
            {
                this.enCarColor = CarColor.Black;
            }
        }

        public class ListCustom : List<object>
        {
            public void convertToInteger()
            {
                for (int i = 0; i < this.Count; i++)
                {
                    var gg = this[i].ToString();
                    var vrInt = (int)(Math.Floor( Convert.ToDouble(gg)));
                    this[i] = vrInt;
                   
                }
            }
            public void printList()
            {         
                foreach (var item in this.ToArray())
                {
                    Console.WriteLine(item);
                  
                }
            }

            public void Sort2()
            {

            }
        }
    }
}
