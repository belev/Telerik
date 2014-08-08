namespace ComputerBuildingSystem
{
    public interface ICpu
    {
        byte NumberOfCores { get; set; }

        int GenerateRandomNumber(int minBoundary, int maxBoundary);

        void SaveRandomNumberToRam(int number);

        void PrintFormattedNumberSquare(string formattedSquareNumber);

        string GetFormattedSquareNumber(int value);
    }
}
