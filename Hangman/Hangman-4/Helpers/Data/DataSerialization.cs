namespace HangMan.InputProviders.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using HangMan.Interfaces;
    
    public class DataSerialization : IDataSerialization
    {
        public ICollection<string> ReadFromFile(FileNames fileName)
        {
            ICollection<string> textLines = File.ReadAllLines("../../Files/" + fileName + ".txt");

            return textLines;
        }

        public void WriteToFile(IEnumerable<IPlayer> scoreBoardPlayers, FileNames fileName)
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
