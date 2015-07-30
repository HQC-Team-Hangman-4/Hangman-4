using System.Collections.Generic;
namespace HangMan.Interfaces
{
    public interface IWord : IRendarable
    {
        IEnumerable<ILetter> Content { get; }

        bool IsRevealed { get; }
    }
}
