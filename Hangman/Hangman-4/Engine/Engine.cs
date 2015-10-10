namespace HangMan.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using HangMan.GameLogic;
    using HangMan.GameObjects;
    using HangMan.Interfaces;
    using HangMan.Renderers;
    using HangMan.Helpers;
    using HangMan.Helpers.Data;
    using HangMan.InputProviders.Data;

    using InputProviders;

    public class Engine
    {
        //private readonly IEnumerable<string> ScoreBoardInfo = DataSerialization.ReadFromFile(FileNames.scoreboard);

        //make wrapper around where do you get the word information from(Dependency inversion of the way you get information)
        private readonly DefaultGameLogic gameLogic;
        private readonly IRenderer consoleRenderer;
        private readonly Scoreboard scoreBoard;
        //Word stuff, should be refactored.
        private IDataSerialization dataSerialization = new DataSerialization();
        private WordDatabase wordDataBase;
        private WordFactory wordFactory;

        private IInputProvider inputProvider;

        public Engine(IRenderer consoleRenderer, IInputProvider inputProvider)
        {
            this.inputProvider = inputProvider;
            this.consoleRenderer = consoleRenderer;
            this.scoreBoard = Scoreboard.Instance;
            this.wordDataBase = new WordDatabase(dataSerialization);
            this.wordFactory = new WordFactory(wordDataBase);
            this.gameLogic = new DefaultGameLogic();
            //Should generate word according to input! 
            this.gameLogic.Word = wordFactory.GetWord(Categories.IT);
        }

        public void StartGame()
        {
            consoleRenderer.PrintInitialScreen();

            while (this.inputProvider.Command != "exit")
            {
                this.consoleRenderer.PrintWord(this.gameLogic.Word);

                this.inputProvider.GetInput();

                this.gameLogic.ParseCommand(this.inputProvider.Command);

                switch (this.gameLogic.gameState)
                {
                    case GameState.guessLetter:
                        this.consoleRenderer.PrintUsedLetters(this.gameLogic.CurrentPlayerInfo.UsedLetters);
                        this.consoleRenderer.PrintMistakes(this.gameLogic.CurrentPlayerInfo.Mistakes); 
                        break;
                    case GameState.top:
                        this.consoleRenderer.RenderScoreboard(scoreBoard.ViewScoreboard());
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
                        this.consoleRenderer.InvalidCommand();
                        break;
                    default: this.consoleRenderer.InvalidCommand();
                        break;
                }

                if (this.gameLogic.IsWordRevealed())
                {
                    this.EndCurrentWordGame();
                }
            }
        }

        private void EndCurrentWordGame()
        {
            this.consoleRenderer.PrintWord(this.gameLogic.Word);

            this.gameLogic.Word = wordFactory.GetWord(Categories.IT);
            this.gameLogic.CurrentPlayerInfo.UsedLetters.Clear();
            this.gameLogic.CurrentPlayerInfo.Mistakes += this.gameLogic.CurrentPlayerInfo.Mistakes;
        }
        
        private void EndGame()
        {
            if (!this.gameLogic.IsCheated)
            {
                if (this.gameLogic.Player.Score > 0)
                {
                    this.consoleRenderer.PrintEndScreen();

                    while (true)
                    {
                        try
                        {
                            this.inputProvider.GetInput();
                            this.gameLogic.Player.Name = this.inputProvider.Command;

                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Try again.");

                            continue;
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Try again.");

                            continue;
                        }

                        break;
                    }

                    consoleRenderer.RenderScoreboard(this.scoreBoard.ViewScoreboard());

                    this.scoreBoard.AddPlayerScore(this.gameLogic.Player);
                }

                else
                {
                    Console.WriteLine("Bye bye!");
                }
                
            }
            else
            {
                this.consoleRenderer.PrintEndScreenIfYouPlayerCheated("You cheated!!!");
            }

            Environment.Exit(1);
        }
    }
}
