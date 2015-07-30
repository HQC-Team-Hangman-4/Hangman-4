namespace HangMan.Interfaces
{
    using System.Collections.Generic;

    public interface ILetter : IRendarable
    {
        string Value { get; }

        bool IsFound { get; set; }
    }
}