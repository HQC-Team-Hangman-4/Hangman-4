namespace HangMan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ScoreBoardPosition : IComparable<ScoreBoardPosition>
    {
        private int mistakes;
        private string name;   

        public ScoreBoardPosition(string name, int mistakes)
        {
            this.name = name;
            this.mistakes = mistakes;
        }

        public ScoreBoardPosition()
            : this(string.Empty, 0)
        {
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int Mistakes
        {
            get
            {
                return this.mistakes;
            }

            set
            {
                this.mistakes = value;
            }
        }

        public int CompareTo(ScoreBoardPosition other)
        {
            return this.Mistakes.CompareTo(other.Mistakes);
        }
    }
}
