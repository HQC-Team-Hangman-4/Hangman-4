namespace HangMan.Engine
{
    using HangMan.GameLogic;
    using HangMan.GameObjects;
    using HangMan.Interfaces;
    using HangMan.Renderers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Helpers;

    public class Engine
    {
        private readonly IEnumerable<string> ScoreBoardInfo = DataSerialization.ReadFromFile(FileNames.scoreboard);
        private readonly IEnumerable<string> WordsInfo = DataSerialization.ReadFromFile(FileNames.words);

        private bool isCheated;
        private int mistakes;
        private int lettersLeft;
        private IWord currentWord;
        private ConsoleRenderer renderer;

        public void SetupGame()
        {
            var words = GetWordsByCategory();

           this.currentWord =  GenerateWordFromString(GetRandomWordByCategory(words, Categories.IT));

            renderer = new ConsoleRenderer();
            renderer.RenderScoreboard(ScoreBoardInfo);

            Console.WriteLine(currentWord);
            this.isCheated = false;

            GameInfo currentPlayerInfo = new GameInfo();
            currentPlayerInfo.Mistakes = 0;
        }

        public void StartGame()
        {
            DataSerialization.ReadFromFile(FileNames.words);
            SetupGame();

            renderer.PrintInitialScreen();
            renderer.PrintWord(this.currentWord);
            Console.Write("enter a letter or command: ");

            string input = Console.ReadLine();
            DefaultGameLogic gameLogic = new DefaultGameLogic();
            gameLogic.Word = this.currentWord;
            while (input != "exit")
            {
                if (input.Length == 1)
                {
                    int guessed = gameLogic.GuessLetter(new Letter(input[0].ToString()));

                    if (guessed > 0)
                    {
                        this.lettersLeft = this.lettersLeft - guessed;
                        Console.WriteLine("you guessed {0} letters", guessed);
                    }
                    else
                    {
                        Console.WriteLine("letter not found");
                        gameLogic.Mistakes++;
                    }

                    if (LettersLeft(currentWord) == 0)
                    {
                        //TODO: UpdateScoreboard(IPlayer);
                        gameLogic.EndGame();
                    }
                }
                else
                {
                    gameLogic.SetGameState(input);
                }

                Console.WriteLine("Use 'top' to view the top scoreboard," + "'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.");
                renderer.PrintWord(currentWord);
                Console.Write("enter a letter or command: ");
                input = Console.ReadLine();
            }

            Console.WriteLine("Goodbye");
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
