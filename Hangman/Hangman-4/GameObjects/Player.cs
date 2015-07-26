namespace HangMan.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using HangMan.Interfaces;
    using HangMan.Users;

    public class Player : IPlayer
    {
        public string Name { get; set; }

        public int Score { get; set; }

        public List<GameInfo> PlayerGameInformation { get; set; }

    }
}
