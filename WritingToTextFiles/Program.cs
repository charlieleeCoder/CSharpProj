using System;
using System.IO;

namespace WritingToTextFiles
{
    internal class Program
    {
        static void Main()
        {
            // Specify the directory path
            string directoryPath = @"C:\Users\charl\OneDrive\Desktop\CSharpProjects";

            // Specify the file name
            string fileName = "example.txt";

            // Combine the directory path and file name to get the full file path
            string filePath = Path.Combine(directoryPath, fileName);

            try
            {
                // Use StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write content to the file
                    writer.WriteLine("Hello, world!");
                    writer.WriteLine("This is a sample text.");
                }

                Console.WriteLine("File has been written successfully to: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to the file: " + ex.Message);
            }
        }
    }
}