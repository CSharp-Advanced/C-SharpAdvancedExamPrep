using System;
using System.Linq;

namespace Beach
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] beach = new char[rows][];
            int tokens = 0;
            int opponentTokens = 0;

            for (int row = 0; row < beach.Length; row++)
            {
                char[] input = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(char.Parse)
                            .ToArray();

                beach[row] = input;
            }

            while (true)
            {

                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = line[0].ToLower();

                if (command == "gong")
                {
                    break;
                }
                int row = int.Parse(line[1]);
                int col = int.Parse(line[2]);


                switch (command)
                {
                    case "find":
                        if (IsInside(beach, row, col))
                        {
                            if (beach[row][col] == 'T')
                            {
                                tokens++;
                                beach[row][col] = '-';
                            }
                        }
                        break;

                    case "opponent":
                        string direction = line[3].ToLower();
                        opponentTokens = OpponentTokes(beach, opponentTokens, row, col);

                        for (int i = 0; i < 3; i++)
                        {
                            if (direction == "up")
                            {
                                row--;
                                opponentTokens = OpponentTokes(beach, opponentTokens, row, col);
                            }
                            else if (direction == "down")
                            {
                                row++;
                                opponentTokens = OpponentTokes(beach, opponentTokens, row, col);
                            }
                            else if (direction == "left")
                            {
                                col--;
                                opponentTokens = OpponentTokes(beach, opponentTokens, row, col);
                            }
                            else if (direction == "right")
                            {
                                col++;
                                opponentTokens = OpponentTokes(beach, opponentTokens, row, col);
                            }
                        }
                        break;
                }
            }



            foreach (char[] row in beach)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            Console.WriteLine($"Collected tokens: {tokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static int OpponentTokes(char[][] beach, int opponentTokens, int row, int col)
        {
            if (IsInside(beach, row, col))
            {
                if (beach[row][col] == 'T')
                {
                    opponentTokens++;
                    beach[row][col] = '-';
                }
            }

            return opponentTokens;
        }

        public static bool IsInside(char[][] beach, int row, int col)
        => row >= 0 && row < beach.Length && col >= 0 && col < beach[row].Length;
    }
}
