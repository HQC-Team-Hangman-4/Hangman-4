namespace HangMan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Interface
    {
        Random random = new Random();

        static void Main()
        {
            Hangman game = new Hangman();
            Console.WriteLine("Welcome to Hangman");
            Console.WriteLine("Use 'top' to view the top scoreboard," +
            "'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.");
            game.PrintWord();
            Console.Write("enter a letter or command: ");
            string input = Console.ReadLine();

            while (input != "exit")
            {
                if (input.Length == 1)
                {
                    bool flag;
                    flag = game.Guess(input[0]);

                    if (flag == true)
                    {
                        game.End();
                        game.Restart();
                    }
                }
                else
                {
                    switch (input)
                    {
                        case "top":
                            {
                                game.ShowScoreboard();
                                break;
                            }

                        case "help":
                            {
                                game.Help();
                                break;
                            }

                        case "restart":
                            {
                                game.Restart();
                                break;
                            }

                        default:
                            {
                                Console.WriteLine("invalid command");
                                break;
                            }
                    }
                }

                Console.WriteLine("Use 'top' to view the top scoreboard," +
                    "'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.");
                game.PrintWord();
                Console.Write("enter a letter or command: ");
                input = Console.ReadLine();
            }

            Console.WriteLine("Goodby");
        }
    }
}
