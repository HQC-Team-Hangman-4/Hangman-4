using HangMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan.GameObjects
{
    public class Word : IWord, IRendarable
    {
        private IEnumerable<ILetter> content;

        public Word(IEnumerable<ILetter> content)
        {
            this.Content = new List<ILetter>(content);
        }

        public IEnumerable<ILetter> Content
        {
            get
            {
                return this.content;
            }

            private set
            {
                //TODO: validate
                this.content = value;
            }
        }
        public bool IsRevealed
        {
            get
            {
                return this.Content.All(l => l.IsFound == true);
            }
        }

        public string GetBody()
        {
            StringBuilder wordContent = new StringBuilder();

            foreach (var letter in this.Content)
            {
                if (letter.IsFound)
                {
                    wordContent.AppendFormat(" {0}", letter.GetBody());
                }
                else
                {
                    wordContent.AppendFormat(" _");
                }
            }

            return wordContent.ToString();
        }
    }
}
