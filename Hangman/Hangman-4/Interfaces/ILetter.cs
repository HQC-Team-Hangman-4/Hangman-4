namespace HangMan.Interfaces
{
    using System.Collections.Generic;

    public interface ILetter : IRenderable
    {
        string Value { get; }

        bool IsFound { get; set; }
    }
}