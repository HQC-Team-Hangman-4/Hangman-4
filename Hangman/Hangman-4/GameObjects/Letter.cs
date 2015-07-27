namespace HangMan.GameObjects
{
    using HangMan.Interfaces;
    using System.Collections.Generic;

    public class Letter : ILetter
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
        
    }
}
