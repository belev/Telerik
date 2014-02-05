using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMProject
{
    public class Battery
    {
        private string model;
        private ushort? hoursIdle;
        private ushort? hoursTalk;
        private BatteryType? type;

        public Battery()
        {
            this.model = null;
            this.hoursIdle = null;
            this.hoursTalk = null;
            this.type = null;
        }

        public Battery(Battery battery)
        {
            this.Model = battery.Model;
            this.HoursIdle = battery.HoursIdle;
            this.HoursTalk = battery.HoursTalk;
            this.Type = battery.Type;
        }

        public Battery(string model)
        {
            this.Model = model;
        }

        public Battery(string model, ushort hoursIdle, ushort hoursTalk)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        public Battery(string model, BatteryType type)
        {
            this.Model = model;
            this.Type = type;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Haven't entered model, it is null or empty!");
                }
                this.model = value;
            }
        }

        public ushort? HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Hours idle can't be a negative number!");
                }
                this.hoursIdle = value;
            }
        }

        public ushort? HoursTalk
        {
            get { return this.hoursIdle; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Hours talk can't be a negative number!");
                }
                this.hoursTalk = value;
            }
        }

        public BatteryType? Type 
        {
            get { return this.type; }
            set
            {
                this.type = value;
            }
        }
    }
}
