using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.HandleTimerEvent
{
    class HandleTimerEvent
    {
        static void Main()
        {
            Timer timer = new Timer(6, 500);

            timer.TimeElapsed += new TimeElapsedEventHandler(Timer.TimerTimeElapsed);

            timer.Start();
        }
    }
}
