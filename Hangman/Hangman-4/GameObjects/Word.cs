using HangMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan.GameObjects
{
    public class Word : IWord
    {
        private IEnumerable<ILetter> content;
        private bool isRevealed;

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
                return this.isRevealed;
            }
            set
            {
                //TODO: Validation
                this.isRevealed = value;
            }
        }
    }
}
