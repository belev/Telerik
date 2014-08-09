namespace _09.MembersOfSequence
{
    using System;
    using System.Collections.Generic;

    public class MembersOfSequence
    {
        static void Main()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            Queue<int> membersOfSequence = new Queue<int>();
            membersOfSequence.Enqueue(n);

            List<int> sequence = new List<int>();

            int counter = 0;

            // this if a little optimization so that we dont calculate and enqueue a lot of unnecessary elements from the sequence
            // from 0 to 17 exclusive there are 17 steps
            // in the loop for every step we generate the next three numbers of the sequence
            // so for 17 steps will have 17 * 3 + 1 = 52 numbers of the sequence
            while (counter < 17)
            {
                int number = membersOfSequence.Dequeue();

                // after number is dequeued from the queue add it to sequence
                sequence.Add(number);
                counter++;

                membersOfSequence.Enqueue(number + 1);
                membersOfSequence.Enqueue(2 * number + 1);
                membersOfSequence.Enqueue(number + 2);
            }


            // there are 52 numbers of the sequence and there are numbers in the queue
            // after that we must have 50 numbers in the sequence add numbers to the sequence
            // until there are only 2 numbers in the queue (we will have exactly 52 - 2 = 50 elements in the sequence)
            while (membersOfSequence.Count != 2)
            {
                sequence.Add(membersOfSequence.Dequeue());
            }

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
