using System;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read in the list of items for each rucksack.
            string[] rucksacks = File.ReadAllLines("input.txt");

            // Keep track of the sum of priorities.
            int sum = 0;

            // For each rucksack...
            foreach (string rucksack in rucksacks)
            {
                // Find the first half and second half of the items in the rucksack.
                string firstHalf = rucksack.Substring(0, rucksack.Length / 2);
                string secondHalf = rucksack.Substring(rucksack.Length / 2);

                // Find the item type that appears in both compartments.
                char commonItemType = firstHalf.Intersect(secondHalf).Single();

                // Calculate the priority of the item type.
                int priority = (commonItemType >= 'a' && commonItemType <= 'z') ?
                    commonItemType - 'a' + 1 :
                    commonItemType - 'A' + 27;

                // Add the priority to the sum.
                sum += priority;
            }

            // Print the sum of priorities.
            Console.WriteLine(sum);
        }
    }
}
