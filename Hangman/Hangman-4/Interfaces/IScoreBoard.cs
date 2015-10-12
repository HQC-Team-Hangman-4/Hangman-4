namespace HangMan.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides a common interface for different scoreboard implementations.
    /// </summary>
    public interface IScoreBoard
    {
        void AddPlayerToScoreBoard(IPlayer player);

        ICollection<IPlayer> GetScoreBoard();
    }
}
