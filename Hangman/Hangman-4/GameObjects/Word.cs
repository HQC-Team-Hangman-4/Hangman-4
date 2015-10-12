namespace HangMan.GameObjects
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HangMan.Helpers;
    using HangMan.Interfaces;

    /// <summary>
    /// Defines word information and functionality.
    /// </summary>
    public class Word : IWord, IRenderable, IEnumerable<ILetter>
    {
        private IEnumerable<ILetter> content;

        /// <summary>
        /// Word constructor.
        /// </summary>
        /// <param name="content">IEnumerable<ILetter> collection.</param>
        public Word(IEnumerable<ILetter> content)
        {
            this.Content = new List<ILetter>(content);
        }

        /// <summary>
        /// Gets the content of a word.
        /// </summary>
        public IEnumerable<ILetter> Content
        {
            get
            {
                return this.content;
            }

            private set
            {
                Validator.CheckIfNull(value, "All letters in word");
                Validator.CheckAllElementsInCollection(value, "All letters in word");
                this.content = value;
            }
        }

        /// <summary>
        /// Gets whether a word is revealed or not.
        /// </summary>
        public bool IsRevealed
        {
            get
            {
                return this.Content.All(l => l.IsFound == true);
            }
        }

        /// <summary>
        /// Gives a string representation of a word.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Allows words to be looped through.
        /// </summary>
        /// <returns>IEnumerator<ILetter> collection.</returns>
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
