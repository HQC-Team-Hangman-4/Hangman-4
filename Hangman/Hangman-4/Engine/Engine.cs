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
        private readonly IEnumerable<string> WordsInfo = DataSerialization.ReadFromFile(FileNames.words);
        private readonly DefaultGameLogic gameLogic;
        private readonly IRenderer consoleRenderer;
        private readonly ScoreBoard scoreBoard;

        private IInputProvider inputProvider;

        public Engine(IRenderer consoleRenderer, IInputProvider inputProvider)
        {
            Dictionary<Categories, ICollection<string>> words = GetWordsByCategory();

            this.inputProvider = inputProvider;
            this.consoleRenderer = consoleRenderer;
            this.scoreBoard = new ScoreBoard();
            this.gameLogic = new DefaultGameLogic();
            this.gameLogic.Word = GenerateWordFromString(GetRandomWordByCategory(words, Categories.IT));
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

        private Dictionary<Categories, ICollection<string>> GetWordsByCategory()
        {
            Dictionary<Categories, ICollection<string>> wordWithCategory = new Dictionary<Categories, ICollection<string>>();

            foreach (var categoryWithWord in WordsInfo)
            {
                var currentCategoryString = categoryWithWord.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                var currentWord = categoryWithWord.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

                Categories currentCategory = (Categories)Enum.Parse(typeof(Categories), currentCategoryString);

                if (!wordWithCategory.ContainsKey(currentCategory))
                {
                    wordWithCategory.Add(currentCategory, new List<string>() { currentWord }); //TODO: change list
                }
                else
                {
                    var currentWordsInCategory = wordWithCategory[currentCategory];
                    currentWordsInCategory.Add(currentWord);
                    wordWithCategory[currentCategory] = currentWordsInCategory;
                }
            }

            return wordWithCategory;
        }

        private string GetRandomWordByCategory(Dictionary<Categories, ICollection<string>> words, Categories category)
        {
            Random random = new Random();

            //TODO: remove guessed word 
            var categoryWords = words.Where(categoryWord => categoryWord.Key == category).Select(catWord => catWord.Value).ToList()[0].ToList();

            string resultWord = categoryWords[random.Next(0, categoryWords.Count)];

            return resultWord;
        }

        private IWord GenerateWordFromString(string wordString)
        {
            List<ILetter> currentWordLetters = new List<ILetter>();
            foreach (var letter in wordString)
            {
                currentWordLetters.Add(new Letter(letter.ToString()));
            }

            return new Word(currentWordLetters);
        }

    }
}
