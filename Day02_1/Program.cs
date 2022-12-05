using System;
using System.Collections.Generic;
using System.IO;

public class Solution
{
    public static void Main()
    {
        // Create a dictionary to store the scores for each shape
        var scores = new Dictionary<string, int>();
        scores["X"] = 1;
        scores["Y"] = 2;
        scores["Z"] = 3;

        // Create a dictionary to store the outcome for each pair of shapes
        var outcomes = new Dictionary<string, int>();
        outcomes["AX"] = 3;
        outcomes["AY"] = 6;
        outcomes["AZ"] = 0;
        outcomes["BX"] = 0;
        outcomes["BY"] = 3;
        outcomes["BZ"] = 6;
        outcomes["CX"] = 6;
        outcomes["CY"] = 0;
        outcomes["CZ"] = 3;

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
