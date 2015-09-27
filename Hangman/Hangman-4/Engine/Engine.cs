using HangMan.Helpers;

namespace HangMan.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using HangMan.GameLogic;
    using HangMan.GameObjects;
    using HangMan.Interfaces;
    using HangMan.Renderers;

    using InputProviders;

    public class Engine
    {
        //private readonly IEnumerable<string> ScoreBoardInfo = DataSerialization.ReadFromFile(FileNames.scoreboard);

        //make wrapper around where do you get the word information from(Dependency inversion of the way you get information)
        private readonly DefaultGameLogic gameLogic;
        private readonly IRenderer consoleRenderer;
        private readonly ScoreBoard scoreBoard;
        //Word stuff, should be refactored.
        private IDataSerialization dataSerialization = new DataSerialization();
        private WordDatabase wordDataBase;
        private WordFactory wordFactory;

        private IInputProvider inputProvider;

        public Engine(IRenderer consoleRenderer, IInputProvider inputProvider)
        {
            this.inputProvider = inputProvider;
            this.consoleRenderer = consoleRenderer;
            this.scoreBoard = new ScoreBoard();
            this.gameLogic = new DefaultGameLogic();
            this.wordDataBase = new WordDatabase(dataSerialization);
            this.wordFactory = new WordFactory(wordDataBase);
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

                this.gameLogic.PrintWhenStateGameIsChanging(consoleRenderer.PrintUsedLetters, consoleRenderer.PrintMistakes, consoleRenderer.RenderScoreboard, this.scoreBoard);


                //this.consoleRenderer.RenderScoreboard(scoreBoard.GetScoreBoard()); // top

                //this.consoleRenderer.PrintUsedLetters(this.gameLogic.CurrentPlayerInfo.UsedLetters); // guess letter

                //this.consoleRenderer.PrintMistakes(this.gameLogic.CurrentPlayerInfo.Mistakes); // guess letter 
                //

                if (this.gameLogic.IsWordRevealed())
                {
                    this.EndGame();
                }
            }
        }

        //TODO: move to Gamelogic
        private void EndGame()
        {
            if (!this.gameLogic.IsCheated)
            {
                this.consoleRenderer.PrintEndScreen();

                this.gameLogic.Player.Name = Console.ReadLine(); //TODO: use inputprovider

                this.scoreBoard.AddPlayerToScoreBoard(this.gameLogic.Player);

                consoleRenderer.RenderScoreboard(this.scoreBoard.GetScoreBoard());
            }
            else
            {
                this.consoleRenderer.PrintEndScreenIfYouPlayerCheated("You cheated!!!");
            }
        }

    }
}
