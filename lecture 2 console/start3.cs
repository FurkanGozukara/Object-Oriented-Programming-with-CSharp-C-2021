using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture_2_console
{
    class start3
    {
        static void Main(string[] args)
        {
            memory_leak_example memoryTest = new memory_leak_example();
            memoryTest.noLeak();
           // memoryTest.memoryLeak();
        }
    }
}
