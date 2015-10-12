namespace Hangman.Tests
{
    using System;
    using System.Collections.Generic;
    using HangMan.GameObjects;
    using HangMan.Interfaces;
    using NUnit.Framework;
    using Telerik.JustMock;

    [TestFixture]
    public class WordTests
    {
        [TestCase]
        public void WordShouldNotBeNullOnCreation() 
        {
            var contentMock = Mock.Create<IEnumerable<ILetter>>();

            var wordMock = new Word(contentMock);

            Assert.NotNull(wordMock);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WordShouldThrowWhenCreatedWithInvalidData()
        {
            var wordMock = new Word(null);
        }

        [TestCase]
        public void GetBodyShouldReturnString()
        {
            var contentMock = Mock.Create<IEnumerable<ILetter>>();

            var wordMock = new Word(contentMock);

            Assert.That(wordMock.GetBody(), Is.TypeOf(typeof(string)));
        }
    }
}
