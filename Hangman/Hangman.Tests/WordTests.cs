namespace Hangman.Tests
{
    using System;
    using HangMan.GameObjects;
    using NUnit.Framework;
    using Telerik.JustMock;
    using HangMan.Interfaces;
    using System.Collections.Generic;

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
