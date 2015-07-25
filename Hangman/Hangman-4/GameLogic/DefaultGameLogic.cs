namespace HangMan.GameLogic
{
    using System;
    using System.Collections.Generic;

    using HangMan.Interfaces;
    using HangMan.Helpers;
    using HangMan.GameObjects;

    public class DefaultGameLogic
    {
        public IWord Word { get; set; }
        public int Mistakes { get; set; }
        public bool IsCheated { get; set; }
        public ScoreBoard scoreBoard;

        public IEnumerable<ILetter> UsedLetters { get; set; }

        public int GuessLetter(ILetter letter)
        {
            int guessedLetter = 0;
            foreach (var symbol in this.Word.Content)
            {
                if (!symbol.IsFound && symbol.Value == letter.Value)
                {
                    symbol.IsFound = true;
                    guessedLetter++;
                }
            }

            return guessedLetter;
        }

        public void SetGameState(string command)
        {
            switch (command)
            {
                case "top":
                    {
                        ShowScoreboard();
                        break;
                    }

                case "help":
                    {
                        Help();
                        break;
                    }

                case "restart":
                    {
                        Restart();
                        break;
                    }

                default:
                    {
                        Console.WriteLine("invalid command");
                        break;
                    }
            }
        }

        public void Help()
        {
            foreach (var letter in this.Word.Content)
            {
                if (!letter.IsFound)
                {
                    this.IsCheated = true;
                    letter.IsFound = true;
                    return;
                }
            }

        }

        public void EndGame()
        {
            Console.WriteLine("GAME OVER");

            //Console.WriteLine("Congratulations! You guessed the word");

            //if (isCheated == false)
            //{

            //for (int i = 0; i < scoreBoardInfo.coun; i++)
            //{
            //    if (scoreBoard[i].Name == string.Empty || this.Mistakes < scoreBoard[i].Mistakes)
            //    {
            //        Console.WriteLine("Congratulations! You made the scoreboard");
            //        Console.Write("Enter your name: ");
            //        string playersName = Console.ReadLine();
            //        if (scoreBoard[i].Name == string.Empty)
            //        {
            //            scoreBoard[i].Name = playersName;
            //            scoreBoard[i].Mistakes = this.Mistakes;
            //        }
            //        else
            //        {
            //            scoreBoard[4].Name = playersName;
            //            scoreBoard[4].Mistakes = this.Mistakes;
            //        }

            //        Array.Sort(scoreBoard);
            //        return;
            //    }
            //}
            //}
            //else
            //{
            //    Console.WriteLine("You cheated");
            //}
        }

        public void ShowScoreboard()
        {
            Console.WriteLine();

            //for (int i = 0; i < scoreBoard.Length; i++)
            //{
            //    if (scoreBoard[i] != default(ScoreBoard))
            //    {
            //        Console.WriteLine("{0} --> {1} - {2} mistakes", i + 1, scoreBoard[i].Name, scoreBoard[i].Mistakes);
            //    }
            //}

            //Console.WriteLine();
        }

        public void Restart()
        {
            //int wordNumber = random.Next(0, 11);
            //this.currentWord = words[wordNumber];
            //this.playersWord = new char[this.currentWord.Length];

            //for (int i = 0; i < this.playersWord.Length; i++)
            //{
            //    this.playersWord[i] = '_';
            //}

            //this.cheated = false;
            //this.mistakes = 0;
            //this.lettersLeft = this.playersWord.Length;
        }
    }
}
