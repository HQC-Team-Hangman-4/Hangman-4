namespace HangMan.GameObjects
{
    using System.Collections.Generic;
    using HangMan.Interfaces;

    public class GameInfo
    {
        public GameInfo()
        {
            this.UsedLetters = new HashSet<ILetter>();
            this.Mistakes = 0;
        }

        public int Mistakes { get; set; }

        public HashSet<ILetter> UsedLetters { get; set; }
    }
}
