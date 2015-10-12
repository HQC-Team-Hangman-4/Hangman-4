namespace HangMan.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides a common interface for all renderes.
    /// </summary>
    public interface IRenderer
    {
        void PrintInitialScreen();

        void PrintWord(IRenderable word);

        void RenderScoreboard(IEnumerable<IRenderable> scoreBoardInfo);

        void PrintEndScreen();

        void PrintUsedLetters(IEnumerable<IRenderable> usedLetters);

        void PrintMistakes(int numberOfMistakes);

        void PrintEndScreenIfPlayerCheated(string message);

        void InvalidCommand();

        void PrintMessage(string message);

        void ClearScreen();
    }
}
