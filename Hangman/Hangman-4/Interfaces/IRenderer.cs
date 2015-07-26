using System.Collections.Generic;
namespace HangMan.Interfaces
{
    public interface IRenderer
    {
        void PrintInitialScreen();

        void PrintWord(IWord word);

        void RenderScoreboard(IEnumerable<IPlayer> scoreBoardInfo);

    }
}
