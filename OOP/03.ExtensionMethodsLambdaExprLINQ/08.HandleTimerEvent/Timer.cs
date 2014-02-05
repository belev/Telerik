using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _08.HandleTimerEvent
{
    public class Timer
    {
        public event TimeElapsedEventHandler TimeElapsed;
        private int ticksCount;
        private int interval;

        public Timer(int ticksCount, int interval)
        {
            this.ticksCount = ticksCount;
            this.interval = interval;
        }

        public int TicksCount { get { return this.ticksCount; } }
        public int Interval { get { return this.interval; } }

        private void OnTimeElapsed(int ticksLeft)
        {
            if (this.TimeElapsed != null)
            {
                TimeElapsedEventArgs e = new TimeElapsedEventArgs(ticksLeft);
                TimeElapsed(this, e);
            }
        }

        public void Start()
        {
            int ticksLeft = this.ticksCount;

            while (ticksLeft > 0)
            {
                Thread.Sleep(this.interval);
                ticksLeft--;
                OnTimeElapsed(ticksLeft);
            }
        }

        public static void TimerTimeElapsed(object sender, TimeElapsedEventArgs e)
        {
            Console.WriteLine("Inside timer tick! Time elapsed! Ticks left: {0}.", e.TicksLeft);
        }
    }
}
