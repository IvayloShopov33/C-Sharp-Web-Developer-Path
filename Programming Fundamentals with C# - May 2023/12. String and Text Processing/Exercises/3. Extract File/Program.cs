using System;

namespace _3._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filePath = Console.ReadLine().Split("\\");
            string fileExtension, fileName;
            InitializeFileNameAndHisExtension(filePath, out fileExtension, out fileName);
            PrintFileNameAndHisExtension(fileExtension, fileName);
        }

        static void InitializeFileNameAndHisExtension(string[] filePath, out string fileExtension, out string fileName)
        {
            string fileNameWithHisExtension = filePath[filePath.Length - 1];
            int indexOfDot = fileNameWithHisExtension.IndexOf('.');
            fileExtension = fileNameWithHisExtension.Substring(indexOfDot + 1);
            fileName = fileNameWithHisExtension.Remove(indexOfDot);
        }

        static void PrintFileNameAndHisExtension(string fileExtension, string fileName)
        {
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
