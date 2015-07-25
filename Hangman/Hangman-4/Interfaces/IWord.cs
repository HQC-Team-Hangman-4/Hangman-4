using System.Collections.Generic;
namespace HangMan.Interfaces
{
    public interface IWord
    {
        IEnumerable<ILetter> Content { get; }

        bool IsRevealed { get; set; }
    }
}
