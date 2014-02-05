using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.InvalidRangeException
{
    //03.Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range.
    //It should hold error message and a range definition [start … end].
    //Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime>
    //by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].

    class Tester
    {
        static void TestWithInt()
        {
            const int minValue = 1;
            const int maxValue = 100;

            try
            {
                Console.Write("Enter number: ");
                int number = int.Parse(Console.ReadLine());

                if (number < minValue || number > maxValue)
                {
                    throw new InvalidRangeException<int>("Number is out of range! Check out the range of available numbers!", minValue, maxValue);
                }

                Console.WriteLine("Successfully entered number. Number was in range!");
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Range: [{0} ... {1}]", e.Start, e.End);
            }
        }

        static void TestWithDate()
        {
            DateTime startDate = new DateTime(1980, 1, 1);
            DateTime endDate = new DateTime(2013, 12, 31);

            try
            {
                Console.Write("Enter date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                if ((date.CompareTo(startDate)) < 0 || (date.CompareTo(endDate) > 0))
                {
                    throw new InvalidRangeException<DateTime>("Date is out of range! Check out the range of available dates!", startDate, endDate);
                }

                Console.WriteLine("Successfully entered date. Date was in range!");
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Range: [{0} ... {1}]", e.Start.ToShortDateString(), e.End.Date.ToShortDateString());
            }
        }
        static void Main(string[] args)
        {
            TestWithInt();
            TestWithDate();
        }
    }
}
