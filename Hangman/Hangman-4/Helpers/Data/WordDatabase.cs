namespace HangMan.Helpers.Data
{
    using System;
    using System.Linq;
    using HangMan.Interfaces;

    /// <summary>
    /// Defines information and functionality for the word database.
    /// </summary>
    public class WordDatabase : Database, IWordDatabase
    {
        private Random random = new Random();

        /// <summary>
        /// WordDatabase constructor.
        /// </summary>
        /// <param name="dataSerialization">IDataSerialization object.</param>
        public WordDatabase(IDataSerialization dataSerialization)
            : base(dataSerialization)
        {
        }

        /// <summary>
        /// Gets a random word by a category.
        /// </summary>
        /// <param name="category">Category of words.</param>
        /// <returns>String representation of word.</returns>
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
