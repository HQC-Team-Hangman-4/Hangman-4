using HangMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan.GameObjects
{
    public class GameInfo
    {
        public GameInfo()
        {
            this.UsedLetters = new HashSet<ILetter>();
        }

        public int Mistakes { get; set; }

        public HashSet<ILetter> UsedLetters { get; set; }
    }
}
