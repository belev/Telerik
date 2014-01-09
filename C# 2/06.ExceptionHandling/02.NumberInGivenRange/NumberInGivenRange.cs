using System;
    class NumberInGivenRange
    {
        static int ReadNumber(int start, int end)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                if (number < start || number > end)
                {
                    throw new ArgumentOutOfRangeException("The number is out of range");
                }

                return number;
            }
            catch (OverflowException)
            {
                throw new OverflowException("The number is too big, enter smaller number");
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid format for number");
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Null is not a value");
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException("The number is out of range");
            }

            
            
        }

        static void Main()
        {
            int leftRange = 2;
            int rightRange = 99;

            for (int i = 0; i < 10; i++)
            {
                int number = ReadNumber(leftRange, rightRange);

                leftRange = number;

            }

            Console.WriteLine("You have entered ten numbers in range from 2 to 99 exclusive");
            
        }
    }

