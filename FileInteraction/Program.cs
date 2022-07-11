using System;
using System.IO;
using System.Xml.Serialization;
namespace FileInteraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Running...");
            string[] text = { "Hello Everyone!", "use commas to seperate items", "in your array", "as you declare them" };
            string path = @"./TextFile.txt";
            File.WriteAllText(path, ""); // To clear the TextFile.txt for testing

            bool loop = true;
            while (loop != false)
            {
                Console.Write("\n0: Exit.\n1: Read from file.\n2: Write to file.\n3: Create Xml Record.\n4: Read Xml Record\nPlease select an option: ");
                string? choice = Console.ReadLine();
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

                    case "3":
                        Person p = new Person("Jake", 1.75, 74);
                        Console.WriteLine("\nWriting on file...");
                        if (!File.Exists(path))
                        {
                            File.WriteAllText(path, p.SerializeXml());
                        }
                        else
                        {
                            File.AppendAllText(path, p.SerializeXml());
                        }
                        break;

                    case "4":
                        Person Q = DeserializeXML();
                        Console.WriteLine(Q.name + "\n" + Q.height + "\n" + Q.weight);
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

        private static Person DeserializeXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            string path = @"./TextFile.txt";
            Person p = new Person();
            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist.");
                return null;
            }
            else
            {
                using StreamReader reader = new StreamReader(path);
                var record = (Person)serializer.Deserialize(reader);
                if (record is null)
                {
                    throw new InvalidDataException();
                    return null;
                }
                else
                {
                    p = record;
                }
            }
            return p;
        }

    }
}