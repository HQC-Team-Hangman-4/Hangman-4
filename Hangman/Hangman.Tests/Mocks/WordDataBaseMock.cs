using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HangMan.Helpers.Data;

namespace Hangman.Tests.Mocks
{
    public abstract class WordDataBaseMock
    {
        private Random random = new Random();

        protected WordDataBaseMock()
        {
            this.PopulateFakeData();
            this.ArrangeCarsRepositoryMock();
        }

        public IWordDatabase db { get; protected set; }

        protected ICollection<string> FakeWordCollection { get; private set; }

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

        protected string GetWord(Categories category)
        {
            var allWords = this.FakeWordCollection
                                            .Where(x => x.Contains(category.ToString())).ToArray();

            var randomIndex = random.Next(0, allWords.Count());
            var separator = allWords[randomIndex].IndexOf(" ", StringComparison.Ordinal) + 1;
            var word = allWords[randomIndex].Substring(separator);

            return word.Trim();
        }

        protected abstract void ArrangeCarsRepositoryMock();
    }
}
