using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            //convert the total sum from bytes to kilobytes
            decimal sumOfFileSizes = CalculateTotalSumOfFileSizes(folderPath) / 1024.0m;
            string outputText = $"{sumOfFileSizes} KB";
            File.WriteAllText(outputFilePath, outputText);

        }

        static long CalculateTotalSumOfFileSizes(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);
            long totalSumOfFileSizes = 0;
            //add the sizes of files and directories to the total sum
            foreach (string file in files)
            {
                totalSumOfFileSizes += new FileInfo(file).Length;
            }
            
            string[] subDirectories = Directory.GetDirectories(folderPath);
            foreach (string subDirectory in subDirectories)
            {
                totalSumOfFileSizes += CalculateTotalSumOfFileSizes(subDirectory);
            }

            return totalSumOfFileSizes;
        }
    }
}
