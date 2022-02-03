using System;
using System.IO;

namespace _2022__ExMAP_MeguGabrielRobert_20_
{
    class Program
    {
        static void Main(string[] args)
        {
            TreiVectori();
        }


        /// <summary>
        /// Se dau 3 vectori care se introduc de la tastatură. Să se scrie programul de
        /// determinare:
        /// a) al produsului mixt al celor 3 vectori
        /// b) Să se verifice dacă vectorii sunt coplanari
        /// c) Să se calculeze volumul paralelogramului construit pe cei trei vectori ca
        /// muchii
        /// </summary>
        private static void TreiVectori()
        {

            Console.WriteLine("Read vectors from console or from file?");
            Console.WriteLine("1 - console");
            Console.WriteLine("2 - file");
            int res = int.Parse(Console.ReadLine());

            double produs_mixt;

            if (res == 1)
            {
                produs_mixt = GetMixtProdFormConsoleVectors();
            }
            else if (res == 2)
            {
                produs_mixt = GetMixtProdFormFileVectors();
            }
            else
            {
                throw new Exception("Wrong input!");
            }


            Console.WriteLine($"Produsul mixt este = {produs_mixt}");

            if (produs_mixt == 0)
                Console.WriteLine("Vectorii sunt coplanari");
            else
                Console.WriteLine("Vectorii nu sunt coplanari");

            double volum = Math.Abs(produs_mixt);

            Console.WriteLine($"Volumul este {volum}");

        }

        private static double GetMixtProdFormFileVectors()
        {

            FileStream fsIn = new FileStream("vectors.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fsIn);

            var vector1 = sr.ReadLine().Split();

            int x1 = int.Parse(vector1[0]);
            int y1 = int.Parse(vector1[1]);
            int z1 = int.Parse(vector1[2]);
            Console.WriteLine("v1=" + Vector(x1, y1, z1));

            var vector2 = sr.ReadLine().Split();

            int x2 = int.Parse(vector2[0]);
            int y2 = int.Parse(vector2[1]);
            int z2 = int.Parse(vector2[2]);
            Console.WriteLine("v2=" + Vector(x2, y2, z2));

            var vector3 = sr.ReadLine().Split();

            int x3 = int.Parse(vector3[1]);
            int y3 = int.Parse(vector3[2]);
            int z3 = int.Parse(vector3[0]);
            Console.WriteLine("v3=" + Vector(x3, y3, z3));

            sr.Close();
            fsIn.Close();

            double produs_mixt = GetProdMixt(x1, y1, z1, x2, y2, z2, x3, y3, z3);
            return produs_mixt;
        }

        private static double GetMixtProdFormConsoleVectors()
        {
            Console.WriteLine($"Introduceti v1:");
            Console.Write("x1 = ");
            int x1 = int.Parse(Console.ReadLine());
            Console.Write("y1 = ");
            int y1 = int.Parse(Console.ReadLine());
            Console.Write("z1 = ");
            int z1 = int.Parse(Console.ReadLine());
            Console.WriteLine("v1=" + Vector(x1, y1, z1));

            Console.WriteLine($"Introduceti v2:");
            Console.Write("x2 = ");
            int x2 = int.Parse(Console.ReadLine());
            Console.Write("y2 = ");
            int y2 = int.Parse(Console.ReadLine());
            Console.Write("z2 = ");
            int z2 = int.Parse(Console.ReadLine());
            Console.WriteLine("v2=" + Vector(x2, y2, z2));

            Console.WriteLine($"Introduceti v3:");
            Console.Write("x3 = ");
            int x3 = int.Parse(Console.ReadLine());
            Console.Write("y3 = ");
            int y3 = int.Parse(Console.ReadLine());
            Console.Write("z3 = ");
            int z3 = int.Parse(Console.ReadLine());
            Console.WriteLine("v3=" + Vector(x3, y3, z3));

            double produs_mixt = GetProdMixt(x1, y1, z1, x2, y2, z2, x3, y3, z3);
            return produs_mixt;
        }

        private static double GetProdMixt(int x1, int y1, int z1, int x2, int y2, int z2, int x3, int y3, int z3)
        {
            return x1 * y2 * z3 + x2 * y3 * z1 + x3 * y1 * z2 - z1 * y2 * x3 - z2 * y3 * x1 - z3 * y1 * x2;
        }

        private static string Vector(int x, int y, int z)
        {
            string result = null;
            if (x != 0)
            {
                result += $"{x}i";

            }
            if (y != 0)
            {
                result += $"{Write(y)}j";
            }
            if (z != 0)
            {
                result += $"{Write(z)}k";
            }
            if (result == null)
            {
                return "0";
            }
            return $"{ x }i{Write(y)}j{Write(z)}k";
        }

        private static string Write(int x)
        {

            if (x >= 0)
                return $"+{x.ToString()}";
            else
                return $"{x.ToString()}";
        }
    }
}
