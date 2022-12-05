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

            // Group the rucksacks into groups of three.
            for (int i = 0; i < rucksacks.Length; i += 3)
            {
                string rucksack1 = rucksacks[i];
                string rucksack2 = rucksacks[i + 1];
                string rucksack3 = rucksacks[i + 2];

                // Find the item type that appears in all three rucksacks.
                char commonItemType =
                    rucksack1.Intersect(rucksack2).Intersect(rucksack3).Single();

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
