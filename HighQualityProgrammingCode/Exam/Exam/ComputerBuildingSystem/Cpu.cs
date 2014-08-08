namespace ComputerBuildingSystem
{
    using System;

    public class Cpu : ICpu
    {
        private static readonly Random RandomGenerator = new Random();

        private readonly IRam ram;
        private readonly VideoCardBase videoCard;
        private readonly BaseSquareNumberFinder squareNumberFinder;

        internal Cpu(byte numberOfCores, byte numberOfBits, IRam ram, VideoCardBase videoCard, BaseSquareNumberFinder squareNumberFinder)
        {
            this.NumberOfBits = numberOfBits;
            this.ram = ram;
            this.NumberOfCores = numberOfCores;
            this.videoCard = videoCard;
            this.squareNumberFinder = squareNumberFinder;
        }

        public byte NumberOfCores
        {
            get;
            set;
        }

        public byte NumberOfBits { get; private set; }

        public int GenerateRandomNumber(int minBoundary, int maxBoundary)
        {
            // refactored bottleneck
            int randomNumber = RandomGenerator.Next(minBoundary, maxBoundary + 1);
            return randomNumber;
        }

        public void SaveRandomNumberToRam(int number)
        {
            this.ram.SaveValue(number);
        }

        public string GetFormattedSquareNumber(int value)
        {
            var squareNumberFormatedResult = this.squareNumberFinder.FormattedSquareNumberResult(value);
            return squareNumberFormatedResult;
        }

        public void PrintFormattedNumberSquare(string formattedSquareNumber)
        {
            this.videoCard.DrawTextData(formattedSquareNumber);
        }
    }
}