using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMProject
{
    //08.Create a class Call to hold a call performed through a GSM. It should contain date, time, dialed phone number and duration (in seconds).

    public class Call
    {
        public Call(string date, string time, string dialedPhoneNumber, uint durationInSeconds)
        {
            this.Date = date;
            this.Time = time;
            this.DialedPhoneNumber = dialedPhoneNumber;
            this.DurationInSeconds = durationInSeconds;
        }
        //automatic properties because haven't got validation
        public string Date { get; set; }
        public string Time { get; set; }
        public string DialedPhoneNumber {get; set;}
        public uint DurationInSeconds { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Call date: " + this.Date);
            result.AppendLine("Call time: " + this.Time);
            result.AppendLine("Call phone number: " + this.DialedPhoneNumber);
            result.AppendLine("Call duration in second: " + this.DurationInSeconds);

            return result.ToString();
        }
    }
}
