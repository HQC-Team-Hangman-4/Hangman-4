using HangMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan.Renderers
{
    public class ConsoleRenderer : IRenderer
    {
        public void PrintInitialScreen()
        {
            Console.WriteLine("Welcome to Hangman");
            Console.WriteLine("Use 'top' to view the top scoreboard," +
            "'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.");
        }

        public void PrintWord(IWord word)
        {
            Console.WriteLine();
            Console.Write("The secret word is: ");

            foreach (var letter in word.Content)
            {
                if (letter.IsFound)
                {
                    Console.Write(letter.Value + " ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }

            Console.WriteLine();
            Console.Write("enter a letter or command: ");
        }

        public void PrintEndScreen()
        {
            Console.WriteLine("Congratulations! You made the scoreboard");
            Console.Write("Enter your name: ");
        }

        public void RenderScoreboard(IEnumerable<IPlayer> scoreBoardInfo)
        {
            foreach (var player in scoreBoardInfo)
            {
                Console.WriteLine("NickName: {0} --> Score: {1}", player.Name, player.Score);
            }
        }

        public void PrintUsedLettersAndMistakes(IEnumerable<ILetter> usedLetters, int numberOfMistakes)
        {
            Console.Write("Used Letters --> ");
            foreach (var letter in usedLetters)
            {
                Console.Write("{0} ", letter.Value);
            }
            Console.WriteLine();
            Console.WriteLine("Mistakes: {0}", numberOfMistakes);
        }
    }
}
