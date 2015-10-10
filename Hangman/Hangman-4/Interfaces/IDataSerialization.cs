namespace HangMan.Interfaces
{
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;

    public interface IDataSerialization
    {
        ICollection<string> ReadFromFile(FileNames fileName);

        void WriteToFile(IEnumerable<IPlayer> scoreBoardPlayers, FileNames fileName);
    }
}
