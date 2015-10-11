namespace HangMan.Interfaces
{
    using System.Collections.Generic;
    using HangMan.GameObjects;

    public interface IPlayer : IRenderable
    {
        string Name { get; set; }

        int Score { get; set; }

        List<GameInfo> PlayerGameInformation { get; set; }
    }
}
