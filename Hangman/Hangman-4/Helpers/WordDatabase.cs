using System;
using System.Linq;
using HangMan.Interfaces;

namespace HangMan.Helpers
{
    public class WordDatabase : DataBase
    {
        private Random random = new Random();

        public WordDatabase(IDataSerialization dataSerialization)
            :base(dataSerialization)
        {
        }

        public string GetRandomWordByCategory(Categories category)
        {
            var allWords = this.DataSerialization.ReadFromFile(FileNames.words)
                                            .Where(x => x.Contains(category.ToString())).ToArray();

            var randomIndex = random.Next(0, allWords.Count());
            var separator = allWords[randomIndex].IndexOf(" ", StringComparison.Ordinal) + 1;
            var word = allWords[randomIndex].Substring(separator);

            return word.Trim();        
        }
    }
}
