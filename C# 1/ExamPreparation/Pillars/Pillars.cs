using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillars
{
    class Pillars
    {

        static void Main()
        {
            int[] numbers = new int[8];
            int[,] matrix = new int[8, 8];

            for (int i = 0; i < 8; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int j = 0; j < 8; j++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if (((numbers[j] >> k) & 1) == 1)
                    {
                        matrix[j, k] = 1;
                    }
                }
            }

            bool hasSolution = false;
            int pillar = -1;
            int numberOfFullCells = 0;

            for (int i = 7; i >= 0; i--)
            {
                int leftCells = 0;
                int rightCells = 0;

                for (int k = 7; k > i; k--)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (matrix[j, k] == 1)
                        {
                            leftCells++;
                        }
                    }
                }

                for (int k = 0; k < i; k++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (matrix[j, k] == 1)
                        {
                            rightCells++;
                        }
                    }
                }

                if (rightCells == leftCells)
                {
                    numberOfFullCells = rightCells;
                    pillar = i;
                    hasSolution = true;
                    break;
                }
            }
           

            if (hasSolution)
            {
                Console.WriteLine(pillar);
                Console.WriteLine(numberOfFullCells);
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}