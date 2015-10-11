namespace Hangman.Tests
{
    using HangMan.GameObjects;
    using NUnit.Framework;

    [TestFixture]
    public class GameInfoTests
    {
        [TestCase]
        public void GameInfoShouldNotBeNullWhenInstantiated()
        {
            var gameInfo = new GameInfo();

            Assert.IsNotNull(gameInfo);
        }

        [TestCase]
        public void MistakesShouldNBeZeroWhenGameInfoCreated()
        {
            var gameInfo = new GameInfo();

            int expected = 0;
            int actual = gameInfo.Mistakes;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void UsedLettersShouldNBeZeroWhenGameInfoCreated()
        {
            var gameInfo = new GameInfo();

            int expected = 0;
            int actual = gameInfo.UsedLetters.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
