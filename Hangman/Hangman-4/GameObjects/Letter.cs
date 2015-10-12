namespace HangMan.GameObjects
{
    using HangMan.Helpers;
    using HangMan.Interfaces;

    /// <summary>
    /// Holds information for a letter.
    /// </summary>
    public class Letter : LetterPrototype, ILetter, IRenderable
    {
        private const char DefaultValue = 'a';
        private const bool DefaultIsFound = false;
        private char value;
        private bool state;

        /// <summary>
        /// Letter constructor.
        /// </summary>
        public Letter()
        {
            this.IsFound = DefaultIsFound;
            this.Value = DefaultValue;
        }

        /// <summary>
        /// Gets and sets the value of a letter.
        /// </summary>
        public char Value
        {
            get
            {
                return this.value;
            }

            set
            {
                Validator.CheckIfNull(value, "Letter value");
                Validator.CheckIfLetter(value, "Letter value");
                this.value = char.ToLower(value);
            }
        }

        /// <summary>
        /// Gets and sets whether a letter is found.
        /// </summary>
        public bool IsFound
        {
            get
            {
                return this.state;
            }

            set
            {
                this.state = value;
            }
        }

        /// <summary>
        /// Determines if a letter is equal to another.
        /// </summary>
        /// <param name="obj">Another letter.</param>
        /// <returns>Boolean.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ILetter))
            {
                return false;
            }

            return this.Value == ((ILetter)obj).Value;
        }

        /// <summary>
        /// Gets the hascode of a letter.
        /// </summary>
        /// <returns>Integer value.</returns>
        public override int GetHashCode()
        {
            return this.Value.ToString().GetHashCode();
        }

        /// <summary>
        /// Gets the body of a letter.
        /// </summary>
        /// <returns>String representation.</returns>
        public string GetBody()
        {
            return this.Value.ToString();
        }

        /// <summary>
        /// Clones the letter.
        /// </summary>
        /// <returns>ILetter object.</returns>
        public override ILetter Clone()
        {
            ILetter otherLetter = (ILetter)this.MemberwiseClone();
            otherLetter.IsFound = this.IsFound;
            otherLetter.Value = this.Value;

            return otherLetter;
        }
    }
}
