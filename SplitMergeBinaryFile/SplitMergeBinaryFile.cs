namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

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
            FileInfo sourceFile = new FileInfo(sourceFilePath);

            int sizeDiscrepancy = sourceFile.Length % 2 == 0 ? 0 : 1;

            byte[] buffer = new byte[512];

            using (FileStream reader = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (FileStream writer = new FileStream(partOneFilePath, FileMode.Create))
                {
                    while (true)
                    {
                        int size = reader.Read(buffer, 0, buffer.Length / 2 + sizeDiscrepancy);

                        if (size == 0) break;

                        writer.Write(buffer, 0, buffer.Length);
                    }
                }

                using (FileStream writer = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    while (true)
                    {
                        int size = reader.Read(buffer, buffer.Length / 2 + sizeDiscrepancy, buffer.Length / 2 - sizeDiscrepancy);

                        if (size == 0) break;

                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            FileInfo partOneFile = new FileInfo(partOneFilePath);
            FileInfo partTwoFile = new FileInfo(partTwoFilePath);

            byte[] buffer = new byte[512];

            using (FileStream writer = new FileStream(joinedFilePath, FileMode.Append))
            {
                using (FileStream reader = new FileStream(partOneFilePath, FileMode.Open))
                {
                    while (true)
                    {
                        int size = reader.Read(buffer, 0, buffer.Length);

                        if (size == 0) break;

                        writer.Write(buffer, 0, buffer.Length);
                    }
                }

                using (FileStream reader = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    while (true)
                    {
                        int size = reader.Read(buffer, 0, buffer.Length);

                        if (size == 0) break;

                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}