using System;
using System.Collections.Generic;
using System.IO;

namespace _2022__ExMAP_MeguGabrielRobert_6_
{
    class Program
    {
        /*
            6.  
            a)Sa se afiseze matricea de adiacenta a unui graf.
            b) sa se faca parcurgerea lui prin algoritmul BFS si sa se afiseze aceasta.
            c) sa se faca parcurgerea lui prin algoritmul DFS si sa se afiseze acesta.
            d) Sa se verifice daca graful este bipartit.
        */

        public static bool[] visited;
        public static int[,] matrix;

        static void Main(string[] args)
        {
            matrix = BuildMatrix("input.in");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }

            Console.WriteLine();

            BFS();
            Console.WriteLine();
            DFS();

            Console.WriteLine(BipartitGraph(matrix) ? "E bipartit" : "Nu e bipartit");
        }

        static int[,] BuildMatrix(string fileName)
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
                    matrix[i, j] = int.Parse((data[i])[j].ToString());

            return matrix;
        }

        static void BFS()
        {
            int start = 0;
            int length = matrix.GetLength(0);

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(start);

            visited = new bool[length];
            visited[start] = true;

            while (queue.Count != 0)
            {
                int currentNode = queue.Dequeue();
                Console.Write($"{currentNode}");

                for (int i = 0; i < length; i++)
                {
                    if (matrix[currentNode, i] != 0 && visited[i] == false)
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }

            Console.WriteLine();
        }

        static void DFS()
        {
            int start = 0;
            int length = matrix.GetLength(0);

            visited = new bool[length];

            DFSBackTrack(start);

            Console.WriteLine();
        }

        private static void DFSBackTrack(int nodeIndex)
        {
            if (visited[nodeIndex])
            {
                return;
            }

            visited[nodeIndex] = true;
            Console.Write($"{nodeIndex}");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[nodeIndex, i] == 1)
                {
                    DFSBackTrack(i);
                }
            }

        }

        static bool BipartitGraph(int[,] matrix)
        {
            int start = 0;
            int n = matrix.GetLength(0);

            Queue<int> q = new Queue<int>();

            q.Enqueue(start);

            int[] visited = new int[n];
            visited[start] = 1;

            while (q.Count != 0)
            {
                int nodCurent = q.Dequeue();

                for (int i = 0; i < n; i++)
                {
                    if (matrix[nodCurent, i] != 0)
                    {
                        if (visited[i] == 0)
                        {
                            q.Enqueue(i);
                            if (visited[nodCurent] == 1)
                                visited[i] = 2;
                            else
                                visited[i] = 1;
                        }
                        else
                            if (visited[nodCurent] == visited[i])
                            return false;
                    }

                }
            }

            return true;
        }
    }
}
