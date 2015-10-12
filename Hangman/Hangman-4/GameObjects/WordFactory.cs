namespace HangMan.GameObjects
{
    using System;
    using System.Collections.Generic;
    using HangMan.Helpers.Data;
    using HangMan.Interfaces;

    /// <summary>
    /// Creates words.
    /// </summary>
    public class WordFactory
    {
        private Letter letterPrototype = new Letter();
        private Random random = new Random();
        private IWordDatabase wordDataBase;

        /// <summary>
        /// WordFactory constructor.
        /// </summary>
        /// <param name="wordDataBase"></param>
        public WordFactory(IWordDatabase wordDataBase)
        {
            this.wordDataBase = wordDataBase;
        }

        /// <summary>
        /// Returns a word.
        /// </summary>
        /// <param name="category">Category of the word.</param>
        /// <returns>IWord object.</returns>
        public IWord GetWord(Categories category)
        {
            var letters = new List<ILetter>();
            switch (category)
            {
                case Categories.Astronomy:
                    letters = this.WordAsLetters(Categories.Astronomy);
                    break;
                case Categories.Biology:
                    letters = this.WordAsLetters(Categories.Biology);
                    break;
                case Categories.Geography:
                    letters = this.WordAsLetters(Categories.Geography);
                    break;
                case Categories.IT:
                    letters = this.WordAsLetters(Categories.IT);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return new Word(letters);
        }

        /// <summary>
        /// Returns a word as collection of letters.
        /// </summary>
        /// <param name="category">Category of the word.</param>
        /// <returns>List<ILetter> collection.</returns>
        private List<ILetter> WordAsLetters(Categories category)
        {
            var allLetters = new List<ILetter>();
            var word = this.wordDataBase.GetRandomWordByCategory(category);

            foreach (var letter in word)
            {
                var currentLetter = this.letterPrototype.Clone();
                currentLetter.Value = letter;
                allLetters.Add(currentLetter);
            }

            return allLetters;
        }
    }
}