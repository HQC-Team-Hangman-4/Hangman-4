using System;
using Hangman.Tests.Mocks;
using HangMan.GameObjects;
using HangMan.Helpers.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman.Tests
{
    [TestClass]
    public class WordFactoryTests
    {
        private readonly IWordDatabase dbWordDatabase;
        private WordFactory wordFactory;

        public WordFactoryTests()
            : this(new JustMockWordDatabase())
        //Since Moq does not have It.IsNotNullOrEmpty the outcome may be different
        //: this(new MoqCarsRepository())
        {
        }

        private WordFactoryTests(WordDataBaseMock dbWordDataBaseMock)
        {
            this.dbWordDatabase = dbWordDataBaseMock.db;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.wordFactory = new WordFactory(this.dbWordDatabase);
        }


        [TestMethod]
        public void GetWordShouldWorkPropperlyWhenValidInput()
        {
            var itWord = wordFactory.GetWord(Categories.IT);
            var astronWord = wordFactory.GetWord(Categories.Astronomy);
            var bioWord = wordFactory.GetWord(Categories.Biology);
            var geoWord = wordFactory.GetWord(Categories.Geography);

            Assert.IsNotNull(itWord);
            Assert.IsNotNull(astronWord);
            Assert.IsNotNull(bioWord);
            Assert.IsNotNull(geoWord);
        }
    }
}
