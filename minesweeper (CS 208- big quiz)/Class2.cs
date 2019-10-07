using System;

public class Print
{
    public static void PrintBoard()
    {
        int numTests = Convert.ToInt32(Console.ReadLine());//take the number of minesweeper board
        for (int t = 0; t < numTests; t++)
        {
            String[] nums = Console.ReadLine().Split(' '); // 3 numbers, so 0 , 1, 2 equals to row , col , mine
            int numRows = Convert.ToInt32(nums[0]);
            int numCols = Convert.ToInt32(nums[1]);
            int numMines = Convert.ToInt32(nums[2]);
            
            

            int[,] board = new int[numRows,numCols];
            for (int i = 0; i < numCols; i++) { //creating empty board
                for (int o = 0; o < numRows-1; o++)
                {
                    board[o,i] = 0;
                }
                board[numRows-1, i] = 0;//only for last position

            }

            for (int m = 0; m < numMines; m++)//printing the mine
            {
                string[] coords = Console.ReadLine().Split(' ');
                int row = Convert.ToInt32(coords[0]);
                int col = Convert.ToInt32(coords[1]);
                board[col, row] = 11;
                for (int i = -1; i <= 1; i++)//add value in square
                {
                    for (int a = -1; a <= 1; a++)
                    {
                        try
                        {
                            board[col + i, row + a] += 1;
                        }
                        catch (System.IndexOutOfRangeException e) { };//for index < 0
                    }
                }
            }

            //printing the board
            for (int i = 0; i < numCols; i++)
            { 
                for (int o = 0; o < numRows - 1; o++)
                {
                    if (board[o, i] > 10)//because pseudo value is 11
                        Console.Write("M ");
                    else Console.Write(board[o, i]+ " ");
                }
                if (board[numRows - 1, i] > 10)//because pseudo value is 11
                    Console.WriteLine("M ");
                else Console.WriteLine(board[numRows - 1, i] + " ");
            }
        }
    }
}
