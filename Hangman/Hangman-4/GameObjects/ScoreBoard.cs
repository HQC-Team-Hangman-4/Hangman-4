namespace HangMan.GameObjects
{
    using HangMan.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ScoreBoard
    { 
        public ScoreBoard(IEnumerable<IPlayer> players)
        {
            
        }

        public IEnumerable<IPlayer> GetScoreBoard()
        {
            throw new Exception();
        }


    }
}
