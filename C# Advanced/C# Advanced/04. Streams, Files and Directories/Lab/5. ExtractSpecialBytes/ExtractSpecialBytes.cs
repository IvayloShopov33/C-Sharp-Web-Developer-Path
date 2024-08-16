using System.IO;

namespace ExtractSpecialBytes
{
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using FileStream fileReader = new FileStream(bytesFilePath, FileMode.Open, FileAccess.Read, FileShare.None);
            using FileStream fileWriter = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None);

            byte[] bytes = new byte[fileReader.Length];
            fileReader.Read(bytes);
            fileWriter.Write(bytes);
        }
    }
}
