using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(">>>>Rock, Paper, Scissors<<<<<");

        Console.Write("Enter hand 1 (rock, paper or scissors): ");
        string hand1 = Console.ReadLine().ToLower();

        Console.Write("Enter hand 2 (rock, paper or scissors): ");
        string hand2 = Console.ReadLine().ToLower();

        Console.WriteLine(CompareHands(hand1, hand2));
    }

    public static string CompareHands(string hand1, string hand2)
    {
        string message = "";
        bool tie = false;
        tie = (hand1 == hand2) ? true : false;

        if (tie) message = "It's a tie!";

        switch (hand1)
        {
            case "rock":
                if (hand2 == "scissors") message = "Rock beats scissors, Hand one wins!";
                message = "Paper beats rock, Hand two wins!";
                break;
            case "paper":
                if (hand2 == "rock") message = "Paper beats rock, Hand one wins!";
                message = "Scissors beats paper, Hand two wins!";
                break;
            case "scissors":
                if (hand2 == "paper") message = "Scissors beats paper, Hand one wins!";
                message = "Rock beats scissors, Hand two wins!";
                break;
        }

        return message;
    }
}
