namespace Hangman.Tests
{
    using System;
    using Hangman.Tests.Mocks;
    using HangMan.GameObjects;
    using HangMan.Helpers.Data;
    using NUnit.Framework;

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
            this.dbWordDatabase = dbWordDataBaseMock.DB;
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
            var word = this.wordFactory.GetWord(category);

            Assert.IsNotNull(word);
            Assert.IsNotNull(word.Content);
        }

        [ExpectedException(typeof(ArgumentException))]
        public void GetWordShouldThrowArgumentExceptionWhenWordOfThatCategoryIsNotFound()
        {
            var geoWord = this.wordFactory.GetWord(Categories.Geography);
        }
    }
}
