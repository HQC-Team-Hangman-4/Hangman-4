namespace HangMan.GameObjects
{
    using System.Collections.Generic;
    using HangMan.Helpers.Data;
    using HangMan.InputProviders.Data;
    using HangMan.Interfaces;

    public sealed class Scoreboard
    {
        private static volatile Scoreboard scoreboard;
        private static object syncLock = new object();
        private ScoreBoardDatabase scoreboardDatabase;

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
