namespace HangMan.Helpers.Data
{
    using System;
    using System.Linq;
    using HangMan.Interfaces;

    public class WordDatabase : Database, IWordDatabase
    {
        private Random random = new Random();

        public WordDatabase(IDataSerialization dataSerialization)
            : base(dataSerialization)
        {
        }

        public string GetRandomWordByCategory(Categories category)
        {
            var allWords = this.DataSerialization.ReadFromFile(FileNames.words)
                                            .Where(x => x.Contains(category.ToString())).ToArray();

            if (allWords.Length <= 0)
            {
                throw new ArgumentException("No word found.");
            }

            var randomIndex = this.random.Next(0, allWords.Count());
            var separator = allWords[randomIndex].IndexOf(" ", StringComparison.Ordinal) + 1;
            var word = allWords[randomIndex].Substring(separator);

            return word.Trim();
        }
    }
}
