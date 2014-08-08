namespace ComputerBuildingSystem
{
    public interface IMotherboard
    {
        /// <summary>
        /// Load the current value from the ram.
        /// </summary>
        /// <returns>Return the value in the ram.</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves the value to the ram.
        /// </summary>
        /// <param name="value">The number which should be saved in the ram.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// By given data the method give the data to the video card so that the data could be drown.
        /// </summary>
        /// <param name="data">The data which should be drown on the video card.</param>
        void DrawOnVideoCard(string data);
    }
}