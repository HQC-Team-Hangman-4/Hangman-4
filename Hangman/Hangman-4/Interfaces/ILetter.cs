namespace HangMan.Interfaces
{
    using System.Collections.Generic;

    public interface ILetter : IRendarable
    {
        char Value { get; set; }

        bool IsFound { get; set; }
    }
}