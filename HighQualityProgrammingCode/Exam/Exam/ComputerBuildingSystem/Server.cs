namespace ComputerBuildingSystem
{
    using System.Collections.Generic;
    using ComputerBuildingSystem.Contracts;

    public class Server : Computer, IProcessable
    {
        public Server(ICpu cpu, IRam ram, IEnumerable<HardDrive> hardDrives, VideoCardBase videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Process(int data)
        {
            this.Ram.SaveValue(data);

            var formattedSquareNumber = this.Cpu.GetFormattedSquareNumber(this.Ram.LoadValue());

            this.Cpu.PrintFormattedNumberSquare(formattedSquareNumber);
        }
    }
}
