namespace Hangman.Tests
{
    using System;
    using System.IO;
    using HangMan.Interfaces;
    using HangMan.Renderers;
    using NUnit.Framework;
    using Telerik.JustMock;
    using Hangman.Tests.Mocks;
    using System.Collections.Generic;

    [TestFixture]
    public class ConsoleRendererTests : ConsoleRendererTestsSetup
    {
        [TestCase]
        public void ConsoleRendererShouldNotBeNullWhenInstantiated()
        {
            var consoleRenderer = new ConsoleRenderer();

            Assert.IsNotNull(consoleRenderer);
        }

        [TestCase]
        public void PrintInitialScreenShouldPrintTextContentToConsole()
        {
            var consoleRenderer = new ConsoleRenderer();
            consoleRenderer.PrintInitialScreen();
            this.textWriter.Close();

            string expected = "Welcome to Hangman" + Environment.NewLine + string.Format("Use 'top' to view the top scoreboard," +
            "'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.") + Environment.NewLine;

            string actual = File.ReadAllText("./consolewritertests.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PrintWordShouldPrintWordToConsole()
        {
            var wordMock = Mock.Create<IRenderable>();
            var consoleRenderer = new ConsoleRenderer();
            Mock.Arrange(() => wordMock.GetBody()).DoNothing();
            consoleRenderer.PrintWord(wordMock);
            textWriter.Close();

            string expected = Environment.NewLine + "The secret word is: " + Environment.NewLine + Environment.NewLine;

            string actual = File.ReadAllText("./consolewritertests.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PrintEndScreenShouldPrintTextContentToConsole()
        {
            var consoleRenderer = new ConsoleRenderer();
            consoleRenderer.PrintEndScreen();
            this.textWriter.Close();

            string expected = "Enter your name: ";

            string actual = File.ReadAllText("./consolewritertests.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void RenderScoreboardShouldPrintPlayersToConsole()
        {
            var playerMock = Mock.Create<IRenderable>();
            var scoreBoardInfoMock = Mock.Create<IEnumerable<IRenderable>>();
            var consoleRenderer = new ConsoleRenderer();
            Mock.Arrange(() => playerMock.GetBody()).DoNothing();
            consoleRenderer.RenderScoreboard(scoreBoardInfoMock);
            this.textWriter.Close();

            string expected = new string('-', 40) + Environment.NewLine + "High Score - sorted by number of mistakes" + Environment.NewLine + new string('-', 40) + Environment.NewLine;

            string actual = File.ReadAllText("./consolewritertests.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PrintUsedLettersShouldPrintLettersToConsole()
        {
            var letterMock = Mock.Create<IRenderable>();
            var usedLettersMock = Mock.Create<IEnumerable<IRenderable>>();
            var consoleRenderer = new ConsoleRenderer();
            Mock.Arrange(() => letterMock.GetBody()).DoNothing();
            consoleRenderer.PrintUsedLetters(usedLettersMock);
            this.textWriter.Close();

            string expected = "Used Letters --> " + Environment.NewLine;
            string actual = File.ReadAllText("./consolewritertests.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PrintMistakesShouldPrintMistakesToConsole()
        {
            var consoleRenderer = new ConsoleRenderer();
            consoleRenderer.PrintMistakes(5);
            textWriter.Close();

            string expected = "Mistakes: " + 5 + Environment.NewLine;

            string actual = File.ReadAllText("./consolewritertests.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PrintEndScreenIfPlayerCheatedShouldPrintMessageToConsole()
        {
            var consoleRenderer = new ConsoleRenderer();
            consoleRenderer.PrintEndScreenIfPlayerCheated("cheater");
            textWriter.Close();

            string expected = "cheater" + Environment.NewLine;

            string actual = File.ReadAllText("./consolewritertests.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void InvalidCommandShouldPrintMessageToConsole()
        {
            var consoleRenderer = new ConsoleRenderer();
            consoleRenderer.InvalidCommand();
            textWriter.Close();

            string expected = "Invalid command!" + Environment.NewLine;

            string actual = File.ReadAllText("./consolewritertests.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PrintMessageShouldPrintMessageToConsole()
        {
            var consoleRenderer = new ConsoleRenderer();
            consoleRenderer.PrintMessage("any message");
            textWriter.Close();

            string expected = "any message" + Environment.NewLine;

            string actual = File.ReadAllText("./consolewritertests.txt");

            Assert.AreEqual(expected, actual);
        }

        //[TestCase]
        //public void ClearScreenShouldReturnEmptyString()
        //{
        //    var consoleRenderer = new ConsoleRenderer();
        //    consoleRenderer.ClearScreen();
        //    textWriter.Close();

        //    string actual = File.ReadAllText("./consolewritertests.txt");

        //    Assert.IsTrue(string.IsNullOrEmpty(actual));
        //}
    }
}
