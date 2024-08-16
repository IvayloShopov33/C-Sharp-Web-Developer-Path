using System;
using System.IO;

namespace CopyDirectory
{
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            string[] filesToMove = Directory.GetFiles(inputPath);
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            File.Create(outputPath);
            foreach (string file in filesToMove)
            {
                File.Move(file, outputPath);
            }
        }
    }
}
