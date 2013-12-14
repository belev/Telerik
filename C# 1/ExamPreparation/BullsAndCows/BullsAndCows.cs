using System;

class BullsAndCows
{
    static void Main()
    {
        int secretNumber = int.Parse(Console.ReadLine());
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());

        if (bulls + cows <= 4)
        {
            int countSolution = 0;
            for (int i = 1111; i <= 9999; i++)
            {
                int countBulls = 0;
                int countCows = 0;

                // the digits of the secret number
                int firstDigit = secretNumber / 1000;
                int secondDigit = (secretNumber / 100) % 10;
                int thirdDigit = (secretNumber / 10) % 10;
                int fourthDigit = secretNumber % 10;

                //the digits of the guessed number
                int one = i / 1000;
                int two = (i / 100) % 10;
                int three = (i / 10) % 10;
                int four = i % 10;

                if (two == 0 || three == 0 || four == 0)
                {
                    continue;
                }

                //find bulls, digits of guessed number are used so they are equal to 0, and digits of the secret number are used so the current digit is equal to -1 so that the secret number digits are different from the guessed number digits
                if (one == firstDigit)
                {
                    countBulls++;
                    one = 0;
                    firstDigit = -1;
                }

                if (two == secondDigit)
                {
                    countBulls++;
                    two = 0;
                    secondDigit = -1;
                }


                if (three == thirdDigit)
                {
                    countBulls++;
                    three = 0;
                    thirdDigit = -1;
                }

                if (four == fourthDigit)
                {
                    countBulls++;
                    four = 0;
                    fourthDigit = -1;
                }

                if (one == secondDigit)
                {
                    countCows++;
                    one = 0;
                    secondDigit = -1;
                }
                else if (one == thirdDigit)
                {
                    countCows++;
                    one = 0;
                    thirdDigit = -1;
                }
                else if (one == fourthDigit)
                {
                    countCows++;
                    one = 0;
                    fourthDigit = -1;
                }

                if (two == firstDigit)
                {
                    countCows++;
                    two = 0;
                    firstDigit = -1;
                }
                else if (two == thirdDigit)
                {
                    countCows++;
                    two = 0;
                    thirdDigit = -1;
                }
                else if (two == fourthDigit)
                {
                    countCows++;
                    two = 0;
                    fourthDigit = -1;
                }

                if (three == firstDigit)
                {
                    countCows++;
                    three = 0;
                    firstDigit = -1;
                }
                else if (three == secondDigit)
                {
                    three = 0;
                    secondDigit = -1;
                    countCows++;
                }
                else if (three == fourthDigit)
                {
                    countCows++;
                    three = 0;
                    fourthDigit = -1;
                }

                if (four == firstDigit)
                {
                    countCows++;
                    four = 0;
                    firstDigit = -1;
                }
                else if (four == secondDigit)
                {
                    countCows++;
                    four = 0;
                    secondDigit = -1;
                }
                else if (four == thirdDigit)
                {
                    countCows++;
                    four = 0;
                    thirdDigit = -1;
                }

                if (countCows == cows && countBulls == bulls)
                {
                    Console.Write(i + " ");
                    countSolution++;
                }
            }

            if (countSolution == 0)
            {
                Console.Write("No");
            }
        }
        else
        {
            Console.Write("No");
        }
    }
}

