using System;
using System.Collections.Generic;

namespace NQueen
{
    class Program
    {

        static int size = 4;
        static List<int[,]> solutions = new List<int[,]>();
        static void Main(string[] args)
        {
            Console.WriteLine("8 Queen solver");
            Console.Write("Enter board size (>4):");
            string input = Console.ReadLine();
            Console.WriteLine();
            size = Convert.ToInt32(input);
            if (size < 4)
                size = 4;
            int[,] board = new int[size, size];

            PlaceQueen(board, 0);

            int i = 1;
            foreach (var solution in solutions)
            {
                Console.WriteLine("Solution #" + i++ + ": ");
                DrawChessBoard(solution);
            }
            Console.ReadKey();
        }
        static bool isSafe(int[,] board, int row, int column)
        {
            //for same row
            for (int i = 0; i < column; i++)
            {
                if (board[row, i] == 1)
                    return false;
            }
            //for same column
            for (int i = 0; i < row; i++)
            {
                if (board[i, column] == 1)
                    return false;
            }
            //for left diagonal
            for (int i = row, j = column; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                    return false;
            }

            //for right diagonal
            for (int i = row, j = column; i >= 0 && j < size; i--, j++)
            {
                if (board[i, j] == 1)
                    return false;
            }

            return true;
        }

        static void PlaceQueen(int[,] board, int row)
        {
            if (row == size)
            {

                solutions.Add((int[,])board.Clone());
                return;
            }



            for (int i = 0; i < size; i++)
            {
                if (isSafe(board, row, i))
                {
                    board[row, i] = 1;//placed in this row
                    PlaceQueen(board, row + 1);

                    board[row, i] = 0;
                }
            }

        }
        static void DrawChessBoard(int[,] board)
        {
            Console.Write("   ");
            for (int i = 0; i < size; i++)
            {
                Console.Write($" {i + 1}  ");
            }
            Console.WriteLine();

            for (int row = 0; row < size; row++)
            {
                Console.Write($" {row + 1} ");
                for (int col = 0; col < size; col++)
                {
                    // Determine if the square should be black or white
                    if ((row + col) % 2 == 0)
                    {
                        if (board[row, col] == 1)
                        {
                            Console.Write("[Q] "); // queened 

                        }
                        else
                            Console.Write("[ ] "); // White square
                    }
                    else
                    {
                        if (board[row, col] == 1)
                        {
                            Console.Write("[Q] "); // queened 

                        }
                        else
                            Console.Write("[ ] "); // black square
                    }
                }

                Console.WriteLine(); // New line after each row
            }

        }
    }




}
