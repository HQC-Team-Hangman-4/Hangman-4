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
    public class ConsoleFancyRendererTests : ConsoleRendererTestsSetup
    {
        [TestCase]
        public void ConsoleFancyRendererShouldNotBeNullWhenInstantiated()
        {
            var consolefancyRenderer = new ConsoleFancyRenderer();

            Assert.IsNotNull(consolefancyRenderer);
        }

        //[TestCase]
        //public void PrintInitialScreenShouldPrintToConsole()
        //{
        //    var consolefancyRenderer = new ConsoleFancyRenderer();
        //    consolefancyRenderer.PrintInitialScreen();
        //    this.textWriter.Close();

        //    string expected = "Welcome to";
        //    string actual = File.ReadAllText("./consolewritertests.txt");

        //    Assert.AreEqual(expected, actual);
        //}
    }
}
