using HangMan.Interfaces;

namespace HangMan.Helpers.Data
{
    using GameObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ScoreBoardDatabase : DataBase
    {
        public ScoreBoardDatabase(IDataSerialization dataSerialization)
            :base(dataSerialization)
        {
        }
        
        public ICollection<IPlayer> ReadScoreboard()
        {
            ICollection<IPlayer> result = new List<IPlayer>();
            IEnumerable<string> scoreBoardInfo = DataSerialization.ReadFromFile(FileNames.scoreboard);

            foreach (var scorBoardPlayer in scoreBoardInfo)
            {
                string[] currentPlayerInfo = scorBoardPlayer.Trim().Split(' ');

                IPlayer player = new Player();
                player.Name = currentPlayerInfo[0];
                player.Score = Convert.ToInt32(currentPlayerInfo[1]);

                result.Add(player);
            }

            return result;
        }
        
        public void WriteToScoreBoard(IPlayer player)
        {
            ICollection<IPlayer> currentScoreBoard = new HashSet<IPlayer>();
            currentScoreBoard = ReadScoreboard();

            bool reorder = true;
            //check if player already exist and have new high score
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
