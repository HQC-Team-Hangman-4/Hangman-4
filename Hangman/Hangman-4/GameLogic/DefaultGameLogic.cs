namespace HangMan.GameLogic
{
    using System.Collections.Generic;
    using HangMan.GameObjects;
    using HangMan.Helpers;
    using HangMan.Interfaces;

    /// <summary>
    /// Default gameplay logic.
    /// </summary>
    public class DefaultGameLogic
    {
        private Letter letterPrototype = new Letter();
        private Player playerPrototype = new Player();

        /// <summary>
        /// Constructor for default gameplay. 
        /// </summary>
        public DefaultGameLogic()
        {
            this.CurrentPlayerInfo = new GameInfo();
            this.Player = this.playerPrototype.Clone();

            this.IsCheated = false;
        }

        /// <summary>
        /// Gets the game state.
        /// </summary>
        public GameState GameState { get; private set; }

        /// <summary>
        /// Gets and sets the current play info.
        /// </summary>
        public GameInfo CurrentPlayerInfo { get; set; }

        /// <summary>
        /// Gets and sets the player.
        /// </summary>
        public IPlayer Player { get; set; }

        /// <summary>
        /// Gets and sets the current word.
        /// </summary>
        public IWord Word { get; set; }

        /// <summary>
        /// Gets and sets whether player cheated.
        /// </summary>
        public bool IsCheated { get; set; }

        /// <summary>
        /// Gets and sets the letters user used.
        /// </summary>
        public IEnumerable<ILetter> UsedLetters { get; set; }

        /// <summary>
        /// Counts the number of times a letter is guessed.
        /// </summary>
        /// <param name="letter">Letter to be guessed.</param>
        /// <returns>Integer value.</returns>
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

        /// <summary>
        /// Sets the state of the letter if it is guessed or not.
        /// </summary>
        /// <param name="letter">Letter to be guessed.</param>
        /// <returns>Boolean is letter guessed.</returns>
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

        /// <summary>
        /// Parses a command and changes the game state accordingly.
        /// </summary>
        /// <param name="command">String command to be parsed.</param>
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

        /// <summary>
        /// Returns tru if word is revealed, falsre otherwise.
        /// </summary>
        /// <returns>Boolean whether the word is revealed.</returns>
        public bool IsWordRevealed()
        {
            if (this.Word.IsRevealed)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Reveals one letter.
        /// </summary>
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

        /// <summary>
        /// Restarts the game.
        /// </summary>
        internal void Restart()
        {
        }

        /// <summary>
        /// Sets te game state according to a command.
        /// </summary>
        /// <param name="command">String command that determines state to be set.</param>
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

        /// <summary>
        /// Counts the number of letters still not guessed. 
        /// </summary>
        /// <param name="word">IWord word object.</param>
        /// <returns></returns>
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
