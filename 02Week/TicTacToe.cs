//using Newtonsoft.Json;
using System;
using System.Collections.Generic;

struct Coordinate
{
    public int Row { get; set; }
    public int Column { get; set; }
}
public class Program
{
    static string playerTurn = "X";
    static string[][] board = new string[][]
    {
        new string[] {"1", "2", "3"},
        new string[] {"4", "5", "6"},
        new string[] {"7", "8", "9"}
    };

    static Dictionary<int, Coordinate> slot = new Dictionary<int, Coordinate>()
    {
        { 1, new Coordinate{ Row = 0, Column = 0} },
        { 2, new Coordinate{ Row = 0, Column = 1} },
        { 3, new Coordinate{ Row = 0, Column = 2} },
        { 4, new Coordinate{ Row = 1, Column = 0} },
        { 5, new Coordinate{ Row = 1, Column = 1} },
        { 6, new Coordinate{ Row = 1, Column = 2} },
        { 7, new Coordinate{ Row = 2, Column = 0} },
        { 8, new Coordinate{ Row = 2, Column = 1} },
        { 9, new Coordinate{ Row = 2, Column = 2} },
    };

    public static void Main()
    {
        do
        {
            DrawBoard();
            GetInput();

        } while (!CheckForWin() && !CheckForTie());

        Console.WriteLine("Game Over!");
        Console.ReadLine(); // keep the console window open until you press `enter`
    }

    public static void GetInput()
    {
        int input = 0;
        bool result = false;

        if (playerTurn == "X")
            Console.ForegroundColor = ConsoleColor.Red;
        else
            Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("Player " + playerTurn);

        Console.ResetColor();

        while (!result)
        {
            Console.WriteLine("Select position on the board (1-9):");
            result = int.TryParse(Console.ReadLine(), out input); // returns `false` if it fails to parse
            if (!result || input > 9)
            {
                Console.WriteLine("Your input was invalid! Try again.");
            }
        }

        Coordinate coor = slot.GetValueOrDefault(input);

        PlaceMark(coor.Row, coor.Column);

        if (CheckForWin())
        {
            DrawBoard();
            Console.WriteLine("Player " + playerTurn + " Won!");
            return;
        }
        else if (CheckForTie())
        {
            DrawBoard();
            Console.WriteLine("It's a Tie!");
            return;
        }

        playerTurn = (playerTurn == "X") ? "O" : "X";
    }

    public static void PlaceMark(int row, int column)
    {
        board[row][column] = playerTurn;
    }

    public static bool CheckForWin()
    {
        bool win = false;

        win = (HorizontalWin() || VerticalWin() || DiagonalWin()) ? true : false;

        return win;
    }

    public static int SlotsAvailable()
    {
        int openSlots = 0;

        foreach (var row in board)
        {
            foreach (var column in row)
            {
                if (column != "X" && column != "O")
                {
                    // there are slots left
                    Console.WriteLine($" {column} ");
                    openSlots++;
                }
            }
        }

        return openSlots;
    }

    public static bool CheckForTie()
    {
        bool tie = false;

        tie = SlotsAvailable() == 0 ? true : false;

        return tie;
    }

    public static bool HorizontalWin()
    {
        /*******************
         
         ►[0,0] [0,1] [0,2]

         ►[1,0] [1,1] [1,2]

         ►[2,0] [2,1] [2,2] 
         
        *******************/

        bool win = false;
        bool topRow = false;
        bool middleRow = false;
        bool bottomRow = false;

        topRow = (board[0][0] == playerTurn && board[0][1] == playerTurn && board[0][2] == playerTurn); // top row

        middleRow = (board[1][0] == playerTurn && board[1][1] == playerTurn && board[1][2] == playerTurn); // middle row

        bottomRow = (board[2][0] == playerTurn && board[2][1] == playerTurn && board[2][2] == playerTurn); // bottom row

        win = (topRow || middleRow || bottomRow);

        return win;
    }

    public static bool VerticalWin()
    {

        /*******************
           ▼     ▼     ▼
         [0,0] [0,1] [0,2]

         [1,0] [1,1] [1,2]

         [2,0] [2,1] [2,2] 
         
        *******************/

        bool win = false;
        bool leftColumn = false;
        bool middleColumn = false;
        bool rightColumn = false;

        leftColumn = (board[0][0] == playerTurn && board[1][0] == playerTurn && board[2][0] == playerTurn); // left column

        middleColumn = (board[0][1] == playerTurn && board[1][1] == playerTurn && board[2][1] == playerTurn); // middle column

        rightColumn = (board[0][2] == playerTurn && board[1][2] == playerTurn && board[2][2] == playerTurn); // right column

        win = (leftColumn || middleColumn || rightColumn);

        return win;
    }

    public static bool DiagonalWin()
    {
        /*******************
          
          [0,0] [0,1] [0,2]

          [1,0] [1,1] [1,2]

          [2,0] [2,1] [2,2] 

         *******************/
        bool win = false;
        bool firstDiagonal = false;
        bool secondDiagonal = false;

        firstDiagonal = (board[0][0] == playerTurn && board[1][1] == playerTurn && board[2][2] == playerTurn); // first diagonal
        secondDiagonal = (board[2][0] == playerTurn && board[1][1] == playerTurn && board[0][2] == playerTurn); // second diagonal

        win = (firstDiagonal || secondDiagonal);

        return win;
    }

    public static void DrawBoard()
    {
        //Console.WriteLine("  0 1 2");
        //Console.WriteLine("0 " + String.Join("|", board[0]));
        //Console.WriteLine("  -----");
        //Console.WriteLine("1 " + String.Join("|", board[1]));
        //Console.WriteLine("  -----");
        //Console.WriteLine("2 " + String.Join("|", board[2]));

        /*
          [1][2][3] 
          [4][5][6]
          [7][8][9]
        */

        Console.Clear();

        //var json = JsonConvert.SerializeObject(board, Formatting.None);
        //Console.WriteLine(json);

        Console.WriteLine(">>>>TIC TAC TOE<<<<");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine();

        foreach (var row in board)
        {
            foreach (var column in row)
            {
                if (column == "X")
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (column == "O")
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.Write(" " + column + " ");

                Console.ForegroundColor = ConsoleColor.DarkGray;

            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.ResetColor();
    }
}
