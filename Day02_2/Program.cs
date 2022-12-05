using System;
using System.Collections.Generic;
using System.IO;

public class Solution
{
    public static void Main()
    {
        // Create a dictionary to store the outcome for each round
        var scores = new Dictionary<string, int>();
        scores["X"] = 0;
        scores["Y"] = 3;
        scores["Z"] = 6;

        // Create a dictionary to store the score for each pair of shapes
        var outcomes = new Dictionary<string, int>();
        outcomes["AX"] = 3;
        outcomes["AY"] = 1;
        outcomes["AZ"] = 2;
        outcomes["BX"] = 1;
        outcomes["BY"] = 2;
        outcomes["BZ"] = 3;
        outcomes["CX"] = 2;
        outcomes["CY"] = 3;
        outcomes["CZ"] = 1;

        // Initialize the total score to 0
        int totalScore = 0;

        // Open the input file
        using (var input = new StreamReader("input.txt"))
        {
            // Read the strategy guide until we reach the end of the input
            string line = input.ReadLine();
            while (line != null)
            {
                // Split the line into the opponent's shape and the player's shape
                string[] shapes = line.Split(' ');
                string opponentShape = shapes[0];
                string myShape = shapes[1];

                // Calculate the score for this round
                int score = scores[myShape] + outcomes[opponentShape + myShape];

                // Add the score to the total score
                totalScore += score;

                // Read the next line of the strategy guide
                line = input.ReadLine();
            }
        }

        // Print the total score
        Console.WriteLine(totalScore);
    }
}
