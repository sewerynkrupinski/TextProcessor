using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pattern - the phrase should look like given below
            string pattern = "<Text>i am the one who knows the words</Text>";
            //Recognized pharee - the phrase looks like given below (wrong words order, multiple lines based on <Text> tags
            string phrase = "<Text>the words</Text><Text>i am the one who knows</Text>";
            //Text separators (like tags)
            string[] separators = { "<Text>", "</Text>" };

            var result = TextProcessor(pattern, phrase, separators);

            if(result)
            {
                Console.WriteLine("The pattern and a given phrase contain the same words");
            }
            else
            {
                Console.WriteLine("The pattern and a given phrase does not contain the same words");
            }

            Console.ReadKey();
        }

        private static bool TextProcessor(string pattern, string phrase, string[] separators)
        {
            if (phrase == null)
            {
                return false;
            }
            else
            {
                var splittedPattern = pattern.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                var joined = string.Join(" ", splittedPattern);
                string[] splittedText = joined.Split(' ');
                var sortedSplittedText = splittedText.OrderByDescending(x => x.Length).ToArray();

                var splittedPhrase = phrase.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                var joinedWord = string.Join(" ", splittedPhrase);
                var clearedJoinedWord = Regex.Replace(joinedWord, @"\s", "");

                string temp = string.Empty;
                string left = string.Empty;


                foreach (var item in sortedSplittedText)
                {
                    if (clearedJoinedWord.Contains(item))
                    {
                        var regex = new Regex(Regex.Escape(item));
                        temp = regex.Replace(clearedJoinedWord, "", 1);
                        clearedJoinedWord = temp;
                    }
                    else
                    {
                        left += item;
                    }
                }

                if (clearedJoinedWord.Length == 0 && left.Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
