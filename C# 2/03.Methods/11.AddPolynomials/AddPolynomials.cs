using System;
class AddPolynomials
{
    static decimal[] ReadPolynomialCoeficient()
    {
        Console.Write("Enter the power of the polynomial: ");
        int power = int.Parse(Console.ReadLine());

        decimal[] polynomial = new decimal[power + 1];
        Console.WriteLine("Please enter the coeficients of the polynomial: ");

        for (int i = 0; i < power; i++)
        {
            polynomial[i] = decimal.Parse(Console.ReadLine());
        }

        return polynomial;
    }
    static decimal[] AddTwoPolynomials(decimal[] firstPolynomial, decimal[] secondPolynomial)
    {
        int firstLength = firstPolynomial.Length;
        int secondLength = secondPolynomial.Length;

        int biggerLength = Math.Max(firstLength, secondLength);

        decimal[] sumOfPolynomials = new decimal[biggerLength];

        for (int i = 0; i < biggerLength; i++)
        {
            if (i < firstLength)
            {
                sumOfPolynomials[i] += firstPolynomial[i];
            }
            if (i < secondLength)
            {
                sumOfPolynomials[i] += secondPolynomial[i];
            }
        }

        return sumOfPolynomials;
    }
    private static void PrintPolynomial(decimal[] polynomial)
    {
        for (int i = polynomial.Length - 1; i >= 0; i--)
        {
            if (polynomial[i] != 0)
            {
                if (i > 0)
                {
                    if (polynomial[i - 1] > 0)
                    {
                        Console.Write("{0}x^{1} +", polynomial[i], i);
                    }
                    else
                    {
                        Console.Write("{0}x^{1} ", polynomial[i], i);
                    }
                }
                else if (i == 0)
                {
                    Console.WriteLine(polynomial[i]);
                }
            }
        }
    }
    static void Main()
    {
        decimal[] firstPolynom = ReadPolynomialCoeficient();
        decimal[] secondPolynom = ReadPolynomialCoeficient();

        decimal[] addResult = AddTwoPolynomials(firstPolynom, secondPolynom);

        Console.Write("The first polynom is: ");
        PrintPolynomial(firstPolynom);

        Console.Write("The second polynom is: ");
        PrintPolynomial(secondPolynom);

        Console.Write("The sum of the polynomials is: ");
        PrintPolynomial(addResult);
    }
}

