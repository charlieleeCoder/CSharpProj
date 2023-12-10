using System;
using System.IO;
//using HtmlAgilityPack;

namespace WritingToTextFiles
{
    internal class Program
    {
        static void Main()
        {
            // Specify the directory path
            string directoryPath = @"C:\Users\charl\OneDrive\Desktop\CSharpProjects\";

            // Specify the file name
            string fileName = "example.txt";

            // Combine the directory path and file name to get the full file path
            string filePath = Path.Combine(directoryPath, fileName);

            try
            {
                // Use StreamWriter to write to the file
                using (var writer = new StreamWriter(filePath))
                {
                    // Write content to the file
                    writer.WriteLine("Hello, world!");
                    writer.WriteLine("This is a sample text.");
                    writer.WriteLine("And here's some more.");
                }

                Console.WriteLine("File has been written successfully to: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to the file: " + ex.Message);
            }
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    // Need to not throw away the null test
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading the file: " + ex.Message);
            }
        }
    }
}