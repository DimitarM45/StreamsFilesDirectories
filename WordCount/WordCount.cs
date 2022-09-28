namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Runtime.CompilerServices;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            string[] wordsToMatch = File.ReadAllText(wordsFilePath).Split();

            Regex wordRegex = new Regex(@"[A-Za-z]+");

            string textFile = File.ReadAllText(textFilePath);

            List<Match> matchedWords = wordRegex.Matches(textFile).ToList();

            Dictionary<string, int> wordsByCount = new Dictionary<string, int>();

            foreach (string word in wordsToMatch)
            {
                if (!wordsByCount.ContainsKey(word))
                    wordsByCount.Add(word, 0);

                int count = 0;

                foreach (Match matchedWord in matchedWords)
                    if (word == matchedWord.ToString().ToLower()) count++;
                
                wordsByCount[word] = count;
            }

            wordsByCount = wordsByCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var (word, count) in wordsByCount)
                    writer.WriteLine($"{word} - {count}");
            }
        }
    }
}
