namespace Hangman.Tests
{
    using System;
    using HangMan.GameObjects;
    using NUnit.Framework;

    [TestFixture]
    public class LetterTests
    {
        private Letter letterPrototype = new Letter();

        [TestCase('a', Result = 'a')]
        [TestCase('b', Result = 'b')]
        [TestCase('E', Result = 'e')]
        [TestCase('D', Result = 'd')]
        [TestCase('f', Result = 'f')]
        [TestCase('g', Result = 'g')]
        [TestCase('Z', Result = 'z')]
        public char CreatingLetterShouldSucceedWhenProvidingValidData(char letter)
        {
            var let = letterPrototype.Clone();
            let.Value = letter;

            return let.Value;
        }

        //[TestCase]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void CreatingLetterShouldThrowArgumentNullExceptionWhenProvidedNullData()
        //{
        //    var let = new LetterPrototype(null);
        //}

        [TestCase('a')]
        [TestCase('b')]
        [TestCase('E')]
        [TestCase('D')]
        [TestCase('f')]
        [TestCase('g')]
        [TestCase('Z')]
        public void CreatingLetterShouldSetIsFoundToFalse(char letter)
        {
            var let = letterPrototype.Clone();
            let.Value = letter;

            Assert.AreEqual(false, let.IsFound);
        }

        [TestCase('a')]
        [TestCase('b')]
        [TestCase('E')]
        [TestCase('D')]
        [TestCase('f')]
        [TestCase('g')]
        [TestCase('Z')]
        public void ChangingLetterIsFoundPropertyShouldWorkWhenGivenValidData(char letter)
        {
            var let = letterPrototype.Clone();
            let.Value = letter;

            let.IsFound = true;

            Assert.AreEqual(true, let.IsFound);
        }

        [TestCase('3', ExpectedException = typeof(ArgumentException))]
        [TestCase('-', ExpectedException = typeof(ArgumentException))]
        [TestCase('!', ExpectedException = typeof(ArgumentException))]
        [TestCase('?', ExpectedException = typeof(ArgumentException))]
        [TestCase('*', ExpectedException = typeof(ArgumentException))]
        public void ChangingLetterIsFoundPropertyShouldThrowWhenProvidedInvalidData(char letter)
        {
            var let = letterPrototype.Clone();
            let.Value = letter;
        }
    }
}
