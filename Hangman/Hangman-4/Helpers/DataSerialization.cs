namespace HangMan.InputProviders
{
    using HangMan.GameObjects;
using HangMan.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

    public static class DataSerialization
    {
        public static ICollection<string> ReadFromFile(FileNames fileName)
        {
            ICollection<string> textLines = File.ReadAllLines("../../Files/" + fileName + ".txt");

            //foreach (var line in textLines)
            //{
            //    Console.WriteLine(line);
            //}

            return textLines;
        }

        public static void WriteToFile(IEnumerable<IPlayer> scoreBoardPlayers, FileNames fileName)
        {

            using (StreamWriter writer = new StreamWriter(string.Format("../../Files/{0}.txt", fileName)))
            {
                foreach (var player in scoreBoardPlayers)
                {
                    writer.WriteLine(string.Format("{0} {1}", player.Name, player.Score));
                }
            }
        }
    }
}
