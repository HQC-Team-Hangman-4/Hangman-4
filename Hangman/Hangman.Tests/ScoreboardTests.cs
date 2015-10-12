namespace Hangman.Tests
{
    using HangMan.GameObjects;
    using NUnit.Framework;

    [TestFixture]
    public class ScoreboardTests
    {
        [TestCase]
        public void ScoreboardInstanceShouldNotBeNull()
        {
            var scoreboard = Scoreboard.Instance;

            Assert.NotNull(scoreboard);
        }
    }
}
