namespace Hangman.Tests
{
    using HangMan.GameLogic;
    using HangMan.GameObjects;
    using HangMan.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class DefaultGameLogicTests
    {
        [TestCase]
        public void DefaultGameLogicShouldNotBeNullOnCreation()
        {
            var gameLogic = new DefaultGameLogic();

            Assert.NotNull(gameLogic);
        }

        [TestCase]
        public void CurrentPlayerInfoShouldNotBeNullOnDefaultGameLogicCreation()
        {
            var gameLogic = new DefaultGameLogic();

            Assert.NotNull(gameLogic.CurrentPlayerInfo);
        }

        [TestCase]
        public void PlayerShouldNotBeNullOnDefaultGameLogicCreation()
        {
            var gameLogic = new DefaultGameLogic();

            Assert.NotNull(gameLogic.Player);
        }

        [TestCase]
        public void IsCheatedShouldFalseOnDefaultGameLogicCreation()
        {
            var gameLogic = new DefaultGameLogic();

            Assert.IsFalse(gameLogic.IsCheated);
        }

        [TestCase]
        public void GameStateShouldBeOfTypeGameState()
        {
            var gameLogic = new DefaultGameLogic();

            Assert.That(gameLogic.GameState, Is.TypeOf(typeof(GameState)));
        }

        [TestCase]
        public void CurrentPlayerInfoShouldBeOfTypeGameInfo()
        {
            var gameLogic = new DefaultGameLogic();

            Assert.That(gameLogic.CurrentPlayerInfo, Is.TypeOf(typeof(GameInfo)));
        }

        [TestCase]
        public void PlayerShouldBeOfTypePlayer()
        {
            var gameLogic = new DefaultGameLogic();

            Assert.That(gameLogic.Player, Is.TypeOf(typeof(Player)));
        }
    }
}
