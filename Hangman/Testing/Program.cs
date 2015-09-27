using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using HangMan.GameObjects;
using HangMan.InputProviders;
using HangMan.Interfaces;

namespace Testing
{

    class Program
    {
        private static Random random = new Random();

        static void Main()
        {
            var listOfLetters = new List<ILetter>();

            for (int i = 0; i < 10; i++)
            {
                var l = (char) (47 + i);
                var letter = new Letter(l.ToString());
                listOfLetters.Add(letter);
            }

            var word = new Word(listOfLetters);
            var player = new Player();
            var guessedWOrd = new Guessed(player);

            Console.WriteLine(guessedWOrd.GetBody());
        }
    }
}
