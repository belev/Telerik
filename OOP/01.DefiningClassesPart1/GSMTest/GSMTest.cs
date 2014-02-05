using System;
using System.Collections.Generic;
using System.Text;
using GSMProject;

namespace GSMTest
{
    public class GSMTest
    {
        //07.Write a class GSMTest to test the GSM class:
        //-Create an array of few instances of the GSM class.
        //-Display the information about the GSMs in the array.
        //-Display the information about the static property IPhone4S.

        static void Main()
        {
            List<GSM> phones = new List<GSM>();

           phones.Add(new GSM("Galaxy S3", "Samsung", 700, "Peshkata", new Battery("A1906", BatteryType.NiCd), new Display(3.9M, 1000000UL)));

            phones.Add(GSM.IPhone4S);

            phones.Add(new GSM("Lumia", "Nokia", 1000, "Nikolina", new Battery("G2940", BatteryType.LiIon), new Display(5.0M, 4000000)));

            int count = 0;

            //print information about every phone in phones
            //change console color to be better seen
            foreach (GSM gsm in phones)
            {
                if (count % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                Console.WriteLine(gsm.ToString());
                count++;
            }
            Console.ResetColor();
        }
    }
}
