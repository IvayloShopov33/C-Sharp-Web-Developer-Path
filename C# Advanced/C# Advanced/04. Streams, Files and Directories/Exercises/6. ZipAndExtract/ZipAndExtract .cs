using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"C:\Users\plame\Desktop\My folder";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\result";

            ZipFileToArchive(inputFile, zipArchiveFile);

            ExtractFileFromArchive(zipArchiveFile, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            ZipFile.CreateFromDirectory(inputFilePath, zipArchiveFilePath);
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string outputFilePath)
        {
            ZipFile.ExtractToDirectory(zipArchiveFilePath, outputFilePath);
        }
    }
}
