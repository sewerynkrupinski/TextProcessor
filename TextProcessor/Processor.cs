using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TextProcessor
{
    public class Processor
    {
        public bool TextProcessor(string pattern, string phrase, string[] separators)
        {
            if (phrase == null)
            {
                return false;
            }
            else
            {
                string[] splittedPattern;
                string joined;

                string[] splittedPhrase;
                string joinedWord;

                if (separators.Length >0)
                {
                    splittedPattern = pattern.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    joined = string.Join(" ", splittedPattern);

                    splittedPhrase = phrase.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    joinedWord = string.Join(" ", splittedPhrase);
                }
                else
                {
                    joined = pattern;
                    joinedWord = phrase;
                }
                
                string[] splittedText = joined.Split(' ');
                var sortedSplittedText = splittedText.OrderByDescending(x => x.Length).ToArray();
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
