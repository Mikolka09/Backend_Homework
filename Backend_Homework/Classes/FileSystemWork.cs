using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_Homework.Classes
{
    internal class FileSystemWork
    {
        private static string? SourceFileName { get; set; }
        private static string? TargetFileName { get; set; }

        public static string? TextDocument { get; private set; }


        public static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tFILE SYSTEM MENU\n");
                Console.Write("The required file is in the folder - \"Source Files\" (Yes - 1, NO - 2): ");
                int var = int.Parse(Console.ReadLine());
                switch (var)
                {
                    case 1:
                        FilePathCreate();
                        break;
                    case 2:
                        FileFullPathCreate();
                        break;
                    default:
                        break;
                }
            }
        }

        //get the full path to the file from the user
        private static void FileFullPathCreate()
        {
            //We accept the path from the user, followed by input validation
            Console.Write("\nEnter the full path to the file: ");
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {

                    if (!string.IsNullOrEmpty(Path.GetExtension(input)))
                    {
                        SourceFileName = input;
                        FileOpenRead();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n[ERROR]: Missing file extension");
                        Console.Write("Retry Enter the full path to the file: ");
                    }
                }
                else
                {
                    Console.WriteLine("\n[ERROR]: Invalid input");
                    Console.Write("Retry Enter the full path to the file: ");
                }
            }
        }

        //we get the full file name from the user and create a path to them
        private static void FilePathCreate()
        {
            //We accept the path from the user, followed by input validation
            Console.Write("\nEnter the full name to the file: ");
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    if (!string.IsNullOrEmpty(Path.GetExtension(input)))
                    {
                        SourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\" + input);
                        FileOpenRead();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n[ERROR]: Missing file extension");
                        Console.Write("Retry Enter the full name to the file: ");
                    }

                }
                else
                {
                    Console.WriteLine("\n[ERROR]: Invalid input");
                    Console.Write("Retry Enter the full name to the file: ");
                }
            }
        }

        private static void FileOpenRead()
        {
            if (File.Exists(SourceFileName))
            {
                using (FileStream fileStream = File.Open(SourceFileName, FileMode.Open))
                {
                    using (StreamReader stream = new StreamReader(fileStream))
                    {
                        string input = stream.ReadToEnd();
                        if (!string.IsNullOrEmpty(input))
                        {
                            TextDocument = input;
                        }
                        else
                        {
                            Console.WriteLine("\n[ERROR]: Read error or file is empty");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\n[ERROR]: The path to the file is incorrect or the file does not exist");
            }
        }
    }
}
