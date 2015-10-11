using HangMan.Engine;

namespace Hangman.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class GlobalTests
    {
        [TestCase]
        public void GameShouldNotThrowWhenStarted()
        {
            HangmanFascade.Start();
        }
    }
}
