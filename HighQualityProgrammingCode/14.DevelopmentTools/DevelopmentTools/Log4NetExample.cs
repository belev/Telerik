namespace T4Template
{
    using System;

    using log4net;
    using log4net.Config;

    public class Log4NetExample
    {
        private static readonly ILog exception = LogManager.GetLogger("Exception");

        private static readonly ILog debug = LogManager.GetLogger("Debug");

        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            debug.Info("Debug logger says hello.");

            try
            {
                debug.Warn("Please enter valid int number!");

                var number = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                exception.Error(ex.Message);
            }
            finally
            {
                debug.Info("Hello from debug logger again. All previous steps have finished.");
            }
        }
    }
}