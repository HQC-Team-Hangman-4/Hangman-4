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
        public Player()
        {
            this.PlayerGameInformation = new List<GameInfo>();
        }

        public string Name { get; set; }

        public int Score { get; set; }

        public List<GameInfo> PlayerGameInformation { get; set; }

        public string GetBody()
        {
            return string.Format("{0} --> {1}", this.Name, this.Score);
        }
    }
}
