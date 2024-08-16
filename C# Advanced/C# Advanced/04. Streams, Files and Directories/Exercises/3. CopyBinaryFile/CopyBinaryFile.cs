using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream fileStreamReader = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.None);
            using FileStream fileStreamWriter = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.None);

            byte[] bufferData = new byte[fileStreamReader.Length];
            fileStreamReader.Read(bufferData);
            fileStreamWriter.Write(bufferData);

        }
    }
}
