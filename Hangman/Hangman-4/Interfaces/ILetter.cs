namespace HangMan.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides a common interface for letters.
    /// </summary>
    public interface ILetter : IRenderable
    {
        char Value { get; set; }

        bool IsFound { get; set; }
    }
}