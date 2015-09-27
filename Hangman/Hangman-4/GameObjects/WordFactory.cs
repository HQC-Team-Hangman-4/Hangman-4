namespace HangMan.GameObjects
{
    using System;
    using System.Linq;

    using HangMan.InputProviders;
    using HangMan.Interfaces;
    using System.Collections.Generic;
    using HangMan.Helpers.Data;

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
                    letters = WordAsLetters(Categories.Geography);
                    break;
                case Categories.IT:
                    letters = WordAsLetters(Categories.IT);
                    break;
                default:
                    throw new NotImplementedException();
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
