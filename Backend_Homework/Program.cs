using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Xml.Linq;
using Backend_Homework.Classes;
using Newtonsoft.Json;
namespace Backend_Homework
{
    #region old buggy code
    //it is better to create a class in a separate file but in the same space, and call the file the name of the class
    /*public class Document
    {
        //perhaps it should be added that the property can be null - "public string? Title { get; set; }"
        public string Title { get; set; }

        //perhaps it should be added that the property can be null - "public string? Text { get; set; }"
        public string Text { get; set; }
    }*/
    #endregion
    class Program
    {

        public static void StartMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tWELCOME TO THE CONVERT APPLICATION\n");
                Console.WriteLine("\tChoose which data store you will work with:\n" +
                    "\t1. File system\n\t2. Cloud Storage\n\t3. HTTP Storage\n\t4. Exit\n");
                Console.Write("\tPlease, your choice: ");
                int var = int.Parse(Console.ReadLine());
                switch (var)
                {
                    case 1:
                        FileSystemWork.Menu();
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

        static void Main(string[] args)
        {
           
            StartMenu();

            #region old buggy code
            //the folder and file were not created at the given path, it will throw an exception "FileNotFoundException"
            /*var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml");

            //the folder has not been created at the given path, it will give an error when trying to write a file to this folder
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");
            try
            {
                //at the beginning, you need to check for the existence of a file along this path so that an exception
                //does not pop up in this way: if(File.Exists(sourceFileName)){}, and if such a file exists, then open it

                FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
                var reader = new StreamReader(sourceStream);

                //the "input" string must be declared before try, as it will not be available to subsequent code (it is not in scope)
                string input = reader.ReadToEnd();

                //you need to close the FileStream.Close() and StreamReader.Close() streams here in "try", since in the future
                //the next opening of the stream or accessing the file will lead to an error, or instead of "try{}catch{}"
                //use the "using(){}", which will automatically release all thread-related resources

            }
            catch (Exception ex)
            {
                //very bad option, it loses the original stack trace of the exception, as well as its type, this will destroy
                //all information about the exception
                throw new Exception(ex.Message);
            }

            //the string "input" is not visible because it is not visible
            var xdoc = XDocument.Parse(input);

            //first you need to check "xdoc.Root" for "is not null"
            var doc = new Document()
            {
                //when dereferencing a variable whose value is null, the runtime will throw an exception.
                //To do this, you need before the operator "." put the negation operator "!" NULL
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };
          
            var serializedDoc = JsonConvert.SerializeObject(doc);

            //you need to work with streams in "try{}catch{}" and close the streams, or immediately use the "using(){}" construct,
            //which will automatically release all resources associated with the streams. Also, if the streams are not closed,
            //the information will not be written to the file.
            //And it's better to use the method - "File.WriteAllText(targetFileName, serializedDoc)"

            var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
            var sw = new StreamWriter(targetStream);
            sw.Write(serializedDoc);*/
            #endregion
        }
    }
}