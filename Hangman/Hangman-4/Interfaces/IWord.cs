namespace HangMan.Interfaces
{
    using System.Collections.Generic;
    
    /// <summary>
    /// Provides a commmon interface for word objects.
    /// </summary>
    public interface IWord : IRenderable
    {
        IEnumerable<ILetter> Content { get; }

        bool IsRevealed { get; }
    }
}
