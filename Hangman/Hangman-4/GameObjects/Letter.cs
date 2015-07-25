using HangMan.Interfaces;

namespace HangMan.GameObjects
{
    public class Letter :ILetter
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
    }
}
