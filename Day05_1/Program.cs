namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the input from the file.
            string[] inputLines = File.ReadAllLines("input.txt");

            // Initialize the stacks of crates.
            List<Stack<char>> stacks = new List<Stack<char>>();

            // Split the crates diagram into rows.
            int numberOfRows = 0;
            int i = 0;
            while (!string.IsNullOrEmpty(inputLines[i]))
            {
                numberOfRows++;
                i++;
            }

            // Get the number of stacks from the last number on the line before the empty line.
            int numberOfStacks = int.Parse(inputLines[i - 1].Trim().Split(' ').Last());

            // Calculate the position of each crate in the rows.
            int[] positions = Enumerable.Range(0, numberOfStacks)
                .Select(s => (s * 4) + 1)
                .ToArray();

            // For each stack, read the crates from top to bottom.
            for (int stack = 0; stack < numberOfStacks; stack++)
            {
                // For each row in the crates diagram, extract the crate from the current stack.
                Stack<char> crates = new Stack<char>();
                for (int row = numberOfRows - 2; row >= 0; row--)
                {
                    // Get the crate from the current stack in the current row.
                    string crate = inputLines[row].Substring(positions[stack], 1);

                    // If the crate is not empty, add it to the stack.
                    if (!string.IsNullOrEmpty(crate.Trim()))
                    {
                        crates.Push(crate.Trim()[0]);
                    }
                }

                // Add the stack of crates to the list of stacks.
                stacks.Add(crates);
            }

            // Read the rearrangement steps.
            List<Tuple<int, int, int>> steps = new List<Tuple<int, int, int>>();
            for (; i < inputLines.Length; i++)
            {
                // Skip the lines that are not move instructions.
                if (!inputLines[i].StartsWith("move"))
                {
                    continue;
                }

                // Split the move instruction into parts.
                string[] parts = inputLines[i].Split(' ');

                // Parse the quantity of crates to move.
                int quantity = int.Parse(parts[1]);

                // Parse the fromStack and the toStack.
                int fromStack = int.Parse(parts[3]) - 1;
                int toStack = int.Parse(parts[5]) - 1;

                // Add the move instruction to the list.
                steps.Add(Tuple.Create(quantity, fromStack, toStack));
            }

            // Apply the move instructions.
            foreach (Tuple<int, int, int> step in steps)
            {
                // Move the specified quantity of crates from the fromStack to the toStack.
                for (i = 0; i < step.Item1; i++)
                {
                    // If the fromStack is empty, skip this step.
                    if (!stacks[step.Item2].Any())
                    {
                        continue;
                    }

                    // Pop the top crate from the fromStack and push it onto the toStack.
                    char crate = stacks[step.Item2].Pop();
                    stacks[step.Item3].Push(crate);
                }
            }

            // Print the top crate of each stack.
            foreach (Stack<char> stack in stacks)
            {
                // If the stack is empty, print a blank space.
                if (!stack.Any())
                {
                    Console.Write(" ");
                }
                else
                {
                    // Print the top crate of the stack.
                    Console.Write(stack.Peek());
                }
            }

            Console.WriteLine();
        }
    }
}
