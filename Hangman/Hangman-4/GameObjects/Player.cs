namespace HangMan.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using HangMan.Helpers;
    using HangMan.Interfaces;
    using HangMan.Users;
    
    public class Player : PlayerPrototype, IPlayer, IRendarable
    {
        private const string DefaultName = "player";
        private const int DefaultScore = 0;
        private string name;
        private int score;

        public Player()
        {
            this.Name = DefaultName;
            this.Score = DefaultScore;
            this.PlayerGameInformation = new List<GameInfo>();
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }

            set
            {
                Validator.CheckIfNull(value, "Player name");
                Validator.CheckIfInRangeIncluded(value.Length, "Player name", 3, 20);
                
                this.name = value;
            }
        }

        public int Score
        {
            get 
            { 
                return this.score; 
            }

            set
            {
                Validator.CheckIfValidScore(value, "Player score");
                this.score = value;
            }
        }

        public List<GameInfo> PlayerGameInformation { get; set; }

        public string GetBody()
        {
            return string.Format("{0} --> {1}", this.Name.PadLeft(20, ' '), this.Score);
        }

        public override IPlayer Clone()
        {
            IPlayer otherPlayer = (IPlayer)this.MemberwiseClone();
            otherPlayer.Name = string.Copy(this.Name);
            otherPlayer.PlayerGameInformation = new List<GameInfo>(this.PlayerGameInformation);
            otherPlayer.Score = this.Score;

            return otherPlayer;
        }
    }
}
