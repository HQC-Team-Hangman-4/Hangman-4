namespace HangMan.GameObjects
{
    using System;
    using System.Collections.Generic;
    using HangMan.Helpers.Data;
    using HangMan.Interfaces;

    public class WordFactory
    {
        private Random random = new Random();
        private IWordDatabase wordDataBase;

        public WordFactory(IWordDatabase wordDataBase)
        {
            this.wordDataBase = wordDataBase;
        }

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

        private List<ILetter> WordAsLetters(Categories category)
        {
            var allLetters = new List<ILetter>();
            var word = this.wordDataBase.GetRandomWordByCategory(category);

            foreach (var letter in word)
            {
                allLetters.Add(new Letter(letter.ToString()));
            }

            return allLetters;
        }
    }
}