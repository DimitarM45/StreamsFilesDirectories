namespace FolderSize
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

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
            IterateThroughDirectory("../../../");
        }

        private static void IterateThroughDirectory(string path)
        {
            
            string[] dirs = Directory.GetDirectories(path);

            foreach (string dir in dirs)
            {

                IterateThroughDirectory(path);
            }
        }
    }
}
