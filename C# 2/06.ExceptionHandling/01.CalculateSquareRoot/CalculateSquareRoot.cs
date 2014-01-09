using System;
class CalculateSquareRoot
{
    static void Main()
    {
        try
        {
            int number = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid number");
            }

            double result = (Math.Sqrt(number));
            Console.WriteLine("The number is valid and its square root is: {0}", result);
        }

        catch (ArgumentOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException("Number is out of the possible range");
        }

        catch (OverflowException)
        {
            throw new OverflowException("The number is too big for the chosen type ot data");
        }

        catch (FormatException)
        {
            throw new FormatException("Number is not in the correct format");
        }

        finally
        {
            Console.WriteLine("Good bye.");
        }

    }
}

