using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            int count = 0;
            List<Tuple<int, int>> ranges = new List<Tuple<int, int>>();
            foreach (string s in input)
            {
                string[] split = s.Split(',');
                int a1 = int.Parse(split[0].Split('-')[0]);
                int a2 = int.Parse(split[0].Split('-')[1]);
                int b1 = int.Parse(split[1].Split('-')[0]);
                int b2 = int.Parse(split[1].Split('-')[1]);
                ranges.Add(Tuple.Create(a1, a2));
                ranges.Add(Tuple.Create(b1, b2));

                if ((a1 <= b1 && a2 >= b2) || (b1 <= a1 && b2 >= a2))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
