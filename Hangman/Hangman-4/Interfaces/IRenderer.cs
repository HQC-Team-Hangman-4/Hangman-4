namespace HangMan.Interfaces
{
    using System.Collections.Generic;

    public interface IRenderer
    {
        void PrintInitialScreen();

        void PrintWord(IRenderable word);

        void RenderScoreboard(IEnumerable<IRenderable> scoreBoardInfo);

        void PrintEndScreen();

        void PrintUsedLetters(IEnumerable<IRenderable> usedLetters);

        void PrintMistakes(int numberOfMistakes);

        void PrintEndScreenIfYouPlayerCheated(string message);

        void InvalidCommand();
    }
}
