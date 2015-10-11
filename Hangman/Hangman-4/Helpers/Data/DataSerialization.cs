namespace HangMan.InputProviders.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using HangMan.Interfaces;
    
    public class DataSerialization : IDataSerialization
    {
        private const string TxtFilePath = "../../Files/{0}.txt";
        private const string ScoreFormat = "{0} {1}";

        public ICollection<string> ReadFromFile(FileNames fileName)
        {
            ICollection<string> textLines = File.ReadAllLines(string.Format(TxtFilePath, fileName));

            return textLines;
        }

        public void WriteToFile(IEnumerable<IPlayer> scoreBoardPlayers, FileNames fileName)
        {
            using (StreamWriter writer = new StreamWriter(string.Format(TxtFilePath, fileName)))
            {
                foreach (var player in scoreBoardPlayers)
                {
                    writer.WriteLine(string.Format(ScoreFormat, player.Name, player.Score));
                }
            }
        }
    }
}
