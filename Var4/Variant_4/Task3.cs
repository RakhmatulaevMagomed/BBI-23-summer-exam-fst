using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Variant_4
{

    public class Task3
    {
        public class Uniques
        {
            private string input;
            private string[] output;

            public string Input
            {
                get { return input; }
            }

            public string[] Output
            {
                get { return output; }
            }

            public Uniques(string text)
            {
                input = text;
                output = FindUniqueWords(input);
            }

            private string[] FindUniqueWords(string text)
            {
                if (string.IsNullOrEmpty(text))
                {
                    return new string[0];
                }

                var words = text.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                var uniqueWords = new List<string>();

                foreach (var word in words)
                {
                    var lowerWord = word.ToLower();
                    if (lowerWord.Length > 1 && IsUnique(lowerWord))
                    {
                        uniqueWords.Add(word);
                    }
                }

                return uniqueWords.ToArray();
            }

            private bool IsUnique(string word)
            {
                var charSet = new List<char>();
                foreach (var ch in word)
                {
                    if (charSet.Contains(ch))
                    {
                        return false;
                    }
                    charSet.Add(ch);
                }
                return true;
            }

            public override string ToString()
            {
                return output.Length > 0 ? string.Join(Environment.NewLine, output) : string.Empty;
            }
        }

    }
}

