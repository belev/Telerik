namespace _02.DataAccessObject
{
    using System;
    using DataAccessObjectsUtils;

    public class DataAccessObjectTest
    {
        public static void Main()
        {
            InsertTest();
            ModifyTest();
            DeleteTest();
        }

        static void InsertTest()
        {
            var affectedRows = DataAccessObjectsUtils.InsertCustomer("ABCDE", "TestCompany", "TestContactName", "TestCity");

            Console.WriteLine("Insert -> ({0} affected row(s))", affectedRows);
        }

        static void ModifyTest()
        {
            var affectedRows = DataAccessObjectsUtils.ModifyCustomerCompanyName("ABCDE", "TestCompanyUpdated");

            Console.WriteLine("Modify -> ({0} affected row(s))", affectedRows);
        }

        static void DeleteTest()
        {
            var affectedRows = DataAccessObjectsUtils.DeleteCustomer("ABCDE");

            Console.WriteLine("Delete -> ({0} affected row(s))", affectedRows);
        }
    }
}
