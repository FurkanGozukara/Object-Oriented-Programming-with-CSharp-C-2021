using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ext1
{
    public static class org_random_generator
    {
        public static int returnRandomNumber()
        {
            return new Random().Next();
        }
    }
}
