namespace HangMan.Interfaces
{
    using System.Collections.Generic;

    public interface IRenderer
    {
        void PrintInitialScreen();

        void PrintWord(IRendarable word);

        void RenderScoreboard(IEnumerable<IRendarable> scoreBoardInfo);

        void PrintEndScreen();

        void PrintUsedLetters(IEnumerable<IRendarable> usedLetters);

        void PrintMistakes(int numberOfMistakes);

        void PrintEndScreenIfYouPlayerCheated(string message);

        void InvalidCommand();
    }
}
