namespace HangMan.GameObjects
{
    using System.Collections.Generic;
    using HangMan.Helpers.Data;
    using HangMan.InputProviders.Data;
    using HangMan.Interfaces;

    /// <summary>
    /// Defines scoreboard information and functionality.
    /// </summary>
    public sealed class Scoreboard
    {
        private static volatile Scoreboard scoreboard;
        private static object syncLock = new object();
        private ScoreBoardDatabase scoreboardDatabase;

        private Scoreboard()
        {
            this.scoreboardDatabase = new ScoreBoardDatabase(new DataSerialization());
        }

        /// <summary>
        /// Returns an instance of Scoreboard.
        /// </summary>
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

        /// <summary>
        /// Adds a player to the scoreboard.
        /// </summary>
        /// <param name="player">IPlayer object.</param>
        public void AddPlayerScore(IPlayer player)
        {
            this.scoreboardDatabase.WriteToScoreBoard(player);
        }

        /// <summary>
        /// Reads and returns the scoreboard.
        /// </summary>
        /// <returns></returns>
        public ICollection<IPlayer> ViewScoreboard()
        {
            var scoreboard = this.scoreboardDatabase.ReadScoreboard();

            return scoreboard;
        }
    }
}
