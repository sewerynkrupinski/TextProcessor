using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "I am the one who knows the words";
            string phrase = "the words i am the one who knows";
            var result = TextProcessor(pattern, phrase);

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

        private static bool TextProcessor(string pattern, string word)
        {
            if (word == null)
            {
                return false;
            }
            else
            {
                string result = string.Empty;
                var joined = string.Join(" ", pattern.ToLower());
                string[] splittedText = joined.Split(' ');
                var sortedSplittedText = splittedText.OrderByDescending(x => x.Length).ToArray();

                var joinedWord = string.Join(" ", word);
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
