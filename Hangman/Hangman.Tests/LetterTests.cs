using System;
using HangMan.GameObjects;
using NUnit.Framework;

namespace Hangman.Tests
{
    [TestFixture]
    public class LetterTests
    {
        [TestCase("a", Result = "a")]
        [TestCase("b", Result = "b")]
        [TestCase("E", Result = "e")]
        [TestCase("D", Result = "d")]
        [TestCase("f", Result = "f")]
        [TestCase("g", Result = "g")]
        [TestCase("Z", Result = "z")]
        public string CreatingLetterShouldSucceedWhenProvidingValidData(string letter)
        {
            var let = new Letter(letter);

            return let.Value;
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatingLetterShouldThrowArgumentNullExceptionWhenProvidedNullData()
        {
            var let = new Letter(null);
        }

        [TestCase("a")]
        [TestCase("b")]
        [TestCase("E")]
        [TestCase("D")]
        [TestCase("f")]
        [TestCase("g")]
        [TestCase("Z")]
        public void CreatingLetterShouldSetIsFoundToFalse(string letter)
        {
            var let = new Letter(letter);

            Assert.AreEqual(false, let.IsFound);
        }

        [TestCase("a")]
        [TestCase("b")]
        [TestCase("E")]
        [TestCase("D")]
        [TestCase("f")]
        [TestCase("g")]
        [TestCase("Z")]
        public void ChangingLetterIsFoundPropertyShouldWorkWhenGivenValidData(string letter)
        {
            var let = new Letter(letter);

            let.IsFound = true;

            Assert.AreEqual(true, let.IsFound);
        }

        [TestCase("aB", ExpectedException = typeof(ArgumentException))]
        [TestCase("13", ExpectedException = typeof(ArgumentException))]
        [TestCase("-", ExpectedException = typeof(ArgumentException))]
        [TestCase("!", ExpectedException = typeof(ArgumentException))]
        [TestCase("?", ExpectedException = typeof(ArgumentException))]
        [TestCase("*", ExpectedException = typeof(ArgumentException))]
        [TestCase("a21*", ExpectedException = typeof(ArgumentException))]
        public void ChangingLetterIsFoundPropertyShouldThrowWhenProvidedInvalidData(string letter)
        {
            var let = new Letter(letter);
        }
    }
}
