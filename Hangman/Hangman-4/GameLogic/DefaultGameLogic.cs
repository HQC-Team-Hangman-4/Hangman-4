namespace HangMan.GameLogic
{
    using System;
    using System.Collections.Generic;

    using HangMan.Interfaces;
    using HangMan.InputProviders;
    using HangMan.GameObjects;
    using HangMan.Helpers;

    public class DefaultGameLogic
    {
        public DefaultGameLogic()
        {
            this.CurrentPlayerInfo = new GameInfo();
            this.Player = new Player();

            this.IsCheated = false;
        }

        public GameState gameState { get; private set; }

        public GameInfo CurrentPlayerInfo { get; set; }

        public IPlayer Player { get; set; }

        public IWord Word { get; set; }

        public bool IsCheated { get; set; }

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

        private int LettersLeft(IWord word)
        {
            int countLeftLetters = 0;
            foreach (var letter in word.Content)
            {
                if (!letter.IsFound)
                {
                    countLeftLetters++;
                }
            }

            return countLeftLetters;
        }

        public bool IsLetterGuessed(ILetter letter)
        {
            int guessed = this.GuessLetter(letter);

            if (guessed > 0)
            {
                Player.Score += 5;
                return true;
            }

            else if (Player.Score > 0)
            {
                Player.Score--;
            }
            
            return false;
        }

        private void SetGameState(string  command)
        {
            switch (command)
            {
                case "letter":
                    {
                        this.gameState = GameState.guessLetter;
                        break;
                    }
                case "top":
                    {
                        this.gameState = GameState.top;
                        break;
                    }

                case "help":
                    {
                        this.gameState = GameState.help;
                        break;
                    }

                case "restart":
                    {
                        this.gameState = GameState.restart;
                        this.Restart();
                        break;
                    }
                case "exit":
                    {
                        this.gameState = GameState.exit;
                        break;
                    }

                default:
                    {
                        this.gameState = GameState.invalidCommand;
                        break;
                    }
            }
        }

        internal void Help()
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

        internal void Restart()
        {
            //foreach (var letter in this.Word.Content)
            //{
            //    letter.IsFound = false;
            //}

            //TODO: change method to the right class
            //var words = engine.GetWordsByCategory(); 
            //this.Word = GenerateWordFromString(GetRandomWordByCategory(words, Categories.IT));

        }

        public void ParseCommand(string command)
        {
            if (command.Length == 1)
            {
                ILetter currentLetter = new Letter(command);
                CurrentPlayerInfo.UsedLetters.Add(currentLetter);

                bool isGuessLetter = this.IsLetterGuessed(currentLetter);
                if (isGuessLetter)
                {
                    currentLetter.IsFound = true;
                }
                else
                {
                    this.CurrentPlayerInfo.Mistakes++;
                }

                SetGameState("letter");
            }
            else
            {
                this.SetGameState(command);
            }
        }

        public bool IsWordRevealed()
        {
            if (this.Word.IsRevealed)
            {
                return true;
            }

            return false;
        }
    }
}
