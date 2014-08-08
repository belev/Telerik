namespace ComputerBuildingSystem
{
    using System;
    using ComputerBuildingSystem.Contracts;
    using ComputerBuildingSystem.Factories;

    internal class CommandsProcessor
    {
        private const string InvalidCommandMessage = "Invalid command!";
        private const string ChargeCommand = "Charge";
        private const string ProcessCommand = "Process";
        private const string PlayCommand = "Play";

        private IPlayable pc;
        private IChargeable laptop;
        private IProcessable server;

        public void ProcessCommands()
        {
            this.ManufacturerInitializeComputersFromInput();

            var currentLine = Console.ReadLine();

            while (currentLine != "Exit")
            {
                this.ProcessCurrentLine(currentLine);

                currentLine = Console.ReadLine();
            }
        }

        private void ManufacturerInitializeComputersFromInput()
        {
            var manufacturerName = Console.ReadLine();

            ManufacturerFactory manufacturerCreator = new ManufacturerFactory();

            ComputersFactory manufacturer = manufacturerCreator.CreateManufacturer(manufacturerName);

            this.pc = manufacturer.CreatePc();
            this.laptop = manufacturer.CreateLaptop();
            this.server = manufacturer.CreateServer();
        }

        private void ProcessCurrentLine(string currentLine)
        {
            var splittedLine = currentLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (splittedLine.Length != 2)
            {
                Console.WriteLine(InvalidCommandMessage);
                return;
            }

            var commandName = splittedLine[0];
            var commandNumber = int.Parse(splittedLine[1]);

            if (commandName == ChargeCommand)
            {
                this.laptop.ChargeBattery(commandNumber);
            }
            else if (commandName == ProcessCommand)
            {
                this.server.Process(commandNumber);
            }
            else if (commandName == PlayCommand)
            {
                this.pc.Play(commandNumber);
            }
            else
            {
                Console.WriteLine(InvalidCommandMessage);
            }
        }
    }
}