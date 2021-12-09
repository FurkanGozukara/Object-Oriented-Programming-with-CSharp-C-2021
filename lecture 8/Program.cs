using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Runtime.Serialization;
using static lecture_8.myExtensions;

namespace lecture_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DataTable dt = new DataTable();
            dt.Columns.Add("col1");
            dt.Rows.Add("12");
            dt.Rows.Add("12a");
            Console.WriteLine(dt.Rows[0][0].converToDouble().formatmyDouble());
            Console.WriteLine(dt.Rows[1][0].converToDouble().formatmyDouble());

            colors mycolor = colors.Lime;

            Console.WriteLine($"pick your color and your options are: {mycolor.returnEnumOptions<colors>(", ")}");
            var vrUserColor = Console.ReadLine();
            var vrEnum = vrUserColor.ToEnum<colors>();
            switch (vrEnum)
            {
                case colors.White:
                case colors.Red:
                case colors.Lime:
                default:
                    Console.WriteLine($"you have entered {vrEnum.ToString()} color which has hex code: {vrEnum.GetEnumDescription()} , selected color order: {(int)(colors)vrEnum} ");
                    break;
            }

            cars myCar = cars.Golf;

            Console.WriteLine($"pick your car and your options are:\r\n{myCar.returnEnumOptions<cars>("\r\n")}");

            vrUserColor = Console.ReadLine();
            var vrEnum2 = vrUserColor.ToEnum<cars>();

            Console.WriteLine($"you have picked {vrEnum2.ToString()} car brand which is: {vrEnum2.GetEnumDescription()} , selected car order: {(int)(cars)vrEnum2} ");


        }
    }

    public static class myExtensions
    {
      public  enum eninvalid
        {
            [Description("#invalid")]
            YouHaveEnteredInvalidInput = -1
        }

        public enum colors
        {
            [Description("#FFFFFF")]
            White = 1,
            [Description("#FF0000")]
            Red = 2,
            [Description("#00FF00")]
            Lime = 3
        }

        public enum cars
        {
            [Description("Cheap")]
            Tofas = 1,
            [Description("Moderate")]
            Golf = 2,
            [Description("Expensive")]
            Mercedes = 3
        }


        public static double converToDouble(this object obj)
        {
            double myDouble = double.NaN;
            if (double.TryParse(obj.ToString(), out myDouble))
            {
                return myDouble;
            }
            return double.NaN;
        }

        public static string formatmyDouble(this double dblVal)
        {
            return dblVal.ToString("N2");
        }

        public static Enum ToEnum<T>(this string value, bool ignoreCase = true)
        {
            try
            {
                return (Enum)Enum.Parse(typeof(T), value, ignoreCase);
            }
            catch  
            {
                return eninvalid.YouHaveEnteredInvalidInput;
            }
        }

        public static string GetEnumDescription(this Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static string returnEnumOptions<T>(this T myEnum, string srJoinVal)
        {
            List<string> lstEnums = new List<string>();
            foreach (string name in Enum.GetNames(typeof(T)))
            {
                lstEnums.Add(name);
            }

            return string.Join(srJoinVal, lstEnums);
        }
    }
}
