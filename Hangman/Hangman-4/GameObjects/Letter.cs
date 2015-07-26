namespace HangMan.GameObjects
{
    using HangMan.Interfaces;
    using System.Collections.Generic;

    public class Letter : ILetter, IEqualityComparer<ILetter>
    {
        private string value;
        private bool state;

        public Letter(string value)
        {
            this.Value = value;
        }

        public string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                //TODO:make validation
                this.value = value;
            }
        }

        bool ILetter.IsFound
        {
            get
            {
                return this.state;
            }
            set
            {
                //TODO:Validation
                this.state = value;
            }
        }

        public bool Equals(ILetter x, ILetter y)
        {
            if (x.Value.Equals(y.Value))
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(ILetter obj)
        {
            return obj.Value.GetHashCode();
        }
    }
}
