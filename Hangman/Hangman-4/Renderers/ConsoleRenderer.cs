namespace HangMan.Renderers
{
    using System;
    using System.Collections.Generic;
    using HangMan.Interfaces;
    
    public class ConsoleRenderer : IRenderer
    {
        public void PrintInitialScreen()
        {
            Console.WriteLine("Welcome to Hangman");
            Console.WriteLine("Use 'top' to view the top scoreboard," +
            "'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.");
        }

        public void PrintWord(IRendarable word)
        {
            Console.WriteLine();
            Console.Write("The secret word is: ");
            Console.WriteLine(word.GetBody());
            Console.WriteLine();
        }

        public void PrintEndScreen()
        {
            //Console.WriteLine("Congratulations! You made the scoreboard!");
            Console.Write("Enter your name: ");
        }

        public void RenderScoreboard(IEnumerable<IRendarable> scoreBoardInfo)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("High Score - sorted by number of mistakes");
            foreach (var player in scoreBoardInfo)
            {
                Console.WriteLine(player.GetBody());
            }

            Console.WriteLine(new string('-', 40));
        }

        public void PrintUsedLetters(IEnumerable<IRendarable> usedLetters)
        {
            Console.Write("Used Letters --> ");
            foreach (var letter in usedLetters)
            {
                Console.Write("{0} ", letter.GetBody());
            }

            Console.WriteLine();
        }

        public void PrintMistakes(int numberOfMistakes)
        {
            Console.WriteLine("Mistakes: {0}", numberOfMistakes);
        }

        public void PrintEndScreenIfYouPlayerCheated(string message)
        {
            Console.WriteLine(message);
        }

        public void InvalidCommand()
        {
            Console.WriteLine("Invalid command");
        }
    }
}
