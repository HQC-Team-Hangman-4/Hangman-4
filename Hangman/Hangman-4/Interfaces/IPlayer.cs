namespace HangMan.Interfaces
{
    using System.Collections.Generic;
    using HangMan.GameObjects;

    /// <summary>
    /// Provides a common interface for players.
    /// </summary>
    public interface IPlayer : IRenderable
    {
        string Name { get; set; }

        int Score { get; set; }

        List<GameInfo> PlayerGameInformation { get; set; }
    }
}
