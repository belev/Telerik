using System;

class PrintManagerAndCompanyInfo
{
    static void Main()
    {
        Console.Write("Enter name of the company: ");
        string companyName = Console.ReadLine();

        Console.Write("Enter company adress: ");
        string companyAdress = Console.ReadLine();

        Console.Write("Enter company phone number: ");
        string companyPhoneNumber = Console.ReadLine();

        Console.Write("Enter company fax number: ");
        string companyFaxNumber = Console.ReadLine();

        Console.Write("Enter company web site: ");
        string companyWebSite = Console.ReadLine();

        //Manager info
        Console.Write("Enter manager first name: ");
        string managerFirstName = Console.ReadLine();

        Console.Write("Enter manager last name: ");
        string managerLastName = Console.ReadLine();

        Console.Write("Enter manager age: ");
        byte managerAge = byte.Parse(Console.ReadLine());

        Console.Write("Enter manager phone number: ");
        string managerPhoneNumber = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Company information");
        Console.WriteLine();

        Console.WriteLine("Name: {0} \nAdress: {1} \nPhone number: {2} \nFax number: {3} \nWeb site: {4}", companyName, companyAdress, companyPhoneNumber, companyFaxNumber, companyWebSite);
        Console.WriteLine();

        Console.WriteLine("Manager information");
        Console.WriteLine();

        Console.WriteLine("Name: {0} {1} \nAge: {2} \nPhone number {3}", managerFirstName, managerLastName, managerAge, managerPhoneNumber);
    }
}

