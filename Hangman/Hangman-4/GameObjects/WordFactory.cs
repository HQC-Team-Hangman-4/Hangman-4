
using System.Collections.Generic;

namespace HangMan.GameObjects
{
    using System;
    using System.Linq;

    using HangMan.InputProviders;
    using HangMan.Interfaces;

    public class WordFactory
    {
        private Random random = new Random();

        public WordFactory()
        {
        }

        public IWord GetWord(Categories category)
        {
            switch (category)
            {
                case Categories.Astronomy:
                    return new Word(WordAsLetters(Categories.Astronomy));
                case Categories.Biology:
                    return new Word(WordAsLetters(Categories.Biology));
                case Categories.Geography:
                    return new Word(WordAsLetters(Categories.Geography));
                case Categories.IT:
                    return new Word(WordAsLetters(Categories.IT));
                default:
                    throw new NotImplementedException();
            }
        }

        // Helper methods
        private string WordFromFile(Categories category)
        {
            var allWords = DataSerialization.ReadFromFile(FileNames.words)
                                            .Where(x => x.Contains(category.ToString()))
                                            .ToArray();
                                            
            var randomIndex = random.Next(0, allWords.Count());
            var separator = allWords[randomIndex].IndexOf(" ", StringComparison.Ordinal) + 1;
            
            //Returns a random word from the given category, without taking the category and the separator.
            var word = allWords[randomIndex].Substring(separator);
            return word;
        }

        private IList<ILetter> WordAsLetters(Categories category)
        {
            var allLetters = new List<ILetter>();
            var word = WordFromFile(category);

            foreach (var letter in word)
            {
                allLetters.Add(new Letter(letter.ToString()));
            }

            return allLetters;
        }
    }
}
