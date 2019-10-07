using System;
using System.Collections.Generic;
using System.Text;

public class Play
{
    private static int[,] board_answer;
    private static int[,] board_play;
    public static void PlayGame()
    {// copy paste the create board_answer
        String[] nums = Console.ReadLine().Split(' '); // 3 numbers, so 0 , 1, 2 equals to row , col , mine
        int numRows = Convert.ToInt32(nums[0]);
        int numCols = Convert.ToInt32(nums[1]);
        int numMines = Convert.ToInt32(nums[2]);
        // Console.Write(numRows + " " + numCols + " " + numMines);

        //if int > 11 = mine, int < 0 = " _ " ( because 9 square surround 1 square)
        board_answer = new int[numRows, numCols];
        board_play = new int[numRows, numCols];
        for (int i = 0; i < numCols; i++)
        { //creating empty board_answer_answer
            for (int o = 0; o < numRows - 1; o++)
            {
                board_answer[o, i] = 0;
                board_play[o, i] = -10;
            }
            board_answer[numRows - 1, i] = 0;//only for last position
            board_play[numRows - 1, i] = -10;
        }

        for (int m = 0; m < numMines; m++)//printing the mine
        {
            string[] coords = Console.ReadLine().Split(' ');
            int row = Convert.ToInt32(coords[0]);
            int col = Convert.ToInt32(coords[1]);
            board_answer[col, row] = 11;
            for (int i = -1; i <= 1; i++)//add value in square
            {
                for (int a = -1; a <= 1; a++)
                {
                    try
                    {
                        board_answer[col + i, row + a] += 1;
                    }
                    catch (System.IndexOutOfRangeException e) { };//for index < 0
                }
            }
        }

        //print board_answer
        bool game_over = false;
        int Count = Convert.ToInt32(Console.ReadLine());
        int NumAction = 0;
        
            while (NumAction < Count)
            {
            NumAction++;
                string[] coords = Console.ReadLine().Split(' ');
                string action = Convert.ToString(coords[0]);
                int RowChosen = Convert.ToInt32(coords[1]);
                int ColChosen = Convert.ToInt32(coords[2]);

                //part 1, check/mark mine
                if (action.Equals("R"))
                {    //check if the the current position is 0 or not
                     // global board _ answer => no need to return a dimensional array value
                     // idea is to return a recursive move from the point of reveal
                    if (board_answer[ColChosen, RowChosen] == 0)
                    {
                        board_play[ColChosen, RowChosen] = board_answer[ColChosen, RowChosen];
                        Limit(ColChosen, RowChosen);// code 1a: recursion of finding 0 and reveal
                                                    // code 2a

                    }
                    else if (board_answer[ColChosen, RowChosen] > 10)
                    {
                        board_play[ColChosen, RowChosen] = board_answer[ColChosen, RowChosen];
                        game_over = true;

                    }
                    else
                    {
                        board_play[ColChosen, RowChosen] = board_answer[ColChosen, RowChosen];
                    }
                }
                //part 1b, mark mine 
                if (action.Equals("M"))
                {
                    board_play[ColChosen, RowChosen] = 11;
                }
                //part 2 : Print the current play board
                Console.WriteLine("The board after reveal");
                for (int i = 0; i < numCols; i++)
                {
                    for (int o = 0; o < numRows - 1; o++)
                    {

                        //first is "normal board game"
                        if (board_play[o, i] > 10)
                            Console.Write("M ");
                        else if (board_play[o, i] < 0)
                            Console.Write("_ ");
                        else Console.Write(board_play[o, i] + " ");
                    }
                    if (board_play[numRows - 1, i] > 10)
                        Console.WriteLine("M ");
                    if (board_play[numRows - 1, i] < 0)
                        Console.WriteLine("_ ");
                    else Console.WriteLine(board_play[numRows - 1, i] + " ");
                }
                if (game_over)
                {
                    Console.WriteLine("You step on the mine !");
                    Console.WriteLine("GAME OVER");
                break;
                }
            }

        
    }
    public static void Limit( int Row, int Col)
    {
        {
            for (int i = -1; i <= 1; i++)
            {
                for(int o = -1; o <= 1; o++)
                {
                    try
                    {
                        if (board_answer[Row - i, Col - o] == 0)
                        {
                           
                            board_play[Row - i, Col - o] = board_answer[Row - i, Col - o];
                            board_answer[Row - i, Col - o] = -1;
                            Limit(Row - i, Col - o);
                        }
                        else
                        {
                            if(board_answer[Row - i, Col - o] < 10 && board_play[Row - i, Col - o] != 0)
                                board_play[Row - i, Col - o] = board_answer[Row - i, Col - o];
                        }
                    }
                    catch (System.IndexOutOfRangeException e) { };
                }
            }
        }
    }
}
