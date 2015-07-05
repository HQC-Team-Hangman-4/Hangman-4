namespace HangMan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Hangman
    {
        private static ScoreBoardPosition[] scoreBoard = new ScoreBoardPosition[5];
        private static Random random = new Random();
        private static string[] words = { "computer", "programmer", "software", "debugger", "compiler", "developer", "algorithm", "array", "method", "variable" };
        private string currentWord;
        private char[] playersWord;
        private bool cheated;
        private int mistakes;
        private int lettersLeft;

        public Hangman()
        {
            int wordNumber = random.Next(0, 10);
            this.currentWord = words[wordNumber];
            this.playersWord = new char[this.currentWord.Length];
            this.cheated = false;
            this.mistakes = 0;
            this.lettersLeft = this.playersWord.Length;

            for (int i = 0; i < this.playersWord.Length; i++)
            {
                this.playersWord[i] = '_';
            }

            for (int i = 0; i < 5; i++)
            {
                scoreBoard[i] = new ScoreBoardPosition(string.Empty, 999);
            }
        }

        public void PrintWord()
        {
            Console.WriteLine();
            Console.Write("The secret word is:");

            foreach (var letter in this.playersWord)
            {
                Console.Write(letter + " ");
            }

            Console.WriteLine();
        }

        public void Help()
        {
            int toBeRevealed;
            toBeRevealed = Array.IndexOf(this.playersWord, '_');
            this.playersWord[toBeRevealed] = this.currentWord[toBeRevealed];
            this.cheated = true;
        }

        public bool Guess(char letter)
        {
            int guessed = 0;

            for (int i = 0; i < this.currentWord.Length; i++)
            {
                if (this.currentWord[i] == letter && this.playersWord[i] == '_')
                {
                    guessed++;
                    this.playersWord[i] = letter;
                }
            }

            if (guessed > 0)
            {
                this.lettersLeft = this.lettersLeft - guessed;
                Console.WriteLine("you guessed {0} letters", guessed);

                if (this.lettersLeft == 0)
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine("letter not found");
                this.mistakes++;
            }

            return false;
        }

        public void End()
        {
            Console.WriteLine("Congratulations! You guessed the word");

            if (this.cheated == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (scoreBoard[i].Name == string.Empty || this.mistakes < scoreBoard[i].Mistakes)
                    {
                        Console.WriteLine("Congratulations! You made the scoreboard");
                        Console.Write("Enter your name: ");
                        string playersName = Console.ReadLine();
                        if (scoreBoard[i].Name == string.Empty)
                        {
                            scoreBoard[i].Name = playersName;
                            scoreBoard[i].Mistakes = this.mistakes;
                        }
                        else
                        {
                            scoreBoard[4].Name = playersName;
                            scoreBoard[4].Mistakes = this.mistakes;
                        }

                        Array.Sort(scoreBoard);
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("You cheated");
            }
        }

        public void ShowScoreboard()
        {
            Console.WriteLine();

            for (int i = 0; i < scoreBoard.Length; i++)
            {
                if (scoreBoard[i] != default(ScoreBoardPosition))
                {
                    Console.WriteLine("{0} --> {1} - {2} mistakes", i + 1, scoreBoard[i].Name, scoreBoard[i].Mistakes);
                }
            }

            Console.WriteLine();
        }

        public void Restart()
        {
            int wordNumber = random.Next(0, 11);
            this.currentWord = words[wordNumber];
            this.playersWord = new char[this.currentWord.Length];

            for (int i = 0; i < this.playersWord.Length; i++)
            {
                this.playersWord[i] = '_';
            }

            this.cheated = false;
            this.mistakes = 0;
            this.lettersLeft = this.playersWord.Length;
        }
    }
}
