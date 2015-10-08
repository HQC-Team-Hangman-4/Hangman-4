﻿namespace HangMan.GameObjects
{
    using HangMan.Interfaces;
    using System.Collections.Generic;

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