using System;
using System.Collections.Generic;

public class Program
{
    // Fields
    private static Dictionary<string, List<int>> stacks;

    // Properties
    // ...

    // Methods
    static Program()
    {
        stacks = new Dictionary<string, List<int>>
        {
            { "a", new List<int>() { 4, 3, 2, 1 } },
            { "b", new List<int>() { } },
            { "c", new List<int>() { } }
        };

    }

    public static void Main()
    {
        while (!GameOver())
        {
            Console.Clear();

            PrintStacks();

            Console.WriteLine("Enter Starting Stack:");
            string start = Console.ReadLine();

            Console.WriteLine("Enter Finish Stack:");
            string finish = Console.ReadLine();

            if (IsLegal(start, finish))
            {
                MovePiece(start, finish);
            }
            else
            {
                Console.WriteLine("Illegal move, try again!!!");
            }

        }

        PrintStacks();
        Console.WriteLine("You Won!!!");
    }

    public static bool GameOver()
    {
        if (stacks["b"].Count == 4 || stacks["c"].Count == 4)
            return true;

        return false;
    }

    public static void MovePiece(string start, string finish)
    {
        List<int> startStack = stacks[start]; // contains all the blocks in the stack e.g. for stack "a" the blocks are 4, 3, 2, 1
        List<int> finishStack = stacks[finish];

        int movingBlock = startStack[startStack.Count - 1]; // gets the block that we will move

        finishStack.Add(movingBlock);
        startStack.Remove(movingBlock);
    }

    public static bool IsLegal(string start, string finish)
    {
        // Is finish stack empty?
        if (stacks[finish].Count == 0) return true;

        List<int> startStack = stacks[start]; // contains all the blocks in the stack e.g. for stack "a" the blocks are 4, 3, 2, 1
        List<int> finishStack = stacks[finish];

        int movingBlock = startStack[startStack.Count - 1]; // gets the block that we will move
        int finishStackLastBlock = finishStack[finishStack.Count - 1]; // gets last block in finish stack, where we are planning on placing the moving block

        // Is the block being moved smaller than the last finish stack block?
        if (movingBlock < finishStackLastBlock) return true;

        return false;
    }

    public static void PrintStacks()
    {
        string[] letters = new string[] { "a", "b", "c" };
        for (var i = 0; i < letters.Length; i++)
        {
            List<string> blocks = new List<string>();
            for (var j = 0; j < stacks[letters[i]].Count; j++)
            {
                blocks.Add(stacks[letters[i]][j].ToString());
            }
            Console.WriteLine(letters[i] + ": " + String.Join("|", blocks));
        }
    }
}
