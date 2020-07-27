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

            var processor = new Processor();
            var result = processor.TextProcessor(pattern, phrase, separators);

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

        
    }
}
