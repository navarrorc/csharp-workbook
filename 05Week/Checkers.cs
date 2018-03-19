using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    // Fields

    // Properties
    // (N/A)

    // Constructor
    // (Optional)

    // Methods
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine(">>>Welcome to C# Checkers ●○<<<");


    }
}

public class Checker
{

    // Fields

    // Properties
    public string Symbol { get; set; }
    public int[] Position { get; set; }
    public string Color { get; set; }

    // Constructors
    public Checker(string color, int[] position)
    {
        // Your code here
    }

    // Methods



}

public class Board
{
    /*
        [0,0] [0,1] [0,2] [0,3] [0,4] [0,5] [0,6] [0,7]

        [1,0] [1,1] [1,2] [1,3] [1,4] [1,5] [1,6] [1,7]

        [2,0] [2,1] [2,2] [2,3] [2,4] [2,5] [2,6] [2,7]

        [3,0] [3,1] [3,2] [3,3] [3,4] [3,5] [3,6] [3,7]

        [4,0] [4,1] [4,2] [4,3] [4,4] [4,5] [4,6] [4,7]

        [5,0] [5,1] [5,2] [5,3] [5,4] [5,6] [5,7] [5,8]

        [6,0] [6,1] [6,2] [6,3] [6,4] [6,5] [6,6] [6,7]

        [7,0] [7,1] [7,2] [7,3] [7,4] [7,5] [7,6] [7,7]


        [ ] [○] [ ] [○] [ ] [○] [ ] [○]

        [○] [ ] [○] [ ] [○] [ ] [○] [ ]

        [ ] [○] [ ] [○] [ ] [○] [ ] [○]

        [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]

        [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]

        [●] [ ] [●] [ ] [●] [ ] [●] [ ]

        [ ] [●] [ ] [●] [ ] [●] [ ] [●]

        [●] [ ] [●] [ ] [●] [ ] [●] [ ]
    */


    // Fields

    // Properties
    public string[][] Grid { get; set; }
    public List<Checker> Checkers { get; set; }

    // Constructors
    public Board()
    {
        Grid = new string[8][]; // jagged array, array of arrays of different lengths
        Checkers = new List<Checker>();
    }

    // Methods    
    public void CreateBoard()
    {
        // Your code here
    }

    public void GenerateCheckers()
    {
        int[][] whitePositions = new int[12][]
        {
            new int[] { 0, 1 }, new int[] { 0, 3 }, new int[] { 0, 5 }, new int[] { 0, 7 },
            new int[] { 1, 0 }, new int[] { 1, 2 }, new int[] { 1, 4 }, new int[] { 1, 6 },
            new int[] { 2, 1 }, new int[] { 2, 3 }, new int[] { 2, 5 }, new int[] { 2, 7 }
        };

        int[][] blackPositions = new int[12][]
        {
            new int[] { 5, 0 }, new int[] { 5, 2 }, new int[] { 5, 4 }, new int[] { 5, 6 },
            new int[] { 6, 1 }, new int[] { 6, 3 }, new int[] { 6, 5 }, new int[] { 6, 7 },
            new int[] { 7, 0 }, new int[] { 7, 2 }, new int[] { 7, 4 }, new int[] { 7, 6 }
        };
    }

    public void PlaceCheckers()
    {
        // Your code here
    }

    public void DrawBoard()
    {
        // Your code here
    }

    public Checker SelectChecker(int row, int column)
    {
        return Checkers.Find(x => x.Position.SequenceEqual(new List<int> { row, column }));
    }

    public void RemoveChecker(int row, int column)
    {
        // Your code here
        return;
    }

    public bool CheckForWin()
    {
        return Checkers.All(x => x.Color == "white") || !Checkers.Exists(x => x.Color == "white");
    }
}

class Game
{
    // Fields

    // Properties

    // Constructors
    public Game()
    {
        // Your code here
    }

    // Methods

}
