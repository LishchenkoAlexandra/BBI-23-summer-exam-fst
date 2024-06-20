using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Variant_5
{
    public class Task3
    {
        public class Statistic
        {
            public string Input { get; private set; }
            public double Output { get; private set; }

            public Statistic(string text)
            {
                Input = text ?? string.Empty; 
                Output = CalculateAverageSyllablesPerWord(Input);
            }

            private double CalculateAverageSyllablesPerWord(string text)
            {
                if (string.IsNullOrEmpty(text)) return 0;

                char[] delimiters = { ' ', '.', ',', '!', '?', ';', ':', '-', 'r', 'n', 't' };
                string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                int totalSyllables = 0;
                int wordCount = 0;

                foreach (string word in words)
                {
                    if (HasLetter(word))
                    {
                        totalSyllables += CountSyllables(word);
                        wordCount++;
                    }
                }

                return wordCount == 0 ? 0 : (double)totalSyllables / wordCount;
            }

            private bool HasLetter(string word)
            {
                foreach (char c in word)
                {
                    if (char.IsLetter(c))
                    {
                        return true;
                    }
                }
                return false;
            }

            private int CountSyllables(string word)
            {
                int syllableCount = 0;
                bool lastCharWasVowel = false;

                foreach (char c in word.ToLower())
                {
                    if (IsVowel(c))
                    {
                        if (!lastCharWasVowel)
                        {
                            syllableCount++;
                        }
                        lastCharWasVowel = true;
                    }
                    else
                    {
                        lastCharWasVowel = false;
                    }
                }

                return Math.Max(syllableCount, 1);
            }

            private bool IsVowel(char c)
            {
                string vowels = "aeiouyаеёиоуыэюя";
                return vowels.IndexOf(c) >= 0;
            }

            public override string ToString()
            {
                string formattedOutput = Output.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
                formattedOutput = formattedOutput.Replace('.', ',');
                return formattedOutput;
            }
        }
    }
}
