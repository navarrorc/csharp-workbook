using System;

public class Program
{
    // possible letters in code
    public static char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

    // size of code
    public static int codeSize = 4;

    // number of allowed attempts to crack the code
    public static int allowedAttempts = 10;

    // number of tried guesses
    public static int numTry = 0;

    // test solution
    public static char[] solution = new char[] { 'a', 'b', 'c', 'd' };

    // game board
    public static string[][] board = new string[allowedAttempts][];


    public static void Main()
    {
        CreateBoard();
        DrawBoard();
        char[] guess = new char[4];

        while (numTry < allowedAttempts)
        {

            Console.WriteLine("Enter Guess:");
            guess = Console.ReadLine().ToCharArray();

            if (CheckSolution(guess))
            {
                Console.WriteLine("Congratulations! You win!");
                return;
            }
            else
            {
                InsertCode(guess);
                Console.WriteLine(GenerateHint(guess));
                Console.WriteLine("Try again.");
                numTry++;
                DrawBoard();
            }

        }

        Console.WriteLine("You lose!");
        Console.WriteLine("The correct answer was " + string.Join("", solution));

    }

    public static bool CheckSolution(char[] guess)
    {
        string s = "";
        string g = "";
        //s = string.Join("", solution);
        //g = string.Join("", guess);

        s = new string(solution);
        g = new string(guess);

        return (s == g);
    }

    public static string GenerateHint(char[] guess)
    {
        int correctLetterLocations = 0; // red pin
        int correctLetters = 0; // white pin
        int targetIndex = 0;
        char[] solutionClone = (char[])solution.Clone(); // need to override values, so we create a clone

        for (int i = 0; i < solutionClone.Length; i++)
        {
            if (solutionClone[i] == guess[i])
            {
                correctLetterLocations++; // found matching letter in the same location
                solutionClone[i] = ' ';
            }
        }

        string s = new string(solution); // convert string so that we can use string methods e.g. IndexOf()

        for (int i = 0; i < solutionClone.Length; i++)
        {
            if (solutionClone[i] != ' ')
            {
                targetIndex = s.IndexOf(guess[i]);
                if (targetIndex > -1)
                {
                    correctLetters++;
                }
            }
        }

        return $"You found {correctLetterLocations} letters in the correct location (red pin), You found {correctLetters} letters in the wrong location (white pin)";
    }

    public static void InsertCode(char[] guess)
    {
        for (var i = 0; i < codeSize; i++)
        {
            board[numTry][i] = guess[i].ToString();
        }
    }

    public static void CreateBoard()
    {
        for (var i = 0; i < allowedAttempts; i++)
        {
            board[i] = new string[codeSize + 1];
            for (var j = 0; j < codeSize + 1; j++)
            {
                board[i][j] = " ";
            }
        }
    }

    public static void DrawBoard()
    {
        for (var i = 0; i < board.Length; i++)
        {
            Console.WriteLine("|" + String.Join("|", board[i]));

            char[] myArray = new char[] { 'a', 'b', 'c' };

            string temp = myArray.ToString();
        }
    }

    public static void GenerateRandomCode()
    {
        Random rnd = new Random();
        for (var i = 0; i < codeSize; i++)
        {
            solution[i] = letters[rnd.Next(0, letters.Length)];
        }
    }
}
