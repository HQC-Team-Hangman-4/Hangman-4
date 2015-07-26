namespace HangMan.Interfaces
{
    using System.Collections.Generic;

    public interface ILetter : IEqualityComparer<ILetter>
    {
        string Value { get; }

        bool IsFound { get; set; }
    }
}