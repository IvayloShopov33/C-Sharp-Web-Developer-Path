using System;
using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using FileStream fileStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read);
            using FileStream partOneFile = new FileStream(partOneFilePath, FileMode.Create, FileAccess.Write);
            using FileStream partTwoFile = new FileStream(partTwoFilePath, FileMode.Create, FileAccess.Write);

            byte[] data = new byte[fileStream.Length];
            fileStream.Read(data);
            
            double fileLengthSplitted = fileStream.Length / 2;
            int partOneFileLength = (int)Math.Ceiling(fileLengthSplitted);
            int partTwoFileLength = (int)Math.Floor(fileLengthSplitted);

            for (int i = 0; i < partOneFileLength; i++)
            {
                partOneFile.Write(data, i, 1);
            }

            for (int i = partOneFileLength; i < partTwoFileLength + partOneFileLength; i++)
            {
                partTwoFile.Write(data, i, 1);
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using FileStream partOneFile = new FileStream(partOneFilePath, FileMode.Open, FileAccess.Read);
            using FileStream partTwoFile = new FileStream(partTwoFilePath, FileMode.Open, FileAccess.Read);
            using FileStream joinedFile = new FileStream(joinedFilePath, FileMode.Create, FileAccess.Write);

            byte[] data = new byte[partOneFilePath.Length + partTwoFilePath.Length];
            
            partOneFile.Read(data);
            partTwoFile.Read(data);
            
            joinedFile.Write(data);
        }
    }
}
