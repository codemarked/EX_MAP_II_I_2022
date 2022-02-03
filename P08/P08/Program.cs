using System;
using System.IO;

namespace P08
{
    class Program
    {

        private static TextReader reader;
        private static TextWriter writer;

        private static int n, k;
        private static int[] vector;

        private static void init()
        {
            reader = new StreamReader(@"../../date.in");
            writer = new StreamWriter(@"../../date.out");

            string[] inputSplit;
            try
            {
                inputSplit = reader.ReadLine().Split(' ');
                n = int.Parse(inputSplit[0]);
                k = int.Parse(inputSplit[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}:{e.StackTrace}");
                reader.Close();
                writer.Close();
                return;
            }
            reader.Close();
            vector = new int[9];
        }

        private static bool Validate(int pos)
        {
            for (int i = 0; i < pos; i++)
                if (vector[i] == vector[pos])
                    return false;
            return true;
        }
        private static void BackTrack(int pos)
        {
            for (int i = 1; i <= n; i++)
            {
                vector[pos] = i;
                if (Validate(pos))
                    if (pos == k - 1)
                    {
                        for (int j = 0; j < k; j++)
                        {
                            Console.Write($"{vector[j]} ");
                            writer.Write($"{vector[j]} ");
                        }
                        writer.WriteLine();
                        Console.WriteLine();
                    }
                    else
                        BackTrack(pos + 1);
            }
        }
        public static void Main(string[] args)
        {
            init();
            BackTrack(0);
            writer.Close();
            Console.ReadKey();
        }
    }
}
