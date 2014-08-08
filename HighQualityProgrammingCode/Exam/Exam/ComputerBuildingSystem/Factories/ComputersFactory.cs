namespace ComputerBuildingSystem.Factories
{
    using ComputerBuildingSystem.Contracts;

    public abstract class ComputersFactory
    {
        public abstract IPlayable CreatePc();

        public abstract IChargeable CreateLaptop();

        public abstract IProcessable CreateServer();
    }
}
