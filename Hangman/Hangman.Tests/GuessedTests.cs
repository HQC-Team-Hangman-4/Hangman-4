using System;
using System.Text;
using Hangman.Tests.Mocks;
using HangMan.GameObjects;
using HangMan.Helpers.Data;
using NUnit.Framework;

namespace Hangman.Tests
{
    [TestFixture]
    public class GuessedTests
    {
        
        private readonly IWordDatabase dbWordDatabase;
        private WordFactory wordFactory;

        public GuessedTests()
            : this(new JustMockWordDatabase())
        {
        }

        private GuessedTests(WordDataBaseMock dbWordDataBaseMock)
        {
            this.dbWordDatabase = dbWordDataBaseMock.db;
        }

        [TestFixtureSetUp]
        public void CreateFactory()
        {
            this.wordFactory = new WordFactory(this.dbWordDatabase);
        }

        [TestCase("Ivan", 150)]
        [TestCase("Vasil", 0)]
        [TestCase("Martin", 450)]
        [TestCase("John", 900)]
        public void GuessedShouldWorkProperlyWhenPassedValidPlayer(string name, int score)
        {
            var player = new Player();
            player.Name = name;
            player.Score = score;

            var guessedPlayer = new Guessed(player);
            var guessedBody = guessedPlayer.GetBody();

            var expectedSb = new StringBuilder();
            expectedSb.AppendLine(new string('-', player.GetBody().Length + 2));
            expectedSb.AppendLine('|' + player.GetBody() + '|');
            expectedSb.AppendLine(new string('-', player.GetBody().Length + 2));

            var expected = expectedSb.ToString();
            Assert.AreEqual(expected, guessedBody);

        }

        [TestCase(Categories.IT)]
        [TestCase(Categories.IT)]
        [TestCase(Categories.IT)]
        [TestCase(Categories.Biology)]
        [TestCase(Categories.Biology)]
        [TestCase(Categories.Astronomy)]
        public void GuessedShouldWorkProperlyWhenPassedValidWord(Categories category)
        {
            var word = wordFactory.GetWord(category);

            var guessedWord = new Guessed(word);
            var guessedBody = guessedWord.GetBody();

            var expectedSb = new StringBuilder();
            expectedSb.AppendLine(new string('-', word.GetBody().Length + 2));
            expectedSb.AppendLine('|' + word.GetBody() + '|');
            expectedSb.AppendLine(new string('-', word.GetBody().Length + 2));
            
            var expected = expectedSb.ToString();

            Assert.AreEqual(expected, guessedBody);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GuessedShouldThrowArgumentNullExceptionWhenPassedNullData()
        {
            var guessedNull = new Guessed(null);
        }
    }
}
