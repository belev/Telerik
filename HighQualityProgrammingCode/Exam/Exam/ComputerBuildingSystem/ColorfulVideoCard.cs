namespace ComputerBuildingSystem
{
    using System;

    public class ColorfulVideoCard : VideoCardBase
    {
        public override void DrawTextData(string data)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(data);
            Console.ResetColor();
        }
    }
}
