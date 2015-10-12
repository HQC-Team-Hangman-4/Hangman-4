namespace HangMan.Interfaces
{
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// Provides an interface for data serializers.
    /// </summary>
    public interface IDataSerialization
    {
        ICollection<string> ReadFromFile(FileNames fileName);

        void WriteToFile(IEnumerable<IPlayer> scoreBoardPlayers, FileNames fileName);
    }
}
