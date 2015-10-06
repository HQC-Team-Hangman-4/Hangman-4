using System;
using Hangman.Tests.Mocks;
using HangMan.GameObjects;
using HangMan.Helpers.Data;
using NUnit.Framework;

namespace Hangman.Tests
{
    [TestFixture]
    public class WordFactoryTests
    {
        private readonly IWordDatabase dbWordDatabase;
        private WordFactory wordFactory;

        public WordFactoryTests()
            : this(new JustMockWordDatabase())
        {
        }

        private WordFactoryTests(WordDataBaseMock dbWordDataBaseMock)
        {
            this.dbWordDatabase = dbWordDataBaseMock.db;
        }

        [TestFixtureSetUp]
        public void CreateController()
        {
            this.wordFactory = new WordFactory(this.dbWordDatabase);
        }


        [TestCase(Categories.Astronomy)]
        [TestCase(Categories.Biology)]
        [TestCase(Categories.IT)]
        public void GetWordShouldWorkPropperlyWhenValidInput(Categories category)
        {
            var word = wordFactory.GetWord(category);

            Assert.IsNotNull(word);
            Assert.IsNotNull(word.Content);
        }

        [TestCase()]
        [ExpectedException(typeof(ArgumentException))]
        public void GetWordShouldThrowArgumentExceptionWhenWordOfThatCategoryIsNotFound()
        {
            var geoWord = wordFactory.GetWord(Categories.Geography);
        }
    }
}
