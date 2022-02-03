using System;
using System.IO;

namespace P15
{
    class Program
    {
        private static TextReader reader;

        private static int n, m, x;
        private static int[,] v;

        private static void init()
        {
            reader = new StreamReader(@"../../date.in");
            
            string input;
            string[] inputSplit;
            try
            {
                input = reader.ReadLine();
                inputSplit = input.Split(' ');
                n = int.Parse(inputSplit[0]);
                m = int.Parse(inputSplit[1]);
                v = new int[n, m];
                Console.WriteLine(n + " " + m);
                int i = 0, j;
                while ((input = reader.ReadLine()) != null && i < n)
                {
                    inputSplit = input.Split(' ');
                    for (j = 0; j < m; j++)
                        Console.Write((v[i, j] = int.Parse(inputSplit[j])) + " ");
                    i++;
                    Console.WriteLine();
                }
                Console.WriteLine(x = int.Parse(input));
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}:{e.StackTrace}");
                reader.Close();
                return;
            }
            reader.Close();
        }
        static void Main(string[] args)
        {
            init();
            bool ok = false;
            for (int i = 0; i < n; i++)
                if (v[i, 0] == x || v[i, m - 1] == x) 
                    ok = true;
            for (int j = 0; j < m; j++) 
                if (v[0, j] == x || v[n - 1, j] == x) 
                    ok = true;
            Console.WriteLine($"{(ok ? "DA" : "NU")}");
            Console.ReadKey();
        }
    }
}
