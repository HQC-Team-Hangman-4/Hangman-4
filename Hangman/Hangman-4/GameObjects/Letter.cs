using HangMan.Helpers;

namespace HangMan.GameObjects
{
    using HangMan.Interfaces;
    using System.Collections.Generic;

    public class Letter : ILetter, IRenderable
    {
        private string value;
        private bool state;

        public Letter(string value)
        {
            this.Value = value;
            this.IsFound = false;
        }

        public string Value
        {
            get
            {
                return this.value;
            }
            private set
            {
                Validator.CheckIfNull(value, "Letter value");
                Validator.CheckIfInRangeIncluded(value.Length, "Letter value length", 1, 1);
                Validator.CheckIfLetter(value, "Letter value");
                this.value = value.ToLower();
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
            return this.Value;
        }
    }
}
