namespace HangMan.GameObjects
{
    using System.Collections.Generic;
    using HangMan.Helpers;
    using HangMan.Interfaces;

    /// <summary>
    /// Represents a player.
    /// </summary>
    public class Player : PlayerPrototype, IPlayer, IRenderable
    {
        private const string DefaultName = "player";
        private const int DefaultScore = 0;
        private string name;
        private int score;

        /// <summary>
        /// Player constructor.
        /// </summary>
        public Player()
        {
            this.Name = DefaultName;
            this.Score = DefaultScore;
            this.PlayerGameInformation = new List<GameInfo>();
        }

        /// <summary>
        /// Gets and sets player name.
        /// </summary>
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

        /// <summary>
        /// Gets and sets player score.
        /// </summary>
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

        /// <summary>
        /// Gets and sets player game information.
        /// </summary>
        public List<GameInfo> PlayerGameInformation { get; set; }

        /// <summary>
        /// Returns string representation of player.
        /// </summary>
        /// <returns>String.</returns>
        public string GetBody()
        {
            string playerBody = string.Format("{0} --> {1}", this.Name.PadLeft(20, ' '), this.Score);

            return playerBody;
        }

        /// <summary>
        /// Clones the player.
        /// </summary>
        /// <returns>IPlayer object.</returns>
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
