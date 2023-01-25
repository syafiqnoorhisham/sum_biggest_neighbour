
class Program
{
    static void Main(string[] args)
    {
        Program obj = new Program();
        int[] a = new int[] { 2, 1, 1, 2 };
        int result = obj.Challenge(a);
        Console.WriteLine("The biggest combination of neighbor elements in X is: " + result);
        Console.ReadLine();
    }

    public int Challenge(int[] a)
    {
        // Find M
        Dictionary<int, int> counts = new Dictionary<int, int>();
        for (int i = 0; i < a.Length; i++)
        {
            if (!counts.ContainsKey(a[i]))
            {
                counts.Add(a[i], 1);
            }
            else
            {
                counts[a[i]]++;
            }
        }
        int M = 0;
        foreach (int count in counts.Values)
        {
            M = Math.Max(M, count);
        }

        // Build X
        List<int> X = new List<int>();
        for (int i = 0; i < a.Length; i++)
        {
            if (counts[a[i]] >= M - 1)
            {
                X.Add(a[i]);
            }
        }

        // Find the biggest combination of neighbor elements
        int biggest = int.MinValue;
        for (int i = 0; i < X.Count - 1; i++)
        {
            biggest = Math.Max(biggest, X[i] + X[i + 1]);
        }

        return biggest;
    }
}
