namespace HangMan.Interfaces
{
    public interface IWordDatabase
    {
        string GetRandomWordByCategory(Categories category);
    }
}
