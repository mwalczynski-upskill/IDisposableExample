using System;
using System.IO;

namespace IDisposableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var myFileName = "myFile.txt";
            CreateMyFile(myFileName);
            var myFileReader = new MyFileReader(myFileName);
            try
            {
                var myfileContent = myFileReader.ReadFromFile();
                Console.WriteLine(myfileContent);
                myFileReader.Dispose();
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var myfileContent = myFileReader.ReadFromFile(); // will fail here
                Console.WriteLine(myfileContent);
                myFileReader.Dispose();
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static void CreateMyFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write("This is the content of my file.");
            }
        }
    }

}
