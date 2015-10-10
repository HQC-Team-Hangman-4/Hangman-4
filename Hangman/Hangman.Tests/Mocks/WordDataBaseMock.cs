namespace Hangman.Tests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HangMan.Helpers.Data;
    
    public abstract class WordDataBaseMock
    {
        private Random random = new Random();

        protected WordDataBaseMock()
        {
            this.PopulateFakeData();
            this.ArrangeDatabaseMock();
        }

        public IWordDatabase DB { get; protected set; }

        protected ICollection<string> FakeWordCollection { get; private set; }

        protected string GetWord(Categories category)
        {
            var allWords = this.FakeWordCollection
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

        protected abstract void ArrangeDatabaseMock();

        private void PopulateFakeData()
        {
            this.FakeWordCollection = new List<string>
            {
                "IT computer",
                "IT programmer ",
                "IT software ",
                "Biology debugger ",
                "IT compiler ",
                "Astronomy developer ",
                "IT algorithm ",
                "IT array",
                "IT method",
                "IT variable"
            };
        }
    }
}
