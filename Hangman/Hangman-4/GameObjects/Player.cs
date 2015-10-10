using HangMan.Helpers;

namespace HangMan.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using HangMan.Interfaces;
    using HangMan.Users;

    public class Player : IPlayer, IRendarable
    {
        private string name;
        private int score;

        public Player()
        {
            this.PlayerGameInformation = new List<GameInfo>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                Validator.CheckIfNull(value, "Player name");
                Validator.CheckIfInRangeIncluded(value.Length, "Player name", 3, 20);
                
                this.name = value;
            }
        }

        public int Score
        {
            get { return this.score; }
            set
            {
                Validator.checkIfValidScore(value, "Player score");
                this.score = value;
            }
        }

        public List<GameInfo> PlayerGameInformation { get; set; }

        public string GetBody()
        {
            return string.Format("{0} --> {1}", this.Name, this.Score);
        }
    }
}
