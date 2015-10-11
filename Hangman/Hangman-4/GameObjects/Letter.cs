namespace HangMan.GameObjects
{
    using HangMan.Helpers;
    using HangMan.Interfaces;

    public class Letter : LetterPrototype, ILetter, IRenderable
    {
        private const char DefaultValue = 'a';
        private const bool DefaultIsFound = false;
        private char value;
        private bool state;

        public Letter()
        {
            this.IsFound = DefaultIsFound;
            this.Value = DefaultValue;
        }

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

        //Need to compare Letter, becauce GameInfo use HashSet
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ILetter))
            {
                return false;
            }

            return this.Value == ((ILetter)obj).Value;
        }

        public override int GetHashCode()
        {
            return this.Value.ToString().GetHashCode();
        }

        public string GetBody()
        {
            return this.Value.ToString();
        }

        public override ILetter Clone()
        {
            ILetter otherLetter = (ILetter)this.MemberwiseClone();
            otherLetter.IsFound = this.IsFound;
            otherLetter.Value = this.Value;

            return otherLetter;
        }
    }
}
