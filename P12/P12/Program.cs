using System;
using System.IO;

namespace P12
{
    class Program
    {

        private static TextReader reader;
        private static TextWriter writer;

        private static int n, nrc;
        private static int[,] a;
        private static int[] v;

        private static void init()
        {
            reader = new StreamReader(@"../../componenteconexe1.in");
            writer = new StreamWriter(@"../../componenteconexe1.out");
            a = new int[100, 100];
            v = new int[100];
            string input;
            string[] inputSplit;
            int x, y;
            try
            {
                n = int.Parse(reader.ReadLine());
                while ((input = reader.ReadLine()) != null) {
                    inputSplit = input.Split(' ');
                    a[x = int.Parse(inputSplit[0]), y = int.Parse(inputSplit[1])] = 1;
                    a[y, x] = 1;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}:{e.StackTrace}");
                reader.Close();
                writer.Close();
                return;
            }
            reader.Close();
        }
        private static void dfs(int x, int val)
        {
            v[x] = val;
            for (int i = 1; i <= n; i++)
                if (v[i] == 0 && a[x, i] == 1)  {
                    dfs(i, val);
                    v[i] = val;
                }
        }
        public static void Main(string[] args)
        {
            init();
            for (int i = 1; i <= n; i++)
                if (v[i] == 0)
                {
                    dfs(i, nrc+1);
                    nrc++;
                }
            Console.WriteLine(nrc - 1);
            writer.WriteLine(nrc - 1);
            int rez = 0;
            for (int i = 2; i <= nrc; i++)
            {
                rez = 0;
                for (int j = 1; j <= n && rez == 0; j++)
                    if (i == v[j]) 
                        rez = j;
                Console.Write($"1 {rez} ");
                writer.Write($"1 {rez} ");
            }
            writer.Close();
        }
    }
}
