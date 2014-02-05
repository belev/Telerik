using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07.TimerClass
{
    //07.Using delegates write a class Timer that has can execute certain method at each t seconds.

    class TimerClass
    {
        public static void PrintText()
        {
            Console.WriteLine("Hello, friend!");
        }
        static void Main()
        {
            Timer timer = new Timer(PrintText, 6, 400);
            timer.Start();
        }
    }
}
