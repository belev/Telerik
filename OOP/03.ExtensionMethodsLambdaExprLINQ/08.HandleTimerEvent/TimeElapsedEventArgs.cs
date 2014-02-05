using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.HandleTimerEvent
{
    //delegate to handle the event
    public delegate void TimeElapsedEventHandler(object sender, TimeElapsedEventArgs e);
    public class TimeElapsedEventArgs : EventArgs
    {
        private int ticksLeft;
        public int TicksLeft
        {
            get
            {
                return this.ticksLeft;
            }
        }
        public TimeElapsedEventArgs(int ticksLeft)
        {
            this.ticksLeft = ticksLeft;
        }
    }
}
