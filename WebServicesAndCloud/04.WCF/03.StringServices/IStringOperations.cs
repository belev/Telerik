namespace _03.StringServices
{
    using System;
    using System.Linq;
    using System.ServiceModel;

    [ServiceContract]
    public interface IStringOperations
    {
        [OperationContract]
        int GetSearchStringContainsCount(string searchString, string containsString);
    }
}