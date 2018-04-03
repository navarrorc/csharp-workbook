using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


/*
Write a program that creates a text file that says "This is a text file.".
Write a program that edits the previous file to say "This is a text file, and I can edit it."
Write a program that deletes the previously created file.
Write a program that reads a text file and displays the number of words.
Write a program that reads a text file and displays the longest word in the file.
 */

public class Program
{
    public static async Task Main()
    {
        var sw = new System.Diagnostics.Stopwatch();
        sw.Start();

        //var files = GetFilesAsync();
        await GetFilesAsync();
        //GetFiles();

        var seconds = sw.ElapsedMilliseconds / 1000;
        Console.WriteLine($"It took {seconds} seconds.");

        Console.ReadLine();
    }

    static void GetFiles()
    {
        var files = Directory.GetFiles(@"C:\Program Files (x86)", "*", SearchOption.AllDirectories);
        //foreach (var file in files)
        //{
        //    Console.WriteLine(file);
        //}
        Console.WriteLine($"Total files found: {files.Count():N0}");
    }

    static async Task GetFilesAsync()
    {
        var files = await Task.Run(() => Directory.GetFiles(@"C:\Program Files (x86)", "*", SearchOption.AllDirectories));
        //files.ToList().ForEach(x => Console.WriteLine(x));
        Console.WriteLine($"Total files found: {files.Count():N0}");

    }
}
