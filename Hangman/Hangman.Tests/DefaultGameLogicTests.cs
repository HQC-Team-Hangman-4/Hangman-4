namespace Hangman.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using HangMan.GameLogic;
    using HangMan.GameObjects;
    using HangMan.Helpers;
    using HangMan.Interfaces;

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
