using System;
using System.Collections;
using System.Text;

public class Program
{
    // Fields
    private static bool _endVoting;
    private static string _command;

    // Properties
    // (N/A)

    // Constructor
    // (Optional)
    static Program()
    {
        _endVoting = false;
    }

    // Methods
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        BlogPost blogPost = new BlogPost(
            title: "My First Blog Post",
            description: "Lorem Ipsum Dolor",
            created: DateTime.Now
            );

        //BlogPost blogPost = new BlogPost("My First Blog Post", "Lorem Ipsum Dolor", DateTime.Now);

        Console.WriteLine(">>>Blog Post Voting<<<");
        Console.WriteLine(blogPost.BlogSummary());

        while (!_endVoting && _command != "exit")
        {
            //Console.Clear();

            // Display Blog Post

            //Console.WriteLine(">>>Blog Post Voting<<<");

            Console.Write("Please enter a command (star, unstar or exit): ");
            _command = Console.ReadLine();

            if (_command == "star")
            {
                Console.Clear();
                blogPost.Upvote();
                Console.WriteLine(blogPost.BlogSummary());
            }
            else if (_command == "unstar")
            {
                Console.Clear();
                bool success = blogPost.Downvote();

                if (!success)
                {
                    Console.WriteLine("Was not able to downvote, value cannot be less than 0");
                }

                Console.WriteLine(blogPost.BlogSummary());
            }
            else if (_command != "exit")
            {
                Console.Clear();
                Console.WriteLine(blogPost.BlogSummary());

                // Display Error message
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Command `{_command}` is not valid. Please try again.");
                Console.ResetColor();
            }
        }
    }
}

public class BlogPost
{
    // Fields
    private int _votes;
    private StringBuilder _summary;
    private string _title;
    private string _description;
    private DateTime _created;

    //Properties

    // Constructors
    public BlogPost(string title, string description, DateTime created)
    {
        _votes = 0;
        _summary = new StringBuilder();
        _title = title;
        _description = description;
        _created = created;
    }

    // Methods
    public string BlogSummary()
    {
        _summary = new StringBuilder();
        _summary.AppendLine("-------------------------------");
        _summary.AppendLine($"Title: {_title}");
        _summary.AppendLine($"Description: {_description}");
        _summary.AppendLine($"Created: {_created}");
        _summary.AppendLine("-------------------------------");
        _summary.AppendLine($"♥ {_votes}");

        return _summary.ToString();
    }


    public bool Upvote()
    {
        _votes++;

        return true;
    }

    public bool Downvote()
    {
        if (_votes == 0)
            return false;

        _votes--;
        return true;
    }
}
