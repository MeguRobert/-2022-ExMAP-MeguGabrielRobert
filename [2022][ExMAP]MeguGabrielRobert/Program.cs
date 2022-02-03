using System;
using System.Collections.Generic;
using System.IO;

namespace _2022__ExMAP_MeguGabrielRobert
{
    class Program
    {
        public static int[,] C;

        static void Main(string[] args)
        {
            //C = GetProblemTableFromFile("problemtable.txt");
            GetMyProblems();
        }


        static int[,] GetProblemTableFromFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            List<string> data = new List<string>();

            while (!sr.EndOfStream)
                data.Add(sr.ReadLine());

            sr.Close();
            fs.Close();

            int length = data.Count;


            int[,] matrix = new int[length, length];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    matrix[i, j] = int.Parse(data[i][j].ToString());

            return matrix;
        }

        private static void GetMyProblems()
        {
            Console.WriteLine("Type the first 4 letters of Your Surname (Last Name)");
            string name = Console.ReadLine();
            name = $"{ name[0].ToString().ToUpper()}{name.Substring(1)}";
            Console.WriteLine(name);
            List<int> categories = new List<int>();

            for (int i = 0; i < name.Length; i++)
            {
                char letter = name[i];
                int code = name[i];
                Console.WriteLine($"{letter} = {code,3}");

                if (i == 0)
                {
                    categories.Add(code % 4);
                }
                if (i == 1)
                {
                    categories.Add(code % 5);
                }
                if (i == 2)
                {
                    categories.Add(code % 8);
                }
                if (i == 3)
                {
                    categories.Add(code % 3);
                }


            }

            foreach (var item in categories)
            {
                Console.Write($"{item} ");
            }

            //for (int i = 0; i < categories.Count; i++)
            //{
            //    Console.WriteLine(C[i, categories[i]]);
            //}



        }
    }
}
