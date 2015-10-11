namespace Hangman.Tests
{
    using System;
    using HangMan.GameObjects;
    using NUnit.Framework;
    using Telerik.JustMock;
    using HangMan.Interfaces;

    [TestFixture]
    public class ScoreboardTests
    {

        [TestCase]
        public void ScoreboardInstanceShouldNotBeNull()
        {
            var scoreboard = Scoreboard.Instance;

            Assert.NotNull(scoreboard);
        }

        [TestCase]
        public void AddPlayerScoreShouldNotThrowWhenValidPlayer()
        {
            var playerMock = Mock.Create<IPlayer>();
            playerMock.Name = "Johnny";
            playerMock.Score = 10;
            var scoreboard = Scoreboard.Instance;

            Assert.DoesNotThrow(() => scoreboard.AddPlayerScore(playerMock));
        }

        [TestCase]
        public void ViewScoreboardShouldNotThrowWhenValidData()
        {
            var playerMock = Mock.Create<IPlayer>();
            playerMock.Name = "Johnny";
            playerMock.Score = 10;
            var scoreboard = Scoreboard.Instance;
            scoreboard.AddPlayerScore(playerMock);

            Assert.DoesNotThrow(() => scoreboard.ViewScoreboard());
        }
    }
}
