namespace HangMan.GameLogic
{
    using System.Collections.Generic;
    using HangMan.GameObjects;
    using HangMan.Helpers;
    using HangMan.Interfaces;

    public class DefaultGameLogic
    {
        private Letter letterPrototype = new Letter();
        private Player playerPrototype = new Player();

        public DefaultGameLogic()
        {
            this.CurrentPlayerInfo = new GameInfo();
            this.Player = this.playerPrototype.Clone();

            this.IsCheated = false;
        }

        public GameState GameState { get; private set; }

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

        public bool IsLetterGuessed(ILetter letter)
        {
             int guessed = this.GuessLetter(letter);

            if (guessed > 0)
            {
                this.Player.Score += 5;
                return true;
            }
            else if (this.Player.Score > 0)
            {
                this.Player.Score--;
            }
            
            return false;
        }
            
        public void ParseCommand(string command)
        {
            if (command.Length == 1)
            {
                ILetter currentLetter = this.letterPrototype.Clone();
                currentLetter.Value = command[0];
                this.CurrentPlayerInfo.UsedLetters.Add(currentLetter);

                bool isGuessLetter = this.IsLetterGuessed(currentLetter);
                if (isGuessLetter)
                {
                    currentLetter.IsFound = true;
                }
                else
                {
                    this.CurrentPlayerInfo.Mistakes++;
                }

                this.SetGameState("letter");
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
        }

        private void SetGameState(string command)
        {
            switch (command)
            {
                case "letter":
                    {
                        this.GameState = GameState.guessLetter;

                        break;
                    }

                case "top":
                    {
                        this.GameState = GameState.top;

                        break;
                    }

                case "help":
                    {
                        this.GameState = GameState.help;

                        break;
                    }

                case "restart":
                    {
                        this.GameState = GameState.restart;
                        this.Restart();

                        break;
                    }

                case "exit":
                    {
                        this.GameState = GameState.exit;

                        break;
                    }

                default:
                    {
                        this.GameState = GameState.invalidCommand;

                        break;
                    }
            }
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
    }
}
