namespace HangMan.Interfaces
{
    using System.Collections.Generic;

    public interface IScoreBoard
    {
        void AddPlayerToScoreBoard(IPlayer player);

        ICollection<IPlayer> GetScoreBoard();
    }
}
