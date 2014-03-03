namespace WarMachines
{
    using WarMachines.Engine;
    using WarMachines.Interfaces;
    using WarMachines.Machines;

    public class WarMachinesProgram
    {
        public static void Main()
        {
            WarMachineEngine.Instance.Start();

        }
    }
}
