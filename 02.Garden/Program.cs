using System;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = 0;
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Bloom Bloom Plow")
                {
                    break;
                }

                string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[0]);
                int col = int.Parse(tokens[1]);

                if (row < 0 || row > rows || col < 0 || col > cols)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                for (int i = 0; i < rows; i++)
                {
                    matrix[row, i]++;
                }
                for (int j = 0; j < cols; j++)
                {
                    matrix[j, col]++;
                }
                matrix[row, col]--;
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
