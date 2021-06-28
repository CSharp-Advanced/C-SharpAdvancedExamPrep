using System;

namespace ThirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] beach = new char[rows][];
            int tokens = 0;
            int opponentTokens = 0;

            for (int row = 0; row < rows; row++)
            {
                string mazeRow = Console.ReadLine();
                beach[row] = new char[mazeRow.Length];

                for (int col = 0; col < mazeRow.Length; col++)
                {
                    beach[row][col] = mazeRow[col];
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];

                if (command == "Gong")
                {
                    break;
                }
                
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);

                switch (command)
                {
                    case "Find":
                        if (IsInside(beach, row, col))
                        {
                            if (beach[row][col] == 'T')
                            {
                                tokens++;
                                beach[row][col] = '-';
                            }
                        }
                        break;

                    case "Opponent":
                        string direction = input[3];
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
                Console.WriteLine(string.Join("", row));
            }
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

        private static bool IsInside(char[][] beach, int row, int col)
        => row >= 0 && row < beach.Length && col >= 0 && col < beach[row].Length;
    }
}
