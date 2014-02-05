using System;
using System.Collections.Generic;
using System.Text;
using GSMProject;

namespace CallHistoryTest
{
    public class CallHistoryTest
    {
        //12.Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
        //-Create an instance of the GSM class.
        //-Add few calls.
        //-Display the information about the calls.
        //-Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
        //-Remove the longest call from the history and calculate the total price again.
        //-Finally clear the call history and print it.

        static void Main()
        {
            const decimal callPerMinutePrice = 0.37M;

            GSM phone = new GSM("Galaxy S2", "Samsung", 450, "Gogo", new Battery("A1920", BatteryType.LiIon), new Display(3.2M, 100000UL));
            phone.AddCall(new Call("29.02.2012", "10:10:10", "0845333444", 60));
            phone.AddCall(new Call("15.12.2013", "12:00:00", "0879123456", 480));
            phone.AddCall(new Call("20.07.2011", "15:00:00", "0863123456", 960));

            //print every call information
            foreach (Call call in phone.CallHistory)
            {
                Console.WriteLine(call.ToString());
                Console.WriteLine();
            }

            decimal phoneCallsPrice = phone.CalculateCallsPrice(callPerMinutePrice);
            Console.WriteLine("Total cost of all calls: {0}", phoneCallsPrice);
            Console.WriteLine();

            phone.DeleteCall(2);

            phoneCallsPrice = phone.CalculateCallsPrice(callPerMinutePrice);
            Console.WriteLine("Total cost of all calls after deleted the longest call: {0}", phoneCallsPrice);
            Console.WriteLine();

            //after the deleted call
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var call in phone.CallHistory)
            {
                Console.WriteLine(call.ToString());
                Console.WriteLine();
            }

            phone.ClearCallHistory();
            //try to print calls, but history is deleted
            //there is no calls in the call history and nothing happens
            foreach (var call in phone.CallHistory)
            {
                Console.WriteLine(call.ToString());
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
