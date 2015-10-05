namespace HangMan.Helpers.Data
{
    public interface IWordDatabase
    {
        string GetRandomWordByCategory(Categories category);
    }
}
