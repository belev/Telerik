using System;

class StringToObjectTypeCasting
{
    static void Main()
    {
        string hello = "Hello";
        string world = "World";

        object helloWorld = hello + " " + world;

        string resultAsString = (string) helloWorld;
    }
}

