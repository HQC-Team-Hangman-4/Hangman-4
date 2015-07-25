namespace HangMan.Interfaces
{
    public interface ILetter
    {
        string Value { get; }

        bool IsFound { get; set; }
    }
}