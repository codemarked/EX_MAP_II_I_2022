using System;
using System.IO;

namespace P09
{
    class Program
    {
        public class Vector
        {
            public readonly int x, y, z;
            public Vector(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public override string ToString()
            {
                return $"{x},{y},{z}";
            }
        }

        private static void ProdusVectorial(Vector a, Vector b)
        {
            Console.WriteLine("Produs Vectorial:");
            Console.WriteLine();
            double colin, det1, det2, det3;
           
            det1 = (a.y * b.z - b.y * a.z);
            det2 = (b.x * a.z - a.x * b.z);
            det3 = (a.x * b.y - b.x * a.y);

            if (det1 < 0)
                Console.Write($"PV = -{-det1}i");
            else if (det1 > 0)
                Console.Write($"PV = {det1}i");

            if (det2 < 0)
                Console.Write($" - {-det2}j");
            else if (det2 > 0)
                Console.Write($" + {det2}j");

            if (det3 < 0)
                Console.WriteLine($" - {-det3}k");
            else if (det3 > 0)
                Console.WriteLine($" + {det3}k");
            Console.WriteLine();
            Console.WriteLine();
            colin = det1 + det2 + det3;
            Console.WriteLine($"A si B {(colin == 0 ? "" : "nu ")}sunt coliniari!");
            Console.WriteLine();
            Console.WriteLine($"Aria Paralelogramului = val(PV) = {Math.Sqrt(Math.Pow(det1, 2) + Math.Pow(det2, 2) + Math.Pow(det3, 2))}");
        }

        static void Main(string[] args)
        {
            TextReader reader = new StreamReader(@"../../date.in");

            Vector a, b;
            string[] inputSplit;
            try
            {
                inputSplit = reader.ReadLine().Split(' ');
                a = new Vector(int.Parse(inputSplit[0]), int.Parse(inputSplit[1]), int.Parse(inputSplit[2]));
                inputSplit = reader.ReadLine().Split(' ');
                b = new Vector(int.Parse(inputSplit[0]), int.Parse(inputSplit[1]), int.Parse(inputSplit[2]));
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}:{e.StackTrace}");
                reader.Close();
                return;
            }
            Console.WriteLine($"A({a.ToString()})");
            Console.WriteLine($"B({b.ToString()})");
            Console.WriteLine();
            ProdusVectorial(a, b);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
