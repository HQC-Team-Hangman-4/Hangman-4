namespace HangMan.InputProviders.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using HangMan.Interfaces;
    
    /// <summary>
    /// Serializes and deserializes data from the file system.
    /// </summary>
    public class DataSerialization : IDataSerialization
    {
        private const string TxtFilePath = "../../Files/{0}.txt";
        private const string ScoreFormat = "{0} {1}";

        /// <summary>
        /// Reads data from file to collection.
        /// </summary>
        /// <param name="fileName">File name in the file system to read from.</param>
        /// <returns>ICollection<string> collection of lines in the file.</returns>
        public ICollection<string> ReadFromFile(FileNames fileName)
        {
            ICollection<string> textLines = File.ReadAllLines(string.Format(TxtFilePath, fileName));

            return textLines;
        }

        /// <summary>
        /// Writes data to file.
        /// </summary>
        /// <param name="scoreBoardPlayers">Collection of players.</param>
        /// <param name="fileName">File name in the file system to write in.</param>
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
