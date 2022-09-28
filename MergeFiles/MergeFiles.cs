namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            string[] firstFileLines = File.ReadAllLines(firstInputFilePath);
            string[] secondFileLines = File.ReadAllLines(secondInputFilePath);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                for (int i = 0; i < Math.Min(firstFileLines.Length, secondFileLines.Length); i++)
                {
                    writer.WriteLine(firstFileLines[i]);
                    writer.WriteLine(secondFileLines[i]);
                }

                if (firstFileLines.Length > secondFileLines.Length)
                {
                    for (int i = firstFileLines.Length - secondFileLines.Length; i < firstFileLines.Length; i++)
                        writer.WriteLine(firstFileLines[i]);
                }
                else if (secondFileLines.Length > firstFileLines.Length)
                {
                    for (int i = secondFileLines.Length - firstFileLines.Length; i < secondFileLines.Length; i++)
                        writer.WriteLine(secondFileLines[i]);
                }
            }
        }
    }
}
