namespace HangMan.Helpers.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameObjects;
    using HangMan.Interfaces;
    
    /// <summary>
    /// Defines information and functionality for the scoreboard database.
    /// </summary>
    public class ScoreBoardDatabase : Database
    {
        private Player playerPrototype = new Player();

        /// <summary>
        /// Constructor for ScoreBoardDatabase.
        /// </summary>
        /// <param name="dataSerialization">IDataSerialization object.</param>
        public ScoreBoardDatabase(IDataSerialization dataSerialization)
            : base(dataSerialization)
        {
        }
        
        /// <summary>
        /// Reads the scoreboard into a collection of players.
        /// </summary>
        /// <returns>Collection of players.</returns>
        public ICollection<IPlayer> ReadScoreboard()
        {
            IList<IPlayer> result = new List<IPlayer>();
            IEnumerable<string> scoreBoardInfo = DataSerialization.ReadFromFile(FileNames.scoreboard);

            foreach (var scorBoardPlayer in scoreBoardInfo)
            {
                string[] currentPlayerInfo = scorBoardPlayer.Trim().Split(' ');

                IPlayer player = this.playerPrototype.Clone();
                player.Name = currentPlayerInfo[0];
                player.Score = Convert.ToInt32(currentPlayerInfo[1]);

                result.Insert(0, player);
            }

            return result;
        }
        
        /// <summary>
        /// Writes a player to the scoreboard database.
        /// </summary>
        /// <param name="player">PLayer to be written.</param>
        public void WriteToScoreBoard(IPlayer player)
        {
            ICollection<IPlayer> currentScoreBoard = new HashSet<IPlayer>();
            currentScoreBoard = this.ReadScoreboard();

            bool reorder = true;
            foreach (var currPlayer in currentScoreBoard.Where(cp => cp.Name == player.Name))
            {
                if (currPlayer.Score <= player.Score)
                {
                    currPlayer.Score = player.Score;
                    reorder = false;
                }
            }

            var sortedScoreBoard = currentScoreBoard;
            if (reorder)
            {
                currentScoreBoard.Add(player);
                sortedScoreBoard = currentScoreBoard.OrderByDescending(pl => Convert.ToInt32(pl.Score)).ThenBy(pl => pl.Name).ToList();
            }

            DataSerialization.WriteToFile(sortedScoreBoard, FileNames.scoreboard);
        }
    }
}
