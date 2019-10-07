using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class minesweeper
{
    public static void Main(String[] args)
    /* this redirects the program to read standard in ( i.e theConsole, 
     * which is equivalent to System.in in java) from the given file.
     * This is one of a *very few* places where it's actually OK to catch 
     * and ignore an exception */
    {
        try
        {
            Console.SetIn(new StreamReader("C:\\Users\\Loli slayer\\source\\repos\\minesweeper (CS 208- big quiz)\\TextFile2.txt"));
        }
        catch (Exception e)
        {
            // ignore ! 
            // we will just read from standard in if the file cannot be found and read
        }

        string inputType = Console.ReadLine();

        if (inputType.Equals("print_board"))
        {
            Print.PrintBoard();
        }
        else if (inputType.Equals("play_game"))
        {
            Play.PlayGame();
        }
        else
        {
            throw new System.InvalidOperationException($"{inputType } is not a valid Minesweeper input file type");
        }
    }
}