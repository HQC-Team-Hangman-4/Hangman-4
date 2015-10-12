namespace HangMan.GameObjects
{
    using System.Collections.Generic;
    using HangMan.Interfaces;

    /// <summary>
    /// Holds info for the game.
    /// </summary>
    public class GameInfo
    {
        /// <summary>
        /// GameInfo constructor.
        /// </summary>
        public GameInfo()
        {
            this.UsedLetters = new HashSet<ILetter>();
            this.Mistakes = 0;
        }

        /// <summary>
        /// Gets and sets the number of mistakes the player has made.
        /// </summary>
        public int Mistakes { get; set; }

        /// <summary>
        /// Gets and sets a collection of the letters the player has used already.
        /// </summary>
        public HashSet<ILetter> UsedLetters { get; set; }
    }
}
