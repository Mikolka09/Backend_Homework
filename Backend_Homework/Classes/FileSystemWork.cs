using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend_Homework.Classes
{
    internal class FileSystemWork
    {
        private static string? SourceFileName { get; set; }
        private static string? TargetFileName { get; set; }

        public static string? TextDocument { get; private set; }
        public static string? TypeFile { get; private set; }


        public static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tFILE SYSTEM MENU\n");
                Console.Write("The required file is in the folder - \"Source Files\" (YES - 1, NO - 2, Back - 3): ");
                int var = int.Parse(Console.ReadLine());
                switch (var)
                {
                    case 1:
                        FilePathCreate();
                        break;
                    case 2:
                        FileFullPathCreate();
                        break;
                    case 3:
                        Program.StartMenu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\n\t[ERROR]: Invalid input");
                        Console.WriteLine("\tTry entering your choice again");
                        Task.Delay(2000).Wait();
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
                        TypeFile = input.Substring(input.LastIndexOf("."));
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
                        TypeFile = input.Split('.')[1];
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
                            ConvertTypes.Menu();
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

        public static void FilePathSave()
        {
            Console.Clear();
            Console.WriteLine("\t\tFILE SYSTEM SAVING\n");
            //We accept the path from the user, followed by input validation
            Console.Write("Enter a filename to save: ");
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    string fileName = input + ConvertTypes.TypeNewFile;
                    TargetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\" + fileName);
                    FileOpenWrite(ConvertTypes.TypeNewFile!.Split('.')[1]);
                    break;
                }
                else
                {
                    Console.WriteLine("\n[ERROR]: Invalid input");
                    Console.Write("Retry Enter a filename to save: ");
                }
            }
        }

        private static void FileOpenWrite(string type)
        {
            using (FileStream fileStream = File.Open(TargetFileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter stream = new StreamWriter(fileStream))
                {
                    switch (type)
                    {
                        case "xml":
                            stream.Write(ConvertTypes.XmlDoc);
                            break;
                        case "yaml":
                            stream.Write(ConvertTypes.YamlDoc);
                            break;
                        case "bson":
                            stream.Write(ConvertTypes.BsonDoc);
                            break;
                        case "json":
                            stream.Write(ConvertTypes.JsonDoc);
                            break;
                        default:
                            Console.WriteLine("\n[ERROR]: Invalid input");
                            Console.WriteLine("Unknown format");
                            Task.Delay(2000).Wait();
                            break;
                    }
                }
            }
            FinishMenu();
        }

        private static void FinishMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tFILE SYSTEM FINISH OPERATION\n");
                Console.WriteLine("\n\tThe file has been converted and saved!\n");
                Console.Write("Want to convert another file? (YES - 1, NO - 2): ");
                int var = int.Parse(Console.ReadLine());
                switch (var)
                {
                    case 1:
                        Program.StartMenu();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\n\t[ERROR]: Invalid input");
                        Console.WriteLine("\tTry entering your choice again");
                        Task.Delay(2000).Wait();
                        break;
                }
            }
        }
    }
}
