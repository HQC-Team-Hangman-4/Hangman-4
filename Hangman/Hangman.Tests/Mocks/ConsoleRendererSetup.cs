namespace Hangman.Tests.Mocks
{
    using System;
    using System.IO;
    using NUnit.Framework;

    public class ConsoleRendererTestsSetup
    {
        public TextWriter textWriter;

        [SetUp]
        public void SetUp()
        {
            textWriter = File.CreateText("./consolewritertests.txt");
            Console.SetOut(textWriter);
        }

        [TearDown]
        public void TearDown()
        {
            textWriter.Close(); 
        }
    }
}
