using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        bool isHuman = true;

        bool f = false;

        decimal num = 9.99m;

        decimal total = num * num;

        string firstName = "Roberto";
        string lastName = "Navarro";
        int age = 35;
        string job = "Developer";
        string favoriteBand = "AC/DC";
        string favoriteSportsTeams = "Spurs";

        Console.WriteLine("First Name: " + firstName);
        Console.WriteLine("Last Name: " + lastName);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Job: " + job);
        Console.WriteLine("Favorite Band: " + favoriteBand);
        Console.WriteLine("Favorite Sports Team: " + favoriteSportsTeams);


        int myInteger = (int)num;

        Console.WriteLine("My Integer: " + myInteger);





        // leave this command at the end so your program does not close automatically
        Console.ReadLine();
    }
}
