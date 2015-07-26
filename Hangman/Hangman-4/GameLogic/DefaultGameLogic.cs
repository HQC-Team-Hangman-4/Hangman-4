namespace HangMan.GameLogic
{
    using System;
    using System.Collections.Generic;

    using HangMan.Interfaces;
    using HangMan.Helpers;
    using HangMan.GameObjects;

    public class DefaultGameLogic
    {
        public IWord Word { get; set; }
        public bool IsCheated { get; set; }

        public IEnumerable<ILetter> UsedLetters { get; set; }

        public int GuessLetter(ILetter letter)
        {
            int guessedLetter = 0;
            foreach (var symbol in this.Word.Content)
            {
                if (!symbol.IsFound && symbol.Value == letter.Value)
                {
                    symbol.IsFound = true;
                    guessedLetter++;
                }
            }

            return guessedLetter;
        }
       
    }
}
