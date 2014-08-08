namespace ComputerBuildingSystem
{
    using System.Collections.Generic;
    
    using ComputerBuildingSystem.Contracts;

    public class Pc : Computer, IPlayable
    {
        public const string DidntGuessTheNumberMessageFormat = "You didn't guess the number {0}.";
        public const string WinMessage = "You win!";

        public const int MinGeneratedNumberBoundary = 1;
        public const int MaxGeneratedNumberBoundary = 10;

        public Pc(ICpu cpu, IRam ram, IEnumerable<HardDrive> hardDrives, VideoCardBase videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Play(int guessNumber)
        {
            var generatedNumber = this.Cpu.GenerateRandomNumber(MinGeneratedNumberBoundary, MaxGeneratedNumberBoundary);
            this.Cpu.SaveRandomNumberToRam(generatedNumber);

            var number = this.Ram.LoadValue();
            if (number != guessNumber)
            {
                var formattedGuessResult = string.Format(DidntGuessTheNumberMessageFormat, number);
                this.VideoCard.DrawTextData(formattedGuessResult);
            }
            else
            {
                this.VideoCard.DrawTextData(WinMessage);
            }
        }
    }
}
