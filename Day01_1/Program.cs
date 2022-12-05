int currentElf = 1;
int maxElf = 1;
int currentCalories = 0;
int maxCalories = 0;

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
            currentElf++;
            currentCalories = 0;
        }
        else
        {
            // add the number of Calories to the current Elf's inventory
            currentCalories += int.Parse(line);

            // update the Elf with the most Calories
            if (currentCalories > maxCalories)
            {
                maxElf = currentElf;
                maxCalories = currentCalories;
            }
        }
    }
}

// print the number of Calories carried by the Elf with the most Calories
Console.WriteLine("Elf {0} has the most Calories with a total of {1}.", maxElf, maxCalories);
