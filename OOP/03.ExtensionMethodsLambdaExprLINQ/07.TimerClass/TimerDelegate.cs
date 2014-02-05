using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07.TimerClass
{
    //07.Using delegates write a class Timer that has can execute certain method at each t seconds.

    public delegate void TimerDelegate();

    public class Timer
    {
        public Timer(TimerDelegate methodToCall, int numberOfProccesses, int interval)
        {
            this.MethodToCall = methodToCall;
            this.NumberOfProccesses = numberOfProccesses;
            this.Interval = interval;
        }

        public int NumberOfProccesses { get; set; }
        public int Interval { get; set; }
        public TimerDelegate MethodToCall { get; set; }

        public void Start()
        {
            int numberOfProccesses = this.NumberOfProccesses;

            for (int tick = 0; tick < numberOfProccesses; tick++)
            {
                Thread.Sleep(this.Interval);
                this.MethodToCall();
            }
        }
    }
}
