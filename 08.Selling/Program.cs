using System;
using System.Collections.Generic;

namespace _08.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int money = 0;
            int curRow = 0;
            int curCol = 0;
            bool isOut = false;

            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row,col]=='S')
                    {
                        curRow = row;
                        curCol = col;
                    }
                }
            }

            while (money<=50 || !isOut)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        matrix[curRow, curCol] = '-';
                        curRow--;
                        if (curRow>n)
                        {
                            isOut = true;
                            break;
                        }
                        if (Char.IsDigit(matrix[curRow, curCol]))
                        {
                            money += matrix[curRow, curCol];
                        }
                        else
                        {
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row,col]=='O')
                                    {
                                        matrix[row, col] = 'S';
                                        continue;
                                    }
                                }
                            }
                        }
                        matrix[curRow, curCol] = 'S';
                        break;
                    case "down":
                        matrix[curRow, curCol] = '-';
                        curRow++;
                        if (curRow > n)
                        {
                            isOut = true;
                            break;
                        }
                        if (Char.IsDigit(matrix[curRow, curCol]))
                        {
                            money += matrix[curRow, curCol];
                        }
                        else
                        {
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        matrix[row, col] = 'S';
                                        continue;
                                    }
                                }
                            }
                        }
                        matrix[curRow, curCol] = 'S';
                        break;
                    case "left":
                        matrix[curRow, curCol] = '-';
                        curCol--;
                        if (curCol > n)
                        {
                            isOut = true;
                            break;
                        }
                        if (Char.IsDigit(matrix[curRow, curCol]))
                        {
                            money += matrix[curRow, curCol];
                        }
                        else
                        {
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        matrix[row, col] = 'S';
                                        continue;
                                    }
                                }
                            }
                        }
                        matrix[curRow, curCol] = 'S';
                        break;
                    case "right":
                        matrix[curRow, curCol] = '-';
                        curCol++;
                        if (curCol > n)
                        {
                            isOut = true;
                            break;
                        }
                        if (Char.IsDigit(matrix[curRow, curCol]))
                        {
                            money += matrix[curRow, curCol];
                        }
                        else
                        {
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        matrix[row, col] = 'S';
                                        continue;
                                    }
                                }
                            }
                        }
                        matrix[curRow, curCol] = 'S';
                        break;
                }
            }

            if (!isOut)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
                Console.WriteLine($"Money: {money}");
                PrintMatrix(matrix,n);
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
                Console.WriteLine($"Money: {money}");
                PrintMatrix(matrix, n);
            }
        }

        private static void PrintMatrix(char[,] matrix, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
