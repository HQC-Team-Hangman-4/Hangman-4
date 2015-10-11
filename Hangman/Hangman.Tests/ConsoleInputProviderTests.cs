namespace Hangman.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using HangMan.InputProviders;
    using Hangman.Tests.Mocks;

    [TestFixture]
    public class ConsoleInputProviderTests
    {
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
    }
}
