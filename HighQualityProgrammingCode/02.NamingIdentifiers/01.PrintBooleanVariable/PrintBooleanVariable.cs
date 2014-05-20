namespace PrintBooleanVariable
{
    using System;

    public class PrintBooleanVariable
    {
        private const int MaxCount = 6;

        public static void Main()
        {
            BooleanVariablePrinter printer = new BooleanVariablePrinter();
            printer.PrintBool(true);
        }

        public class BooleanVariablePrinter
        {
            public void PrintBool(bool booleanVariable)
            {
                string variableAsString = booleanVariable.ToString();
                Console.WriteLine(variableAsString);
            }
        }
    }
}