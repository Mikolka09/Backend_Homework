using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend_Homework.Classes
{
    internal class ConvertTypes
    {
        private static Document? Document { get; set; }
        public static XDocument? XmlDoc { get; private set; }
        public static string? JsonDoc { get; private set; }
        public static string? TypeNewFile { get; private set; }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("\t\tTYPE CONVERSION MENU\n");
            Console.WriteLine("\tWhat format to convert the document to:\n" +
                "\t1. JSON\n\t2. BSON\n\t3. YAML\n\t4. XML\n\t5. Back to \"Start Menu\"\n\t6. Exit\n");
            Console.Write("\tPlease, your choice: ");
            int var = int.Parse(Console.ReadLine());
            switch (var)
            {
                case 1:
                    ConvertToJSON();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    Program.StartMenu();
                    break;
                case 6:
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

        private static void ParsingToDocument()
        {
            Document = new Document();
            switch (FileSystemWork.TypeFile)
            {
                case "xml":
                    var xdoc = XDocument.Parse(FileSystemWork.TextDocument);
                    if (xdoc.Root is not null)
                    {
                        Document.Title = xdoc.Root.Element("title")!.Value;
                        Document.Text = xdoc.Root.Element("text")!.Value;
                    }
                    break;
                case "yaml":
                    break;
                case "bson":
                    break;
                default:
                    break;
            }
        }

        private static void ConvertToJSON()
        {
            ParsingToDocument();
            JsonDoc = JsonConvert.SerializeObject(Document);
            TypeNewFile = "." + "json";
            FileSystemWork.FilePathSave();
        }
    }
}
