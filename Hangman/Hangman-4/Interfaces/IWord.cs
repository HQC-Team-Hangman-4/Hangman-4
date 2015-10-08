using System.Collections.Generic;
namespace HangMan.Interfaces
{
    public interface IWord : IRenderable
    {
        IEnumerable<ILetter> Content { get; }

        bool IsRevealed { get; }
    }
}
