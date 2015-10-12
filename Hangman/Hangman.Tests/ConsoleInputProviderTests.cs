namespace Hangman.Tests
{
    using System;
    using System.IO;
    using Hangman.Tests.Mocks;
    using HangMan.InputProviders;
    using NUnit.Framework;

    [TestFixture]
    public class ConsoleInputProviderTests
    {
        private TextReader textReader;

        [TestFixtureSetUp]
        public void SetUpConsoleWrite()
        {
            this.textReader = File.OpenText("./consolereadtests.txt");
            Console.SetIn(this.textReader);
        }

        [TestCase]
        public void ConsoleInputProviderShouldNotBeNullWhenInstantiated()
        {
            var consoleInputProvider = new ConsoleInputProvider();

            Assert.IsNotNull(consoleInputProvider);
        }

        [TestCase]
        public void CommandPropertyShouldBeNullOnCreation()
        {
            var consoleInputProvider = new ConsoleInputProvider();

            Assert.IsNull(consoleInputProvider.Command);
        }

        [TestCase]
        public void GetInputMethodShouldSetCommandValueToString()
        {
            var consoleInputProviderMock = new ConsoleInputProviderMock();
            consoleInputProviderMock.GetInput();

            Assert.That(consoleInputProviderMock.Command, Is.TypeOf(typeof(string)));
        }

        [TestCase]
        public void GetInputMethodShouldReadFromConsole()
        {
            var consoleInputProvider = new ConsoleInputProvider();
            consoleInputProvider.GetInput();

            Assert.AreEqual(consoleInputProvider.Command, "this is a Test reading from console test.");
        }
    }
}
