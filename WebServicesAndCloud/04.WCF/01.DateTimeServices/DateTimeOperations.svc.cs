namespace DateTimeServices
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DateTimeOperations : IDateTimeOperations
    {
        public string GetDayOfWeekAsString(DateTime dateTime)
        {
            var bulgarianCulture = new CultureInfo("bg-BG");
            Thread.CurrentThread.CurrentCulture = bulgarianCulture;
            
            var dayOfWeek = dateTime.DayOfWeek;

            var dayOfWeekAsString = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dayOfWeek);
            return dayOfWeekAsString;
        }
    }
}