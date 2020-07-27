using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextProcessor;

namespace TextProcessorTest
{
    [TestClass]
    public class TextProcessorTest
    {
        [TestMethod]
        public void SimpleTest()
        {
            //Arrange
            var program = new Processor();
            string[] separators = { "<Text>", "</Text>" };
            //Act
            bool result = program.TextProcessor("Alice has a cat", "cat has a Alice", separators);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenPhraseTest()
        {
            var program = new Processor();
            string pattern = "<Text>i am the one who knows the words</Text>";
            string phrase = "<Text>the words</Text><Text>i am the one who knows</Text>";
            string[] separators = { "<Text>", "</Text>" };
            var result = program.TextProcessor(pattern, phrase, separators);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WithoutSeparatorsTest()
        {
            var program = new Processor();
            string pattern = "i am the one who knows the words";
            string phrase = "the words i am the one who knows";
            string[] separators = {};
            var result = program.TextProcessor(pattern, phrase, separators);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EmptyStringsTest()
        {
            var program = new Processor();
            string pattern = string.Empty;
            string phrase = string.Empty;
            string[] separators = { };
            var result = program.TextProcessor(pattern, phrase, separators);
            Assert.IsTrue(result);
        }

    }
}
