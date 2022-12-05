int currentElf = 1;
List<int> topElves = new List<int>();
int currentCalories = 0;

string line;

// open the input file
using (StreamReader reader = new StreamReader("input.txt"))
{
    // read each line of the input file
    while ((line = reader.ReadLine()) != null)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            // start a new Elf's inventory

            // add the current Elf's Calories to the top Elves
            if (topElves.Count < 3)
            {
                topElves.Add(currentCalories);
            }
            else if (currentCalories > topElves.Min())
            {
                topElves[topElves.IndexOf(topElves.Min())] = currentCalories;
            }

            currentElf++;
            currentCalories = 0;
        }
        else
        {
            // add the number of Calories to the current Elf's inventory
            currentCalories += int.Parse(line);
        }
    }

    // add the current Elf's Calories to the top Elves
    if (topElves.Count < 3)
    {
        topElves.Add(currentCalories);
    }
    else if (currentCalories > topElves.Min())
    {
        topElves[topElves.IndexOf(topElves.Min())] = currentCalories;
    }
}

// calculate the total number of Calories carried by the top three Elves
int totalCalories = 0;
foreach (int calories in topElves)
{
    totalCalories += calories;
}

// print the number of Calories carried by the top three Elves
Console.WriteLine("The top three Elves have a total of {0} Calories.", totalCalories);
