namespace ComputerBuildingSystem
{
    using System;

    public class MonochromeVideoCard : VideoCardBase
    {
        public override void DrawTextData(string data)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(data);
            Console.ResetColor();
        }
    }
}
