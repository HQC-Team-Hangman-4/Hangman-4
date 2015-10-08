using HangMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using HangMan.Helpers;

namespace HangMan.GameObjects
{
    public class Word : IWord, IRenderable, IEnumerable<ILetter>
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
                Validator.CheckIfNull(value, "All letters in word");
                Validator.CheckAllElementsInCollection(value, "All letters in word");
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

        public IEnumerator<ILetter> GetEnumerator()
        {
            foreach (var letter in this.Content)
            {
                yield return letter;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
