namespace HangMan.Renderers
{
    using System;
    using System.Collections.Generic;
    using HangMan.Interfaces;

    /// <summary>
    /// Renders game on the console in a text mode.
    /// </summary>
    public class ConsoleRenderer : IRenderer
    {
        /// <summary>
        /// Prints the game initial screen.
        /// </summary>
        public void PrintInitialScreen()
        {
            Console.WriteLine("Welcome to Hangman");
            Console.WriteLine("Use 'top' to view the top scoreboard," +
            "'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.");
        }

        /// <summary>
        /// Prints the word to be guessed on the console.
        /// </summary>
        /// <param name="word">IRenderable word to be guessed.</param>
        public void PrintWord(IRenderable word)
        {
            Console.WriteLine();
            Console.Write("The secret word is: ");
            Console.WriteLine(word.GetBody());
            Console.WriteLine();
        }

        /// <summary>
        /// Prints the end screen where user is asked for name.
        /// </summary>
        public void PrintEndScreen()    
        {
            Console.Write("Enter your name: ");
        }

        /// <summary>
        /// Renders scoreboard on the console.
        /// </summary>
        /// <param name="scoreBoardInfo">Collection of renderable elements of the scoreboard.</param>
        public void RenderScoreboard(IEnumerable<IRenderable> scoreBoardInfo)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("High Score - sorted by number of mistakes");
            foreach (var player in scoreBoardInfo)
            {
                Console.WriteLine(player.GetBody());
            }

            Console.WriteLine(new string('-', 40));
        }

        /// <summary>
        /// Prints the letter the user has already used.
        /// </summary>
        /// <param name="usedLetters">Collection of renderabla letters the user has used.</param>
        public void PrintUsedLetters(IEnumerable<IRenderable> usedLetters)
        {
            Console.Write("Used Letters --> ");
            foreach (var letter in usedLetters)
            {
                Console.Write("{0} ", letter.GetBody());
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Prints the number of mistakes the user has made.
        /// </summary>
        /// <param name="numberOfMistakes">Integer number of mistakes.</param>
        public void PrintMistakes(int numberOfMistakes)
        {
            Console.WriteLine("Mistakes: {0}", numberOfMistakes);
        }

        /// <summary>
        /// Prints the end screen if player has cheated.
        /// </summary>
        /// <param name="message">String message for player.</param>
        public void PrintEndScreenIfPlayerCheated(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints an invalid command message for the player.
        /// </summary>
        public void InvalidCommand()
        {
            Console.WriteLine("Invalid command!");
        }

        /// <summary>
        /// Prints a message for the player.
        /// </summary>
        /// <param name="message">String message to printed.</param>
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Clears the entire screen of the console.
        /// </summary>
        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
