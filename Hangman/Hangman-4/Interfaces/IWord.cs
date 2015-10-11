namespace HangMan.Interfaces
{
    using System.Collections.Generic;
    
    public interface IWord : IRenderable
    {
        IEnumerable<ILetter> Content { get; }

        bool IsRevealed { get; }
    }
}
