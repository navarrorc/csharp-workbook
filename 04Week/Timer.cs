using System;
using System.Collections.Generic;

public class Program
{
    // Fields
    private static Stopwatch _stopwatch;
    private static string _command;

    // Properties
    /* Nothing here as we don't want to share data with any other classes.
       Also, this is the class with the static void Main() Method 
       and only the compiler instantiates/creates an object from this class. */

    // Constructor
    static Program()
    {
        _stopwatch = new Stopwatch();
    }

    //Methods
    public static void Main()
    {
        bool started = false;
        bool stopped = false;
        bool reset = false;

        Console.Clear();
        Console.WriteLine(">>>StopWatch v1.0<<<");

        while (_command != "exit")
        {
            Console.Write("Type command (start, stop, reset, laps or exit): ");
            _command = Console.ReadLine().ToLower();

            Console.Clear();
            Console.WriteLine(">>>StopWatch v1.0<<<");

            if (_command == "start")
            {
                started = _stopwatch.Start();

                if (!started)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("StopWatch is running, `reset` it first to `start` it again.");
                    Console.ResetColor();
                }
            }
            else if (_command == "stop")
            {
                stopped = _stopwatch.Stop();
                if (!stopped)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("StopWatch is NOT runnnig, `start` it first.");
                    Console.ResetColor();
                }

            }
            else if (_command == "reset")
            {
                reset = _stopwatch.Reset();
                if (!reset)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("StopWatch is NOT running, `start` it first.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("StopWatch has been `reset` successfully.");
                    Console.ResetColor();
                }
            }
            else if (_command == "laps")
            {
                if (_stopwatch.Laps.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No laps have been recorded.");
                    Console.ResetColor();
                }

                TimeSpan lap;
                for (int i = 0; i < _stopwatch.Laps.Count; i++)
                {
                    lap = _stopwatch.Laps[i];
                    // see: http://bit.ly/2D7nCdN
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"{(i + 1).ToString("D2")} - {lap.ToString(@"hh\:mm\:ss")} ");
                    Console.ResetColor();

                }
            }
            else if (_command != "exit")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"`{_command}` is NOT a valid command! Please try gain.");
                Console.ResetColor();
            }
        }
        Console.WriteLine("You exited the StopWatch application successfully.");
        Console.ReadLine();
    }
}

class Stopwatch
{
    // Fields
    private DateTime _startDateTime;
    private DateTime _endDateTime;
    private TimeSpan _elapsedTime;

    // Properties
    public List<TimeSpan> Laps { get; set; }

    // Constructors
    public Stopwatch()
    {
        Laps = new List<TimeSpan>();
    }

    // Methods
    public bool Start()
    {
        /* see: https://www.dotnetperls.com/datetime-format
            MMM     display three-letter month
            ddd     display three-letter day of the WEEK
            d       display day of the MONTH
            HH      display two-digit hours on 24-hour scale
            mm      display two-digit minutes
            yyyy    display four-digit year
        */
        //string format = "MMM ddd d HH:mm yyyy";
        //Console.WriteLine(_startDateTime.ToString(format));

        if (_startDateTime.Year == DateTime.Now.Year)
            return false; // stopwatch was already started

        _startDateTime = DateTime.Now;

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("StopWatch is running...");
        Console.ResetColor();

        return true;
    }

    public bool Stop()
    {
        if (_startDateTime.Year != DateTime.Now.Year)
            return false; // stopwatch has not been started

        _endDateTime = DateTime.Now;

        _elapsedTime = _endDateTime.Subtract(_startDateTime);

        Laps.Add(_elapsedTime); // add laps

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(_elapsedTime.ToString(@"hh\:mm\:ss"));
        Console.ResetColor();

        return true;
    }

    public bool Reset()
    {
        if (_startDateTime.Year != DateTime.Now.Year)
            return false; // stopwatch has not been started

        Laps = new List<TimeSpan>(); // clear out the list, reinitialize

        _startDateTime = new DateTime();
        _endDateTime = new DateTime();

        return true;
    }
}
