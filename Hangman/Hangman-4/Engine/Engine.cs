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
        private readonly IEnumerable<string> ScoreBoardInfo = DataSerialization.ReadFromFile(FileNames.scoreboard);
        private readonly IEnumerable<string> WordsInfo = DataSerialization.ReadFromFile(FileNames.words);
        private readonly DefaultGameLogic gameLogic;
        private readonly GameInfo currentPlayerInfo;
        private readonly ScoreBoard scoreBoard;

        private int lettersLeft;
        private bool isCheated;
        private IRenderer consoleRenderer;
        private IPlayer player;
        private IInputProvider inputProvider;

        public Engine(IRenderer consoleRenderer, IInputProvider inputProvider)
        {
            this.consoleRenderer = consoleRenderer;
            this.inputProvider = inputProvider;

            this.currentPlayerInfo = new GameInfo();
            currentPlayerInfo.Mistakes = 0;

            Dictionary<Categories, ICollection<string>> words = GetWordsByCategory();

            player = new Player();
            player.PlayerGameInformation = new List<GameInfo>();

            gameLogic = new DefaultGameLogic();
            gameLogic.Word = GenerateWordFromString(GetRandomWordByCategory(words, Categories.IT));

            this.scoreBoard = new ScoreBoard();

            this.isCheated = false;
        }

        public void StartGame()
        {
            consoleRenderer.PrintInitialScreen();

            while (this.inputProvider.Command != "exit")
            {
                consoleRenderer.PrintWord(this.gameLogic.Word);
                this.inputProvider.Command = Console.ReadLine();

                if (this.inputProvider.Command.Length == 1)
                {
                    IsLetterGuessed();
                }
                else
                {
                    this.SetGameState(this.inputProvider.Command);
                }

                consoleRenderer.PrintUsedLettersAndMistakes(currentPlayerInfo.UsedLetters, currentPlayerInfo.Mistakes);
                if (LettersLeft(this.gameLogic.Word) == 0)
                {
                    EndGame();
                    Restart();
                }
            }
        }

        private void IsLetterGuessed()
        {
            currentPlayerInfo.UsedLetters.Add(new Letter(this.inputProvider.Command));
            int guessed = gameLogic.GuessLetter(new Letter(this.inputProvider.Command[0].ToString()));

            if (guessed > 0)
            {
                this.lettersLeft = this.lettersLeft - guessed;
                Console.WriteLine("you guessed {0} letters", guessed);
                player.Score++;
            }
            else
            {
                Console.WriteLine("letter not found");
                currentPlayerInfo.Mistakes++;

                //todo delete this test
                player.Name = "Koleto";
            }
        }

        private void SetGameState(string command)
        {
            switch (command)
            {
                case "top":
                    {
                        consoleRenderer.RenderScoreboard(this.scoreBoard.GetScoreBoard());
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

        private void Help()
        {
            foreach (var letter in gameLogic.Word.Content)
            {
                if (!letter.IsFound)
                {
                    this.isCheated = true;
                    letter.IsFound = true;
                    return;
                }
            }
        }

        private void EndGame()
        {
            if (!this.isCheated)
            {
                consoleRenderer.PrintEndScreen();

                player.Name = Console.ReadLine();

                this.scoreBoard.AddPlayerToScoreBoard(player);

                consoleRenderer.RenderScoreboard(this.scoreBoard.GetScoreBoard());
            }
            else
            {
                Console.WriteLine("You cheated!");
            }
        }

        private void Restart()
        {
            foreach (var letter in gameLogic.Word.Content)
            {
                letter.IsFound = false;
            }

            var words = GetWordsByCategory();
            gameLogic.Word = GenerateWordFromString(GetRandomWordByCategory(words, Categories.IT));

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
