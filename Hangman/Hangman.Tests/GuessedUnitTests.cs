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
    using HangMan.GameObjects;

    [TestFixture]
    public class GuessedUnitTests
    {
        [TestCase]
        public void GuessedShouldNotBeNullWhenInstantiated()
        {
            var renderableMock = Mock.Create<IRenderable>();
            var guessed = new Guessed(renderableMock);

            Assert.IsNotNull(guessed);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RenderableShouldNotBeNullWhenGuessedInstantiated()
        {
            IRenderable renderable = null;
            var guessed = new Guessed(renderable);
        }

        [TestCase]
        public void GetBodyShouldReturnString()
        {
            var renderableMock = Mock.Create<IRenderable>();
            var guessed = new Guessed(renderableMock);

            Assert.That(guessed.GetBody(), Is.TypeOf(typeof(string)));
        }
    }
}
