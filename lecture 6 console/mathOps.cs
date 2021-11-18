using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture_6_console
{
   class mathOps
    {
        public int sumNumbers(params int[] _params)
        {
            return _params.Sum();
        }

        public static int sumNumbers2(params int[] _params)
        {
            return _params.Sum()* _params.Sum();
        }
    }
}
