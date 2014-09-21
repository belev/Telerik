namespace DateTimeServices
{
    using System;
    using System.Linq;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDateTimeOperations
    {

        [OperationContract]
        string GetDayOfWeekAsString(DateTime dateTime);
    }
}
