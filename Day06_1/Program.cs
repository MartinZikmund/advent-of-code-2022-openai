string datastream = File.ReadAllText("input.txt");

Queue<char> queue = new Queue<char>();

for (int i = 0; i < datastream.Length; i++)
{
    char c = datastream[i];

    queue.Enqueue(c);

    if (queue.Count > 4)
    {
        queue.Dequeue();
    }

    if (queue.Count == 4)
    {
        HashSet<char> set = new HashSet<char>(queue);
        if (set.Count == 4)
        {
            Console.WriteLine(i + 1);
            break;
        }
    }
}
