using System;

public class Program
{
    static string playerTurn = "X";
    static string[][] board = new string[][]
    {
        new string[] {" ", " ", " "},
        new string[] {" ", " ", " "},
        new string[] {" ", " ", " "}
    };

    public static void Main()
    {
        do
        {
            DrawBoard();
            GetInput();

        } while (!CheckForWin() && !CheckForTie());

        //Console.ReadLine(); // keep the console window open until you press `enter`
    }

    public static void GetInput()
    {
        int row = 0, column = 0;
        bool result = false;

        Console.WriteLine("Player " + playerTurn);

        while (!result)
        {
            Console.WriteLine("Enter Row:");
            result = int.TryParse(Console.ReadLine(), out row);
            if (!result)
            {
                Console.WriteLine("Your input was invalid! Try again.");
            }
        }

        result = false; // reset to default value before reusing it below

        while (!result)
        {
            Console.WriteLine("Enter Column:");
            result = int.TryParse(Console.ReadLine(), out column);
            if (!result)
            {
                Console.WriteLine("Your input was invalid! Try again.");
            }
        }

        // Draw on board
        board[row][column] = "X";
    }

    public static void PlaceMark(int row, int column)
    {
        // your code goes here
    }

    public static bool CheckForWin()
    {
        // your code goes here

        return false;
    }

    public static bool CheckForTie()
    {
        // your code goes here

        return false;
    }

    public static bool HorizontalWin()
    {
        // your code goes here

        return false;
    }

    public static bool VerticalWin()
    {
        // your code goes here

        return false;
    }

    public static bool DiagonalWin()
    {
        // your code goes here

        return false;
    }

    public static void DrawBoard()
    {
        Console.WriteLine("  0 1 2");
        Console.WriteLine("0 " + String.Join("|", board[0]));
        Console.WriteLine("  -----");
        Console.WriteLine("1 " + String.Join("|", board[1]));
        Console.WriteLine("  -----");
        Console.WriteLine("2 " + String.Join("|", board[2]));
    }
}
