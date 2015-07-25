using HangMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan.GameObjects
{
    public class GameInfo
    {
        public int Mistakes { get; set; }

        public IList<ILetter> UsedLetters { get; set; }
    }
}
