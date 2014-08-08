namespace ComputerBuildingSystem
{
    public class ComputerBuildingSystemEntryPoint
    {
        private static void Main()
        {
            CommandsProcessor commandsProcessor = new CommandsProcessor();
            commandsProcessor.ProcessCommands();
        }
    }
}