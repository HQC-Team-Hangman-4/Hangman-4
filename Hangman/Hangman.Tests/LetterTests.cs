namespace Hangman.Tests
{
    using System;
    using HangMan.GameObjects;
    using NUnit.Framework;

    [TestFixture]
    public class LetterTests
    {
        private Letter letterPrototype = new Letter();

        [TestCase]
        public void LetterShouldNotBeNullWhenInstantiated()
        {
            var letter = new Letter();

            Assert.NotNull(letter);
        }

        [TestCase]
        public void IsFoundShouldBeFalseWhenLetterIsInstantiated()
        {
            var letter = new Letter();

            Assert.IsFalse(letter.IsFound);
        }

        [TestCase]
        public void ValueShouldNotBeNullWhenLetterIsInstantiated()
        {
            var letter = new Letter();

            Assert.IsNotNull(letter.Value);
        }

        [TestCase]
        public void ValueShouldHaveDefaultValueA()
        {
            var letter = new Letter();

            Assert.AreEqual(letter.Value, 'a');
        }

        [TestCase]
        public void GetBodyShouldReturnString()
        {
            Assert.That(this.letterPrototype.GetBody(), Is.TypeOf(typeof(string)));
        }

        [TestCase('a', Result = 'a')]
        [TestCase('b', Result = 'b')]
        [TestCase('E', Result = 'e')]
        [TestCase('D', Result = 'd')]
        [TestCase('f', Result = 'f')]
        [TestCase('g', Result = 'g')]
        [TestCase('Z', Result = 'z')]
        public char CreatingLetterShouldSucceedWhenProvidingValidData(char letter)
        {
            var let = this.letterPrototype.Clone();
            let.Value = letter;

            return let.Value;
        }

        [TestCase('a')]
        [TestCase('b')]
        [TestCase('E')]
        [TestCase('D')]
        [TestCase('f')]
        [TestCase('g')]
        [TestCase('Z')]
        public void CreatingLetterShouldSetIsFoundToFalse(char letter)
        {
            var let = this.letterPrototype.Clone();
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
            var let = this.letterPrototype.Clone();
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
            var let = this.letterPrototype.Clone();
            let.Value = letter;
        }

        [TestCase('s')]
        [TestCase('r')]
        [TestCase('T')]
        [TestCase('O')]
        [TestCase('P')]
        public void LetterShouldNotBeEqualWhenDifferent(char letter)
        {
            var letA = this.letterPrototype.Clone();
            letA.Value = letter;

            var letB = this.letterPrototype.Clone();
            letB.Value = 'A';

            Assert.AreNotEqual(letA, letB);
        }

        [TestCase('p')]
        [TestCase('Y')]
        [TestCase('q')]
        [TestCase('f')]
        [TestCase('n')]
        public void LetterShouldBeEqualWhenSame(char letter)
        {
            var letA = this.letterPrototype.Clone();
            letA.Value = letter;

            var letB = this.letterPrototype.Clone();
            letB.Value = letter;

            Assert.AreEqual(letA, letB);
        }

        [TestCase('s')]
        [TestCase('t')]
        [TestCase('r')]
        [TestCase('p')]
        [TestCase('M')]
        public void DifferentLettersHashCodeShouldBeUnique(char letter)
        {
            var letA = this.letterPrototype.Clone();
            letA.Value = letter;

            var letB = this.letterPrototype.Clone();
            letB.Value = 'A';

            Assert.AreNotEqual(letA.GetHashCode(), letB.GetHashCode());
        }
    }
}
