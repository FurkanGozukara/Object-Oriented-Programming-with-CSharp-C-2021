using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture_7
{
    public static class statictest
    {
        public static Dictionary<string, string> dicTest;
        static statictest()//2021112202
        {
            dicTest = new Dictionary<string, string>();
            for (int i = 0; i < 1000000; i++)
            {
                dicTest.Add(i.ToString(), "lkmasdlmaslkfmalkmflkasmflamfklasmlkfmaslfmlaksmflasmfas");
            }
        }
    }

    public class nonstaticclass
    {
        //2021112202
        public nonstaticclass (string sr)//sig str
        {

        }
        //2021112202
        public nonstaticclass(string sr, int ir)//sig str int
        {

        }
    }
}
