using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using SharpYaml.Serialization;



namespace Backend_Homework.Classes
{
    public class ConvertTypes
    {
        public static Document? Doc { get; set; } = new Document();
        public static string? XmlDoc { get; private set; }
        public static string? JsonDoc { get; private set; }
        public static string? BsonDoc { get; private set; }
        public static string? YamlDoc { get; private set; }
        public static string? TypeNewFile { get; private set; }

        //conversion menu for types
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
                    ConvertToBSON();
                    break;
                case 3:
                    ConvertToYAML();
                    break;
                case 4:
                    ConvertToXML();
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

        //parsing a string into a document object
        private static void ParsingToDocument()
        {
            string? input = FileSystemWork.TextDocument;
            string? type = FileSystemWork.TypeFile;
            switch (type)
            {
                case "xml":
                    ParsingXmlToDocument(input);
                    break;
                case "yaml":
                    ParsingYamlToDocument(input);
                    break;
                case "bson":
                    ParsingBsonToDocument(input);
                    break;
                case "json":
                    ParsingJsonToDocument(input);
                    break;
                default:
                    break;
            }
        }


        //parsing a xml into a document object
        public static void ParsingXmlToDocument(string? input)
        {
            var xdoc = XDocument.Parse(input);
            if (xdoc.Root is not null)
            {
                Doc.Title = xdoc.Root.Element("title")!.Value;
                Doc.Text = xdoc.Root.Element("text")!.Value;
            }
        }

        //parsing a yaml into a document object
        public static void ParsingYamlToDocument(string? input)
        {
            var yamlSerializer = new Serializer();
            Doc = yamlSerializer.Deserialize<Document>(input);
        }

        //parsing a bson into a document object
        public static void ParsingBsonToDocument(string? input)
        {
            byte[] bytes = Convert.FromBase64String(input);
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                using (BsonDataReader reader = new BsonDataReader(ms))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    Doc = serializer.Deserialize<Document>(reader);
                }
            }
        }

        //parsing a json into a document object
        public static void ParsingJsonToDocument(string? input)
        {
            dynamic? jdoc = JsonConvert.DeserializeObject(input);
            if (jdoc != null)
            {
                Doc.Title = jdoc.Title;
                Doc.Text = jdoc.Text;
            }
        }

        //converting a document object into a format json
        private static void ConvertToJSON()
        {
            ParsingToDocument();
            JsonDoc = JsonConvert.SerializeObject(Doc);
            TypeNewFile = "." + "json";
            MenuSave();
        }

        //converting a document object into a format xml
        private static void ConvertToXML()
        {
            ParsingToDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, Doc);
                XmlDoc = writer.ToString();
            }
            TypeNewFile = "." + "xml";
            MenuSave();
        }

        //converting a document object into a format bson
        private static void ConvertToBSON()
        {
            ParsingToDocument();
            using (MemoryStream memory = new MemoryStream())
            {
                using (BsonDataWriter writer = new BsonDataWriter(memory))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(writer, Doc);
                }
                BsonDoc = Convert.ToBase64String(memory.ToArray());
            }
            TypeNewFile = "." + "bson";
            MenuSave();
        }

        //converting a document object into a format yaml
        private static void ConvertToYAML()
        {
            ParsingToDocument();
            var yamlSerializer = new Serializer();
            YamlDoc = yamlSerializer.Serialize(Doc);
            TypeNewFile = "." + "yaml";
            MenuSave();
        }

        //menu for selecting the type of saving the converted document
        private static void MenuSave()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tMENU SELECT SAVE DESTINATION\n");
                Console.WriteLine("\tChoose where to save data:\n" +
                    "\t1. File system\n\t2. Cloud Storage\n\t3. HTTP Storage\n\t4. Back to \"Conversion Menu\"\n\t5. Exit\n");
                Console.Write("\tPlease, your choice: ");
                int var = int.Parse(Console.ReadLine());
                switch (var)
                {
                    case 1:
                        FileSystemWork.FilePathSave();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n\n\tSorry, this method is under development!");
                        Task.Delay(2000).Wait();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\n\n\tSorry, this method is under development!");
                        Task.Delay(2000).Wait();
                        break;
                    case 4:
                        Menu();
                        break;
                    case 5:
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
