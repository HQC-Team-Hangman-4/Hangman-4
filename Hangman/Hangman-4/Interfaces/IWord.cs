namespace HangMan.Interfaces
{
    using System.Collections.Generic;
    
    public interface IWord : IRendarable
    {
        IEnumerable<ILetter> Content { get; }

        bool IsRevealed { get; }
    }
}
