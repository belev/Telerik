namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        static Engine GetEngineInstance()
        {
            return new ExtendedEngine();
        }

        public static void Main()
        {
            Engine engine = GetEngineInstance();

            string command = Console.ReadLine();
            while (command != "end")
            {
                engine.ExecuteCommand(command);
                command = Console.ReadLine();
            }
            Console.WriteLine(Engine.result.ToString().TrimEnd());
        }
    }
}
