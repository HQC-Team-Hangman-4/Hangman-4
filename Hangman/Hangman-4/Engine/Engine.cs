namespace HangMan.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using HangMan.GameLogic;
    using HangMan.GameObjects;
    using HangMan.Interfaces;
    using HangMan.Renderers;
   
    using Helpers;

    public class Engine
    {
        private readonly IEnumerable<string> ScoreBoardInfo = DataSerialization.ReadFromFile(FileNames.scoreboard);
        private readonly IEnumerable<string> WordsInfo = DataSerialization.ReadFromFile(FileNames.words);

        private int mistakes;
        private int lettersLeft;
        private bool isCheated;
        private IRenderer consoleRenderer;
        private IPlayer player;
        private IInputProvider inputProvider;
        private DefaultGameLogic gameLogic;

        public Engine(IRenderer consoleRenderer, IInputProvider inputProvider) 
        {
            this.consoleRenderer = consoleRenderer;
            this.inputProvider = inputProvider;

        }

        public void SetupGame()
        {
            var words = GetWordsByCategory();
            
            this.isCheated = false;

            GameInfo currentPlayerInfo = new GameInfo();
            currentPlayerInfo.Mistakes = 0;

            player = new Player();
            player.PlayerGameInformation = new List<GameInfo>();
            gameLogic = new DefaultGameLogic();
            gameLogic.Word = GenerateWordFromString(GetRandomWordByCategory(words, Categories.IT));
        }

        public void StartGame()
        {
            DataSerialization.ReadFromFile(FileNames.words);
            SetupGame();

            consoleRenderer.PrintInitialScreen();
            consoleRenderer.PrintWord(gameLogic.Word);

            Console.Write("enter a letter or command: ");
            string input = Console.ReadLine();
            GameInfo gameInfo = new GameInfo();

            while (input != "exit")
            {
                if (input.Length == 1)
                {
                    gameInfo.UsedLetters.Add(new Letter(input));
                    int guessed = gameLogic.GuessLetter(new Letter(input[0].ToString()));

                    if (guessed > 0)
                    {
                        this.lettersLeft = this.lettersLeft - guessed;
                        Console.WriteLine("you guessed {0} letters", guessed);
                        player.Score++;
                    }
                    else
                    {
                        Console.WriteLine("letter not found");
                        gameInfo.Mistakes++;

                        //todo delete this test
                        player.Name = "Koleto";
                    }

                    if (LettersLeft(this.gameLogic.Word) == 0)
                    {
                        EndGame();
                        Restart();
                    }
                }
                else
                {
                    this.SetGameState(input);
                }

                Console.WriteLine("Use 'top' to view the top scoreboard," + "'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.");
                consoleRenderer.PrintWord(this.gameLogic.Word);
                Console.Write("enter a letter or command: ");
                input = Console.ReadLine();
            }

            Console.WriteLine("Goodbye");
        }

        private void SetGameState(string command)
        {
            switch (command)
            {
                case "top":
                    {
                        consoleRenderer.RenderScoreboard(ScoreBoard.GetScoreBoard());
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

        public void EndGame()
        {
            if (!this.isCheated)
            {
                Console.WriteLine("Congratulations! You made the scoreboard");
                Console.Write("Enter your name: ");
                player.Name = Console.ReadLine();
 
                ScoreBoard.AddPlayerToScoreBoard(player);

                consoleRenderer.RenderScoreboard(ScoreBoard.GetScoreBoard());
            }
            else
            {
                Console.WriteLine("You cheated!");
            }
        }

        public void Restart()
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
