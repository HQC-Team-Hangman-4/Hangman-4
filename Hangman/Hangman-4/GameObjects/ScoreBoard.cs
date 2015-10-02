using HangMan.Helpers.Data;
using HangMan.InputProviders.Data;
using HangMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan.GameObjects
{
    public sealed class Scoreboard
    {
        private ScoreBoardDatabase scoreboardDatabase;
        private static volatile Scoreboard scoreboard;
        private static object syncLock = new object();

        private Scoreboard()
        {
            this.scoreboardDatabase = new ScoreBoardDatabase(new DataSerialization());
        }

        public static Scoreboard Instance
        {
            get
            {
                if (scoreboard == null)
                {
                    lock (syncLock)
                    {
                        if (scoreboard == null)
                        {
                            scoreboard = new Scoreboard();
                        }
                    }
                }

                return scoreboard;
            }
        }

        public void AddPlayerScore(IPlayer player)
        {
            this.scoreboardDatabase.WriteToScoreBoard(player);
        }

        public ICollection<IPlayer> ViewScoreboard()
        {
            return this.scoreboardDatabase.ReadScoreboard();
        }
    }
}
