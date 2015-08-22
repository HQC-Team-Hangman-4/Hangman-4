namespace HangMan.Interfaces
{
    using HangMan.GameObjects;
    using System.Collections.Generic;

    public interface IPlayer : IRendarable
    {
        string Name { get; set; }

        int Score { get; set; }

        List<GameInfo> PlayerGameInformation { get; set; }
    }
}
