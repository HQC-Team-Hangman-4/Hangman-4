
using System.Collections.Generic;
using HangMan.Helpers;

namespace HangMan.GameObjects
{
    using System;
    using System.Linq;

    using HangMan.InputProviders;
    using HangMan.Interfaces;

    public class WordFactory
    {
        private Random random = new Random();
        private WordDatabase wordDataBase;

        public WordFactory(WordDatabase wordDataBase)
        {
            this.wordDataBase = wordDataBase;
        }

        public IWord GetWord(Categories category)
        {
            var letters = new List<ILetter>();
            switch (category)
            {
                case Categories.Astronomy:
                    letters = WordAsLetters(Categories.Astronomy);
                    break;
                case Categories.Biology:
                    letters = WordAsLetters(Categories.Biology);
                    break;
                case Categories.Geography:
                    letters =WordAsLetters(Categories.Geography);
                    break;
                case Categories.IT:
                    letters = WordAsLetters(Categories.IT);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return new Word(letters);
        }

        // Helper methods
        // Goes to Database 

        //Stay here
        private List<ILetter> WordAsLetters(Categories category)
        {
            var allLetters = new List<ILetter>();
            var word = wordDataBase.GetRandomWordByCategory(category);

            foreach (var letter in word)
            {
                allLetters.Add(new Letter(letter.ToString()));
            }

            return allLetters;
        }
    }
}
