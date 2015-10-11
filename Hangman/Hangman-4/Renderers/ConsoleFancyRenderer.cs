namespace HangMan.Renderers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HangMan.Helpers;
    using HangMan.Interfaces;

    public class ConsoleFancyRenderer : IRenderer
    {
        private const int ConsoleHeight = 50;
        private const int ConsoleWidth = 140;
        private const int CenterHeight = ConsoleHeight / 2;
        private const int CenterWidth = ConsoleWidth / 2;
        private const string TitleMessage = "Hangman";
        private const string GamePlayMessage1Line = "Use 'top' to view the top scoreboard,'restart' to start a new game, ";
        private const string GamePlayMessage2Line = "'help' to cheat and 'exit' to quit the game.";
        private const string GamePlayMessage3Line = "Press ENTER to continue";
        private const ConsoleColor BackgroundColor = ConsoleColor.Yellow;
        private const ConsoleColor FontColor = ConsoleColor.Magenta;
        private static FontHelper normalFont = new FontHelper("../../Files/cyber.txt");
        private static FontHelper titleFont = new FontHelper("../../Files/shadow.txt");
        private static FontHelper wordsFont = new FontHelper("../../Files/calvin.txt");
        private static FontHelper smallFont = new FontHelper("../../Files/straight.txt");

        public void PrintInitialScreen()
        {
            Console.CursorVisible = false;
            Console.WindowHeight = ConsoleHeight;
            Console.WindowWidth = ConsoleWidth;
            Console.BufferHeight = ConsoleHeight;
            Console.BufferWidth = ConsoleWidth;
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = FontColor;

            Console.Clear();

            normalFont.Print("Welcome to", 38, CenterHeight - 10);
            titleFont.Print(TitleMessage, 30, CenterHeight - 5);

            Console.ReadKey();
            Console.SetCursorPosition(35, CenterHeight + 5);
            Console.WriteLine(GamePlayMessage1Line);
            Console.SetCursorPosition(45, CenterHeight + 6);
            Console.WriteLine(GamePlayMessage2Line);
            Console.SetCursorPosition(55, CenterHeight + 8);
            Console.WriteLine(GamePlayMessage3Line);
            Console.ReadKey();
            Console.ForegroundColor = BackgroundColor;
            Console.Clear();
        }

        public void PrintWord(IRenderable word)
        {
            Console.ForegroundColor = FontColor;

            string secretWord = word.GetBody().ToUpper();
            wordsFont.Print(secretWord, CenterWidth - secretWord.Length * 5 / 2, CenterHeight - 10);

            ClearCommand();
        }

        public void RenderScoreboard(IEnumerable<IRenderable> scoreBoardInfo)
        {
            Console.ForegroundColor = FontColor;
            Console.Clear();

            string scoreboardMessage = "HIGH SCORE - sorted by number of mistakes";

            Console.SetCursorPosition(CenterWidth - scoreboardMessage.Length + 18, 4);
            Console.WriteLine('╔' + new string('═', scoreboardMessage.Length + 1) + '╗');
            for (int i = 1; i < 23; i++)
            {
                Console.SetCursorPosition(CenterWidth - scoreboardMessage.Length + 18, 4 + i);
                Console.WriteLine('║' + new string(' ', scoreboardMessage.Length + 1) + '║');
            }

            Console.SetCursorPosition(CenterWidth - scoreboardMessage.Length + 18, 27);
            Console.WriteLine('╚' + new string('═', scoreboardMessage.Length + 1) + '╝');

            Console.SetCursorPosition(CenterWidth - scoreboardMessage.Length + 19, 5);
            Console.WriteLine(scoreboardMessage);

            int counter = 7;
            foreach (var player in scoreBoardInfo)
            {
                Console.SetCursorPosition(CenterWidth - scoreboardMessage.Length + 20, counter++);
                Console.WriteLine(player.GetBody());
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void PrintEndScreen()
        {
            Console.ForegroundColor = FontColor;
            Console.Clear();
            
            Console.SetCursorPosition(CenterWidth - 10, 19);
            Console.WriteLine("╔═════════════════════╗ ");
            Console.SetCursorPosition(CenterWidth - 10, 20);
            Console.WriteLine("║                     ║ ");
            Console.SetCursorPosition(CenterWidth - 10, 21);
            Console.WriteLine("║   ENTER YOUR NAME   ║ ");
            Console.SetCursorPosition(CenterWidth - 10, 22);
            Console.WriteLine("║                     ║ ");
            Console.SetCursorPosition(CenterWidth - 10, 23);
            Console.WriteLine("╚═════════════════════╝ ");

            Console.ReadKey();

            Console.SetCursorPosition(CenterWidth - 10, 21);
            Console.WriteLine("║                     ║ ");
            Console.SetCursorPosition(CenterWidth - 9, 21);
        }

        public void PrintUsedLetters(IEnumerable<IRenderable> usedLetters)
        {
            Console.ForegroundColor = FontColor;

            string usedLettersMessage = "USED LETTERS";

            Console.SetCursorPosition(ConsoleWidth - 15, 3);
            Console.WriteLine(usedLettersMessage);
            Console.SetCursorPosition(ConsoleWidth - 15, 4);
            Console.Write(new string('═', usedLettersMessage.Length));

            int counter = 0;
            foreach (var letter in usedLetters)
            {
                string currentLetter = letter.GetBody().ToUpper();

                Console.SetCursorPosition(ConsoleWidth - 9, 5 + counter++);
                Console.Write(currentLetter + " ");
            }

            ClearCommand();
        }

        public void PrintMistakes(int numberOfMistakes)
        {
            Console.ForegroundColor = FontColor;

            string usedLettersMessage = "MISTAKES";
            Console.SetCursorPosition(ConsoleWidth - 11, ConsoleHeight - 5);
            Console.Write(new string('═', usedLettersMessage.Length));
            Console.SetCursorPosition(ConsoleWidth - 11, ConsoleHeight - 4);
            Console.Write(usedLettersMessage);

            Console.SetCursorPosition(ConsoleWidth - 8, ConsoleHeight - 6);
            Console.Write(numberOfMistakes);

            ClearCommand();
        }

        public void PrintEndScreenIfYouPlayerCheated(string message)
        {
            Console.ForegroundColor = FontColor;
            Console.Clear();

            Console.SetCursorPosition(CenterWidth - message.Length / 2, CenterHeight / 2 + 10);
            Console.Write(message);

            Console.ForegroundColor = BackgroundColor;
        }

        public void InvalidCommand()
        {
            string message = "Invalid command!";

            Console.ForegroundColor = FontColor;

            Console.SetCursorPosition(CenterWidth - message.Length / 2, CenterHeight / 2 + 10);
            Console.Write(message);

            Console.ForegroundColor = BackgroundColor;

            new System.Threading.Thread(() =>
            {
                System.Threading.Thread.CurrentThread.IsBackground = true;
                System.Threading.Thread.Sleep(1000);
                Console.SetCursorPosition(CenterWidth - message.Length / 2, CenterHeight / 2 + 10);
                Console.Write(new string(' ', message.Length));
            }).Start();
        }

        public void PrintMessage(string message)
        {
            Console.ForegroundColor = FontColor;

            Console.SetCursorPosition(CenterWidth - message.Length / 2, CenterHeight / 2 + 10);
            Console.Write(message);

            ClearCommand();
        }

        private static void ClearCommand()
        {
            Console.SetCursorPosition(CenterWidth - 10, ConsoleHeight - 4);
            Console.Write(new string(' ', 30));
            Console.SetCursorPosition(CenterWidth - 10, ConsoleHeight - 4);
        }


        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
