namespace Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Lifetime;
    using System.Text;
    using System.Threading.Tasks;
    using HangMan.GameObjects;
    using HangMan.InputProviders;
    using HangMan.Interfaces;

    public class Program
    {
        private static Random random = new Random();

        public static void Main()
        {
            Letter letterPrototype = new Letter();
            Player playerPrototype = new Player();

            var listOfLetters = new List<ILetter>();

            for (int i = 0; i < 10; i++)
            {
                var l = (char)(47 + i);
                var letter = letterPrototype.Clone();
                letter.Value = l;
                listOfLetters.Add(letter);
            }

            var word = new Word(listOfLetters);
            var player = playerPrototype.Clone();
            var guessedWOrd = new Guessed(player);

            Console.WriteLine(guessedWOrd.GetBody());
        }
    }
}
