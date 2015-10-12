namespace Hangman.Tests.Mocks
{
    using System;
    using System.IO;
    using NUnit.Framework;

    public class ConsoleRendererTestsSetup
    {
        public TextWriter TextWriter { get; set; }

        [SetUp]
        public void SetUp()
        {
            this.TextWriter = File.CreateText("./consolewritertests.txt");
            Console.SetOut(this.TextWriter);
        }

        [TearDown]
        public void TearDown()
        {
            this.TextWriter.Close(); 
        }
    }
}
