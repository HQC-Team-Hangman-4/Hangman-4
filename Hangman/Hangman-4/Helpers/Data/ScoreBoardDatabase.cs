namespace HangMan.Helpers.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameObjects;
    using HangMan.Interfaces;
    
    public class ScoreBoardDatabase : Database
    {
        private Player playerPrototype = new Player();

        public ScoreBoardDatabase(IDataSerialization dataSerialization)
            : base(dataSerialization)
        {
        }
        
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
