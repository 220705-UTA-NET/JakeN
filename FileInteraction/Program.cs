using System;
using System.IO;
namespace FileInteraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Running...");
            string[] text = { "Hello Everyone!", "use commas to seperate items", "in your array", "as you declare them" };
            string path = @"./TextFile.txt";
            bool loop = true;
            while (loop != false)
            {
                Console.Write("\n0: Exit.\n1: Read from file.\n2: Write to file.\nPlease select an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": // if (choice == read)
                        Console.WriteLine("\nReading from file...\n");
                        if (!File.Exists(path))
                        {
                            Console.WriteLine("The File doesn't exist");
                        }
                        else
                        {
                            string[] readText = File.ReadAllLines(path);
                            foreach (string s in readText)
                            {
                                Console.WriteLine(s);
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("\nWriting on file...");
                        if (!File.Exists(path))
                        {
                            File.WriteAllLines(path, text); // write all lines to the file, if the file exists, 
                                                            // it will over write it,
                                                            // if the file doesn't exist, it will create it.
                        }
                        else
                        {
                            File.AppendAllLines(path, text);
                        }
                        break;
                    case "0":
                        loop = false;
                        Console.WriteLine("\nExiting...");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice, try again...");
                        break;
                }
            }

            Console.WriteLine("\nApplication Complete");
        }
    }
}