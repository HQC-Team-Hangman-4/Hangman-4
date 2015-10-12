namespace HangMan.Engine
{
    using System;
    using HangMan.GameLogic;
    using HangMan.GameObjects;
    using HangMan.Helpers;
    using HangMan.Helpers.Data;
    using HangMan.InputProviders.Data;
    using HangMan.Interfaces;

    /// <summary>
    /// Sets up the game.
    /// </summary>
    public class Engine
    {
        private readonly DefaultGameLogic gameLogic;
        private readonly Scoreboard scoreBoard;
        private readonly IRenderer renderer;
        private readonly IInputProvider inputProvider;
        private IDataSerialization dataSerialization = new DataSerialization();
        private WordDatabase wordDataBase;
        private WordFactory wordFactory;

        /// <summary>
        /// Constructor for the Engine class. 
        /// </summary>
        /// <param name="renderer">IRenderer object</param>
        /// <param name="inputProvider">IInputProvider object.</param>
        public Engine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.inputProvider = inputProvider;
            this.renderer = renderer;
            this.scoreBoard = Scoreboard.Instance;
            this.wordDataBase = new WordDatabase(this.dataSerialization);
            this.wordFactory = new WordFactory(this.wordDataBase);
            this.gameLogic = new DefaultGameLogic();
            this.gameLogic.Word = this.wordFactory.GetWord(Categories.IT);
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame()
        {
            this.renderer.PrintInitialScreen();

            while (this.inputProvider.Command != "exit")
            {
                this.renderer.PrintWord(this.gameLogic.Word);

                this.inputProvider.GetInput();

                this.gameLogic.ParseCommand(this.inputProvider.Command);
                switch (this.gameLogic.GameState)
                {
                    case GameState.guessLetter:
                        this.renderer.PrintUsedLetters(this.gameLogic.CurrentPlayerInfo.UsedLetters);
                        this.renderer.PrintMistakes(this.gameLogic.CurrentPlayerInfo.Mistakes);
                        break;
                    case GameState.top:
                        this.renderer.RenderScoreboard(this.scoreBoard.ViewScoreboard());
                        break;
                    case GameState.help:
                        this.gameLogic.Help();
                        break;
                    case GameState.restart:
                        this.gameLogic.Restart();
                        break;
                    case GameState.exit:
                        this.EndGame();
                        break;
                    case GameState.invalidCommand:
                        this.renderer.InvalidCommand();
                        break;
                    default: this.renderer.InvalidCommand();
                        break;
                }

                if (this.gameLogic.IsWordRevealed())
                {
                    this.EndCurrentWordGame();
                }
            }
        }


        /// <summary>
        /// Ends the game after each guessed word.
        /// </summary>
        private void EndCurrentWordGame()
        {
            this.renderer.PrintWord(this.gameLogic.Word);

            this.gameLogic.Word = this.wordFactory.GetWord(Categories.IT);
            this.gameLogic.CurrentPlayerInfo.UsedLetters.Clear();
            this.gameLogic.CurrentPlayerInfo.Mistakes += this.gameLogic.CurrentPlayerInfo.Mistakes;

            System.Threading.Thread.Sleep(2000);
            this.renderer.ClearScreen();
        }

        /// <summary>
        /// Ends the game and shows highscore after user types 'exit'.
        /// </summary>
        private void EndGame()
        {
            if (!this.gameLogic.IsCheated)
            {
                if (this.gameLogic.Player.Score > 0)
                {
                    this.renderer.PrintEndScreen();

                    while (true)
                    {
                        try
                        {
                            this.inputProvider.GetInput();
                            this.gameLogic.Player.Name = this.inputProvider.Command;
                        }
                        catch (ArgumentNullException ex)
                        {
                            this.renderer.PrintMessage(ex.Message);

                            continue;
                        }
                        catch (ArgumentException ex)
                        {
                            this.renderer.PrintMessage(ex.Message);

                            continue;
                        }

                        this.scoreBoard.AddPlayerScore(this.gameLogic.Player);
                        this.renderer.RenderScoreboard(this.scoreBoard.ViewScoreboard());

                        break;
                    }
                }
                else
                {
                    this.renderer.PrintMessage("Bye bye!");
                }
            }
            else
            {
                this.renderer.PrintEndScreenIfPlayerCheated("You cheated!!!");
            }

            Environment.Exit(1);
        }
    }
}
