namespace HangMan.Interfaces
{
    using System.Collections.Generic;

    public interface ILetter : IRenderable
    {
        char Value { get; set; }

        bool IsFound { get; set; }
    }
}