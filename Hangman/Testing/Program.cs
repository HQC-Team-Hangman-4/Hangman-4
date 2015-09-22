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
            var allWords = DataSerialization.ReadFromFile(FileNames.words)
                                            .Where(x => x.Contains("IT")).ToArray();

            var randomIndex = random.Next(0, allWords.Count());
            var separator = allWords[randomIndex].IndexOf(" ") + 1;
            var word = allWords[randomIndex].Substring(separator);

            var allLetters = new List<ILetter>();

            foreach (var letter in word)
            {
                allLetters.Add(new Letter(letter.ToString()));
            }

            foreach (var letter in allLetters)
            {
                Console.WriteLine(letter.Value);
            }
        }
    }
}
