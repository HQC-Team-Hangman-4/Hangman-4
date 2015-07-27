namespace HangMan.Interfaces
{
    using System.Collections.Generic;

    public interface ILetter 
    {
        string Value { get; }

        bool IsFound { get; set; }
    }
}