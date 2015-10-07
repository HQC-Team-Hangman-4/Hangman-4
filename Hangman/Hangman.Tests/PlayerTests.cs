namespace Hangman.Tests
{
    using System;
    using Hangman.Tests.Mocks;
    using HangMan.GameObjects;
    using HangMan.Helpers.Data;
    using NUnit.Framework;

    [TestFixture]
    public class PlayerTests
    {
        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameShouldThrowArgumentNullExceptionWhenProvidedNullData()
        {
            var player = new Player();
            player.Name = null;
        }

        [TestCase("A", ExpectedException = typeof(ArgumentException))]
        [TestCase("", ExpectedException = typeof(ArgumentException))]
        [TestCase(" ", ExpectedException = typeof(ArgumentException))]
        [TestCase("ASD", ExpectedException = typeof(ArgumentException))]
        public void NameShouldThrowArgumentExceptionWhenProvidedShortName(string invalidName)
        {
            var player = new Player();
            player.Name = invalidName;
        }


        [TestCase("AAAAAAAAAAAAAAAAAAAA", ExpectedException = typeof(ArgumentException))]
        [TestCase("KARAKONDJULKARABABADOGARATA", ExpectedException = typeof(ArgumentException))]
        public void NameShouldThrowArgumentExceptionWhenProvidedLongName(string invalidName)
        {
            var player = new Player();
            player.Name = invalidName;
        }

        [TestCase("Ivan", Result = "Ivan")]
        [TestCase("Kartel", Result = "Kartel")]
        [TestCase("Saviour", Result = "Saviour")]
        [TestCase("KiseloZele", Result = "KiseloZele")]
        [TestCase("Baghdad", Result = "Baghdad")]
        public string NameShouldWorkWhenProvidedValidData(string name)
        {
            var player = new Player();
            player.Name = name;

            Assert.IsNotNull(player);
            Assert.IsNotNull(player.Name);
            return player.Name;
        }


        [TestCase(5, Result = 5)]
        [TestCase(125, Result = 125)]
        [TestCase(0, Result = 0)]
        [TestCase(500, Result = 500)]
        [TestCase(350, Result = 350)]
        public int ScoreShouldWorkWhenProvidedValidData(int score)
        {
            var player = new Player();
            player.Score = score;
            return player.Score;
        }

        [TestCase(1001, ExpectedException = typeof(ArgumentException))]
        [TestCase(int.MaxValue, ExpectedException = typeof(ArgumentException))]
        [TestCase(1500000, ExpectedException = typeof(ArgumentException))]
        [TestCase(10000000, ExpectedException = typeof(ArgumentException))]
        public void ScoreShouldThrowArgumentExceptionWhenProvidedTooBigScore(int score)
        {
            var player = new Player();
            player.Score = score;
        }

        [TestCase(-15, ExpectedException = typeof(ArgumentException))]
        [TestCase(-100000, ExpectedException = typeof(ArgumentException))]
        [TestCase(int.MinValue, ExpectedException = typeof(ArgumentException))]
        [TestCase(-1, ExpectedException = typeof(ArgumentException))]
        public void ScoreShouldThrowArgumentExceptionWhenProvidedNegativeScore(int score)
        {
            var player = new Player();
            player.Score = score;
        }
    }
}
