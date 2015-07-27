namespace HangMan.Interfaces
{
    using System.Collections.Generic;

    public interface IRenderer
    {
        void PrintInitialScreen();

        void PrintWord(IWord word);

        void RenderScoreboard(IEnumerable<IPlayer> scoreBoardInfo);

        void PrintEndScreen();

        void PrintUsedLettersAndMistakes(IEnumerable<ILetter> usedLetters, int numberOfMistakes);
    }
}
