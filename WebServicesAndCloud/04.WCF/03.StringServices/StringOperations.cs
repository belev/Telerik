namespace _03.StringServices
{
    using System;
    using System.Linq;

    public class StringOperations : IStringOperations
    {
        // Press Ctrl + F5 and the WCF test client will run
        // The service will be hosted locally on your machine
        public int GetSearchStringContainsCount(string searchString, string containsString)
        {
            int index = containsString.IndexOf(searchString);

            int count = 0;
            while (index != -1)
            {
                count++;
                index = containsString.IndexOf(searchString, index + 1);
            }

            return count;
        }
    }
}