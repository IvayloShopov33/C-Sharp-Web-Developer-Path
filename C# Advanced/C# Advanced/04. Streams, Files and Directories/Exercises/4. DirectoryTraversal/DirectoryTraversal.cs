using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, Dictionary<string, decimal>> filesNamesWithTheirSizes = new Dictionary<string, Dictionary<string, decimal>>();
            string[] files = Directory.GetFiles(inputFolderPath);
            foreach (string file in files)
            {
                int indexOfDot = file.IndexOf('.');
                string extension = file.Substring(indexOfDot);
                if (!filesNamesWithTheirSizes.ContainsKey(extension))
                {
                    filesNamesWithTheirSizes.Add(extension, new Dictionary<string, decimal>());
                }

                decimal fileSize = new FileInfo(file).Length / 1024.0m;
                filesNamesWithTheirSizes[extension].Add(file, fileSize);
            }

            string output = string.Empty;
            foreach (var extensions in filesNamesWithTheirSizes.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                output += extensions.Key;
                foreach (var filesWithTheirSizes in extensions.Value.OrderBy(x => x.Value))
                {
                    output += $"--{filesWithTheirSizes.Key} - {filesWithTheirSizes.Value}kb";
                }
            }

            return output;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            File.WriteAllText(reportFileName, textContent);
        }
    }
}
